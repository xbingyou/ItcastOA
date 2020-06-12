using CZBK.ItcastOA.BLL;
using CZBK.ItcastOA.IBLL;
using CZBK.ItcastOA.Model;
using CZBK.ItcastOA.Model.EnumType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CZBK.ItcastOA.WebApp.Controllers
{
    public class UserInfoController : BaseController //Controller
    {
        // GET: UserInfo
        IUserinfoService UserInfoService { get; set; }

        public ActionResult Index()
        {
            return View();
        }

        #region 获取用户列表数据
        public ActionResult GetUserInfoList()
        {
            int pageIndex = Request["page"] != null ? int.Parse(Request["page"]) : 1;
            int pageSize = Request["rows"] != null ? int.Parse(Request["rows"]) : 5;
            int totalCount;
            short delFlag = (short)DeleteEnumType.Normarl;
            var userInfoList = UserInfoService.LoadPageEntities(pageIndex, pageSize, out totalCount,
                c => c.DELFLAG == delFlag, c => c.ID, true);
            var temp = from u in userInfoList
                       select new
                       {
                           ID = u.ID,
                           UNAME = u.UNAME,
                           UPWD = u.UPWD,
                           REMARK = u.REMARK,
                           SUBTIME = u.SUBTIME
                       };
            return Json(new { rows = temp, total = totalCount, }, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region 删除用户数据
        public ActionResult DeleteUserInfo()
        {
            string strId = Request["strId"];
            string[] strIds = strId.Split(',');
            List<decimal> list = new List<decimal>();
            foreach (string id in strIds)
            {
                list.Add(Convert.ToInt32(id));
            }
            //将list集合存储的的要删除的记录的编号传递到业务层.
            if (UserInfoService.DeleteEntities(list))
            {
                return Content("ok");
            }
            else
            {
                return Content("no");
            }
        }
        #endregion

        #region 添加用户数据
        public ActionResult AddUserInfo(USERINFO userInfo)
        {
            userInfo.ID = decimal.Parse(userInfo.SORT);
            userInfo.DELFLAG = 0;
            userInfo.MODIFIEDON = DateTime.Now;
            userInfo.SUBTIME = DateTime.Now;
            UserInfoService.AddEntity(userInfo);
            return Content("ok");
        }
        #endregion

        #region 展示要修改的数据
        public ActionResult ShowEditInfo()
        {
            decimal id = decimal.Parse(Request["id"]);
            USERINFO userInfo = UserInfoService.LoadEntities(c => c.ID == id).FirstOrDefault();
            return Json(userInfo, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region 完成用户数据的更新
        public ActionResult EditUserInfo(USERINFO userInfo)
        {
            userInfo.MODIFIEDON = DateTime.Now;
            if (UserInfoService.EditEntity(userInfo))
            {
                return Content("ok");
            }
            else
            {
                return Content("no");
            }
        }
        #endregion
    }
}