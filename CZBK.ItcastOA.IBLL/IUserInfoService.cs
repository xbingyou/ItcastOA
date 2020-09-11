using CZBK.ItcastOA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CZBK.ItcastOA.IBLL
{
    public partial interface IUserinfoService:IBaseService<USERINFO>
    {
        bool DeleteEntities(List<decimal> list);
        bool SetUserActionInfo(int actionId, int userId, int isPass);
    }
}
