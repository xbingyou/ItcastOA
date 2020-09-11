 
using CZBK.ItcastOA.IBLL;
using CZBK.ItcastOA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CZBK.ItcastOA.BLL
{
	
	public partial class ActioninfoService :BaseService<ACTIONINFO>,IActioninfoService
    {
    

		 public override void SetCurrentDal()
        {
            CurrentDal = this.CurrentDBSession.ActioninfoDal;
        }
    }   
	
	public partial class DepartmentService :BaseService<DEPARTMENT>,IDepartmentService
    {
    

		 public override void SetCurrentDal()
        {
            CurrentDal = this.CurrentDBSession.DepartmentDal;
        }
    }   
	
	public partial class R_userinfo_actioninfoService :BaseService<R_USERINFO_ACTIONINFO>,IR_userinfo_actioninfoService
    {
    

		 public override void SetCurrentDal()
        {
            CurrentDal = this.CurrentDBSession.R_userinfo_actioninfoDal;
        }
    }   
	
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