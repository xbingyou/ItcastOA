using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CZBK.ItcastOA.IBLL;
using CZBK.ItcastOA.Model;
using CZBK.ItcastOA.Model.EnumType;

namespace CZBK.ItcastOA.BLL
{
    public partial class UserinfoService : BaseService<USERINFO>, IUserinfoService
    {
        //public override void SetCurrentDal()
        //{
        //    CurrentDal = this.CurrentDBSession.UserInfoDal;
        //}
        //public void SetUserInfo(USERINFO userInfo)
        //{
        //    this.CurrentDBSession.UserInfoDal.AddEntity(userInfo);
        //    this.CurrentDBSession.UserInfoDal.DeleteEntity(userInfo);
        //    this.CurrentDBSession.UserInfoDal.EditEntity(userInfo);
        //    this.CurrentDBSession.SaveChanges();
        //}
        /// <summary>
        /// 批量删除多条用户数据
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public bool DeleteEntities(List<decimal> list)
        {
            var userInfoList = this.CurrentDBSession.UserInfoDal.LoadEntities(u => list.Contains(u.ID));
            foreach (var userInfo in userInfoList)
            {
                this.CurrentDBSession.UserInfoDal.DeleteEntity(userInfo);
            }
            return this.CurrentDBSession.SaveChanges();
        }
        /// <summary>
        /// 完成用户权限的分配
        /// </summary>
        /// <param name="actionId"></param>
        /// <param name="userId"></param>
        /// <param name="isPass"></param>
        /// <returns></returns>
        public bool SetUserActionInfo(int actionId, int userId, int isPass)
        {
            //判断userId以前是否有了该actionId，如果有了只需要更改isPass状态，否则插入
            var r_userinfo_actioninfo = this.CurrentDBSession.R_userinfo_actioninfoDal.LoadEntities(
                a => a.ACTIONINFOID == actionId && a.USERINFOID == userId).FirstOrDefault();
            if (r_userinfo_actioninfo == null)
            {
                R_USERINFO_ACTIONINFO userInfoActionInfo = new R_USERINFO_ACTIONINFO();
                userInfoActionInfo.ACTIONINFOID = actionId;
                userInfoActionInfo.USERINFOID = userId;
                userInfoActionInfo.ISPASS = isPass;
                this.CurrentDBSession.R_userinfo_actioninfoDal.AddEntity(userInfoActionInfo);
            }
            else
            {
                r_userinfo_actioninfo.ISPASS = isPass;
                this.CurrentDBSession.R_userinfo_actioninfoDal.EditEntity(r_userinfo_actioninfo);
            }
            return this.CurrentDBSession.SaveChanges();
        }
    }
}
