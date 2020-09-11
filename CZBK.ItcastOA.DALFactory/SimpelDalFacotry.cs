 

using CZBK.ItcastOA.IDAL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CZBK.ItcastOA.DALFactory
{
    public partial class AbstractFactory
    {

		
	    public static IActioninfoDal CreateActioninfoDal()
        {
		 string fullClassName = NameSpace + ".ActioninfoDal";
          return CreateInstance(fullClassName) as IActioninfoDal;
        }
		
	    public static IDepartmentDal CreateDepartmentDal()
        {
		 string fullClassName = NameSpace + ".DepartmentDal";
          return CreateInstance(fullClassName) as IDepartmentDal;
        }
		
	    public static IR_userinfo_actioninfoDal CreateR_userinfo_actioninfoDal()
        {
		 string fullClassName = NameSpace + ".R_userinfo_actioninfoDal";
          return CreateInstance(fullClassName) as IR_userinfo_actioninfoDal;
        }
		
	    public static IRoleinfoDal CreateRoleinfoDal()
        {
		 string fullClassName = NameSpace + ".RoleinfoDal";
          return CreateInstance(fullClassName) as IRoleinfoDal;
        }
		
	    public static IUserinfoDal CreateUserinfoDal()
        {
		 string fullClassName = NameSpace + ".UserinfoDal";
          return CreateInstance(fullClassName) as IUserinfoDal;
        }
	}
	
}