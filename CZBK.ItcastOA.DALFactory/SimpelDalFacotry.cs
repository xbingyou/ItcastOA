 

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