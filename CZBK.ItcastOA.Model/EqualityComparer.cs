using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CZBK.ItcastOA.Model
{
    public class EqualityComparer : IEqualityComparer<ACTIONINFO>
    {
        public bool Equals(ACTIONINFO x, ACTIONINFO y)
        {
            return x.ID == y.ID;
        }

        public int GetHashCode(ACTIONINFO obj)
        {
            return obj.GetHashCode();
        }
    }
}
