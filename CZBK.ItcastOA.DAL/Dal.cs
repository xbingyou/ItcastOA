 

using CZBK.ItcastOA.IDAL;
using CZBK.ItcastOA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CZBK.ItcastOA.DAL
{
		
	public partial class ActioninfoDal :BaseDal<ACTIONINFO>,IActioninfoDal
    {

    }
		
	public partial class DepartmentDal :BaseDal<DEPARTMENT>,IDepartmentDal
    {

    }
		
	public partial class R_userinfo_actioninfoDal :BaseDal<R_USERINFO_ACTIONINFO>,IR_userinfo_actioninfoDal
    {

    }
		
	public partial class RoleinfoDal :BaseDal<ROLEINFO>,IRoleinfoDal
    {

    }
		
	public partial class UserinfoDal :BaseDal<USERINFO>,IUserinfoDal
    {

    }
	
}