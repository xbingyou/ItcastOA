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
    }
}
