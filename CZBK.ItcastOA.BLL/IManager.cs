 
using CZBK.ItcastOA.IBLL;
using CZBK.ItcastOA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CZBK.ItcastOA.BLL
{
	
	public partial class RoleinfoService :BaseService<ROLEINFO>,IRoleinfoService
    {
    

		 public override void SetCurrentDal()
        {
            CurrentDal = this.CurrentDBSession.RoleinfoDal;
        }
    }   
	
	public partial class UserinfoService :BaseService<USERINFO>,IUserinfoService
    {
    

		 public override void SetCurrentDal()
        {
            CurrentDal = this.CurrentDBSession.UserinfoDal;
        }
    }   
	
}