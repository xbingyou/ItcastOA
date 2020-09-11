 

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CZBK.ItcastOA.IDAL
{
	public partial interface IDBSession
    {

	
		IActioninfoDal ActioninfoDal{get;set;}
	
		IDepartmentDal DepartmentDal{get;set;}
	
		IR_userinfo_actioninfoDal R_userinfo_actioninfoDal{get;set;}
	
		IRoleinfoDal RoleinfoDal{get;set;}
	
		IUserinfoDal UserinfoDal{get;set;}
	}	
}