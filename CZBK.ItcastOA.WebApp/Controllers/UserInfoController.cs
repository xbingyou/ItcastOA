using CZBK.ItcastOA.BLL;
using CZBK.ItcastOA.IBLL;
using CZBK.ItcastOA.Model;
using CZBK.ItcastOA.Model.EnumType;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CZBK.ItcastOA.Common;

namespace CZBK.ItcastOA.WebApp.Controllers
{
    public class UserInfoController : BaseController //Controller
    {
        // GET: UserInfo
        IUserinfoService UserInfoService { get; set; }
        IRoleinfoService RoleInfoService { get; set; }
        IActioninfoService ActionInfoService { get; set; }
        IR_userinfo_actioninfoService R_UserInfo_ActionInfoService { get; set; }

        public ActionResult Index()
        {
            return View();
        }

        #region 获取用户列表数据
        public ActionResult GetUserInfoList(string strID,string strName)
        {
            int pageIndex = Request["page"] != null ? int.Parse(Request["page"]) : 1;
            int pageSize = Request["rows"] != null ? int.Parse(Request["rows"]) : 5;
            int totalCount;
            short delFlag = (short)DeleteEnumType.Normarl;
            int nID = BasePubfun.ConvertToInt32(strID, -1);            
            System.Linq.Expressions.Expression<Func<USERINFO, bool>> whereLambda = c => c.DELFLAG == delFlag;
            if (nID >= 0)
                whereLambda = whereLambda.And(c => c.ID == nID);
            if (!string.IsNullOrEmpty(strName) && strName.Length >= 1)
                whereLambda = whereLambda.And(c => c.UNAME.Contains(strName));
            var userInfoList = UserInfoService.LoadPageEntities(pageIndex, pageSize, out totalCount,
                whereLambda, c => c.ID, true);
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
            userInfo.ID = userInfo.ID;
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
            //使用匿名类，解决USERINFO中有集合类数据ICollection<R_USERINFO_ACTIONINFO>转换JSON失败的问题
            var obj = new
            {
                userInfo.UNAME,
                userInfo.UPWD,
                userInfo.REMARK,
                userInfo.SORT,
                userInfo.DELFLAG,
                userInfo.SUBTIME
            };
            return Json(obj, JsonRequestBehavior.AllowGet);
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

        #region 展示用户已经有的角色
        public ActionResult ShowUserRoleInfo()
        {
            int id = int.Parse(Request["id"]);
            var userInfo = UserInfoService.LoadEntities(u => u.ID == id).FirstOrDefault();
            ViewBag.UserInfo = userInfo;
            //查询所有的角色.
            short delFlag = (short)DeleteEnumType.Normarl;
            var allRoleList = RoleInfoService.LoadEntities(r => r.DELFLAG == delFlag).ToList();
            //查询一下要分配角色的用户以前具有了哪些角色编号。
            var allUserRoleIdList = (from r in userInfo.R_USERINFO_ACTIONINFO
                                     select r.ID).ToList();
            ViewBag.AllRoleList = allRoleList;
            ViewBag.AllUserRoleIdList = allUserRoleIdList;
            return View();
        }

        #endregion

        #region 展示用户权限
        public ActionResult ShowUserAction()
        {
            int userId = int.Parse(Request["userId"]);
            var userInfo = UserInfoService.LoadEntities(u => u.ID == userId).FirstOrDefault();
            ViewBag.UserInfo = userInfo;
            //获取所有的权限。
            short delFlag = (short)DeleteEnumType.Normarl;
            var allActionList = ActionInfoService.LoadEntities(a => a.DELFLAG == delFlag).ToList();
            //获取要分配的用户已经有的权限。
            var allActionIdList = (from a in userInfo.R_USERINFO_ACTIONINFO
                                   select a).ToList();
            ViewBag.AllActionList = allActionList;
            ViewBag.AllActionIdList = allActionIdList;
            return View();
        }
        #endregion

        #region 完成用户权限的分配
        public ActionResult SetUserAction()
        {
            int actionId = int.Parse(Request["actionId"]);
            int userId = int.Parse(Request["userId"]);
            int isPass = Request["isPass"] == "true" ? 1 : 0;
            if (UserInfoService.SetUserActionInfo(actionId, userId, isPass))
            {
                return Content("ok");
            }
            else
            {
                return Content("no");
            }
        }
        #endregion

        #region 完成权限删除
        public ActionResult ClearUserAction()
        {
            int actionId = int.Parse(Request["actionId"]);
            int userId = int.Parse(Request["userId"]);
            var r_userInfo_actionInfo = R_UserInfo_ActionInfoService.LoadEntities(r => r.ACTIONINFOID == actionId && r.USERINFOID == userId).FirstOrDefault();
            if (r_userInfo_actionInfo != null)
            {
                if (R_UserInfo_ActionInfoService.DeleteEntity(r_userInfo_actionInfo))
                {
                    return Content("ok:删除成功!!");
                }
                else
                {
                    return Content("ok:删除失败!!");
                }
            }
            else
            {
                return Content("no:数据不存在!!");
            }

        }
        #endregion
    }
}