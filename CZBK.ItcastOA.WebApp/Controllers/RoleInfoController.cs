using CZBK.ItcastOA.Model;
using CZBK.ItcastOA.Model.EnumType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CZBK.ItcastOA.WebApp.Controllers
{
    public class RoleInfoController : BaseController
    {
        IBLL.IRoleinfoService RoleInfoService { get; set; }
        // GET: RoleInfo
        public ActionResult Index()
        {
            return View();
        }

        #region 获取角色列表
        public ActionResult GetRoleInfoList()
        {
            int pageIndex = Request["page"] != null ? int.Parse(Request["page"]) : 1;
            int pageSize = Request["rows"] != null ? int.Parse(Request["rows"]) : 5;
            int totalCount;
            short delFlag = (short)DeleteEnumType.Normarl;
            var roleInfoList = RoleInfoService.LoadPageEntities(pageIndex, pageSize, out totalCount,
                c => c.DELFLAG == delFlag, c => c.ID, true);
            var temp = from r in roleInfoList
                       select new
                       {
                           ID = r.ID,
                           ROLENAME = r.ROLENAME,
                           SORT = r.SORT,
                           REMARK = r.REMARK,
                           SUBTIME = r.SUBTIME
                       };
            return Json(new { rows = temp, total = totalCount, }, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region 展示添加表单
        public ActionResult ShowAddInfo()
        {
            return View();
        }
        #endregion


        #region 完成角色信息添加
        public ActionResult AddRoleInfo(ROLEINFO roleInfo)
        {
            roleInfo.MODIFIEDON = DateTime.Now;
            roleInfo.SUBTIME = DateTime.Now;
            roleInfo.DELFLAG = 0;
            RoleInfoService.AddEntity(roleInfo);
            return Content("ok");
        }
        #endregion
    }
}