﻿using CZBK.ItcastOA.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CZBK.ItcastOA.WebApp.Controllers
{
    public class LoginController : Controller
    {
        IBLL.IUserinfoService UserInfoService { get; set; }
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        #region 完成用户登录
        public ActionResult UserLogin()
        {
            string validateCode = Session["validateCode"] != null ? Session["validateCode"].ToString() : string.Empty;
            if (string.IsNullOrEmpty(validateCode))
                return Content("no:验证码错误!!");
            Session["validateCode"] = null;
            string txtCode = Request["vCode"];
            if (!validateCode.Equals(txtCode, StringComparison.InvariantCultureIgnoreCase))
                return Content("no:验证码错误!!");
            string userName = Request["LoginCode"];
            string userPwd = Request["LoginPwd"];
            //根据用户名找用户
            var userInfo = UserInfoService.LoadEntities(u => u.UNAME == userName && u.UPWD == userPwd).FirstOrDefault();
            if (userInfo != null)
            {
                Session["userInfo"] = UserInfoService;
                string sessionId = Guid.NewGuid().ToString();
                Common.MemcacheHelper.Set(sessionId, Common.SerializeHelper.SerializeToString(userInfo)
                    , DateTime.Now.AddDays(2));//将登录用户信息存储到Memcache中。AddMinutes(20)
                Response.Cookies["sessionId"].Value = sessionId;//将Memcache的key以Cookie的形式返回给浏览器。
                Response.Cookies["sessionId"].Expires = DateTime.Now.AddDays(2);//存的时候指定过期时间
                return Content("ok:登录成功!!");
            }
            else
                return Content("no:登录失败!!");
        }
        #endregion

        #region 显示验证码
        public ActionResult ShowValidateCode()
        {
            ValidateCode validateCode = new ValidateCode();
            string code = validateCode.CreateValidateCode(4);//产生验证码
            Session["validateCode"] = code;
            byte[] buffer = validateCode.CreateValidateGraphic(code);//将验证码画到画布上
            return File(buffer,"image/jpeg");
        }
        #endregion
    }
}