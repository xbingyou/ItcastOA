﻿ 

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

	
		IRoleinfoDal RoleinfoDal{get;set;}
	
		IUserinfoDal UserinfoDal{get;set;}
	}	
}