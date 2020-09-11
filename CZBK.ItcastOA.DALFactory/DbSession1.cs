 
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
	
		private IActioninfoDal _ActioninfoDal;
        public IActioninfoDal ActioninfoDal
        {
            get
            {
                if(_ActioninfoDal == null)
                {
                    _ActioninfoDal = AbstractFactory.CreateActioninfoDal();
                }
                return _ActioninfoDal;
            }
            set { _ActioninfoDal = value; }
        }
	
		private IDepartmentDal _DepartmentDal;
        public IDepartmentDal DepartmentDal
        {
            get
            {
                if(_DepartmentDal == null)
                {
                    _DepartmentDal = AbstractFactory.CreateDepartmentDal();
                }
                return _DepartmentDal;
            }
            set { _DepartmentDal = value; }
        }
	
		private IR_userinfo_actioninfoDal _R_userinfo_actioninfoDal;
        public IR_userinfo_actioninfoDal R_userinfo_actioninfoDal
        {
            get
            {
                if(_R_userinfo_actioninfoDal == null)
                {
                    _R_userinfo_actioninfoDal = AbstractFactory.CreateR_userinfo_actioninfoDal();
                }
                return _R_userinfo_actioninfoDal;
            }
            set { _R_userinfo_actioninfoDal = value; }
        }
	
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