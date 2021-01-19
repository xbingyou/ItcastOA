using CZBK.ItcastOA.Model;
using Spring.Context;
using Spring.Context.Support;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;

namespace CZBK.ItcastOA.WebApp.Controllers
{
    public class BaseController : Controller
    {
        public USERINFO LoginUser { get; set; }
        /// <summary>
        /// 执行控制器中的方法之前，先执行该方法
        /// </summary>
        /// <param name="filterContext"></param>
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            bool isSucess = false;
            if (Request.Cookies["sessionId"] != null)
            {
                string sessionId = Request.Cookies["sessionId"].Value;
                //根据该值查Memcache.
                object obj = Common.MemcacheHelper.Get(sessionId);
                if (obj != null)
                {
                    USERINFO userInfo = Common.SerializeHelper.DeserializeToObject<USERINFO>(obj.ToString());
                    LoginUser = userInfo;
                    isSucess = true;
                    //Common.MemcacheHelper.Set(sessionId, obj, DateTime.Now.AddMinutes(20));//模拟出滑动过期时间.
                    //完成权限校验。
                    if (LoginUser.UNAME == "caomao")//超级管理员
                        return;
                    //获取用户请求的URL地址.
                    string url = Request.Url.AbsolutePath;
                    if (url == "/" || url.Contains("/Home/"))//首页不用权限
                        return;
                    //获取请求的方式.
                    string httpMehotd = Request.HttpMethod;
                    //根据获取的URL地址与请求的方式查询权限表。
                    IApplicationContext ctx = ContextRegistry.GetContext();
                    IBLL.IActioninfoService ActionInfoService = (IBLL.IActioninfoService)ctx.GetObject("ActionInfoService");
                    var actionInfo = ActionInfoService.LoadEntities(a => a.URL == url && a.HTTPMETHOD == httpMehotd).FirstOrDefault();
                    if (actionInfo == null)
                    {
                        filterContext.Result = new JavaScriptResult()
                        {
                            Script = "alert('权限不足');"
                        };
                        //filterContext.Result = Redirect("/Error.html");
                        return;
                    }

                    //判断用户是否具有所访问的地址对应的权限
                    IBLL.IUserinfoService UserInfoService = (IBLL.IUserinfoService)ctx.GetObject("UserInfoService");
                    var loginUserInfo = UserInfoService.LoadEntities(u => u.ID == LoginUser.ID).FirstOrDefault();
                    //1:可以先按照用户权限这条线进行过滤。
                    var isExt = (from a in loginUserInfo.R_USERINFO_ACTIONINFO
                                 where a.ACTIONINFOID == actionInfo.ID
                                 select a).FirstOrDefault();
                    if (isExt != null)
                    {
                        if (isExt.ISPASS == 1)
                        {
                            return;
                        }
                        else
                        {
                            filterContext.Result = Redirect("/Error.html");
                            return;
                        }
                    }
                    //2：按照用户角色权限这条线进行过滤。
                    var loginUserRole = loginUserInfo.R_USERINFO_ROLEINFO;
                    var count = (from r in loginUserRole
                                 from a in r.ROLEINFO.R_ROLEINFO_ACTIONINFO
                                 where a.ID == actionInfo.ID
                                 select a).Count();
                    if (count < 1)
                    {
                        filterContext.Result = Redirect("/Error.html");
                        return;
                    }
                }
                //  filterContext.HttpContext.Response.Redirect("/Login/Index");
            }
            if (!isSucess)
            {
                filterContext.Result = Redirect("/Login/Index");//注意.
            }
        }
    }
}