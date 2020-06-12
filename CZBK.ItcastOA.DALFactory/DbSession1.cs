 
using CZBK.ItcastOA.DAL;
using CZBK.ItcastOA.IDAL;
using CZBK.ItcastOA.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CZBK.ItcastOA.DALFactory
{
	public partial class DBSession : IDBSession
    {
	
		private IRoleinfoDal _RoleinfoDal;
        public IRoleinfoDal RoleinfoDal
        {
            get
            {
                if(_RoleinfoDal == null)
                {
                    _RoleinfoDal = AbstractFactory.CreateRoleinfoDal();
                }
                return _RoleinfoDal;
            }
            set { _RoleinfoDal = value; }
        }
	
		private IUserinfoDal _UserinfoDal;
        public IUserinfoDal UserinfoDal
        {
            get
            {
                if(_UserinfoDal == null)
                {
                    _UserinfoDal = AbstractFactory.CreateUserinfoDal();
                }
                return _UserinfoDal;
            }
            set { _UserinfoDal = value; }
        }
	}	
}