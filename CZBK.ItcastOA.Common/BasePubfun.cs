using CZBK.ItcastOA.Common.BaseValidator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CZBK.ItcastOA.Common
{
    public class BasePubfun
    {
        public static int ConvertToInt32(object objValue, params int[] lstDefautValue)
        {
            int nDefault = 0;
            if (lstDefautValue.Length > 0)
            {
                nDefault = lstDefautValue[0];
            }

            if (objValue == System.DBNull.Value || objValue == null)
            {
                return nDefault;
            }

            string strValue = Convert.ToString(objValue);
            strValue = strValue.Replace("+", "");

            DoubleValidator val = new DoubleValidator();
            val.IsCanNull = false;
            if (val.IsValid(strValue) == false)
            {
                return nDefault;
            }

            double dValue = Math.Round(Convert.ToDouble(strValue), 0); // 四舍六入五成双
            Int64 nLong = Convert.ToInt64(dValue);
            int nRet = nDefault;
            if (nLong > Int32.MaxValue)
            {
                nRet = Convert.ToInt32(Int32.MaxValue - nLong);
            }
            else
            {
                nRet = Convert.ToInt32(nLong);
            }
            return nRet;
        }

        public static Int64 ConvertToInt64(object objValue, params Int64[] lstDefautValue)
        {
            Int64 nDefault = 0;
            if (lstDefautValue.Length > 0)
            {
                nDefault = lstDefautValue[0];
            }

            if (objValue == System.DBNull.Value)
            {
                return nDefault;
            }

            string strValue = Convert.ToString(objValue);
            strValue = strValue.Replace("+", "");

            DoubleValidator val = new DoubleValidator();
            val.IsCanNull = false;
            if (val.IsValid(strValue) == false)
            {
                return nDefault;
            }

            Int64 nRight = 0;
            Int64 nValue = 0;
            if (strValue.IndexOf(".") > 0)
            {
                nRight = Convert.ToInt64(Math.Round(Convert.ToDouble(strValue.Substring(strValue.IndexOf(".") - 1)), 0)); // 四舍六入五成双
                nValue = Convert.ToInt64(strValue.Substring(0, strValue.IndexOf(".") - 1) + "0") + nRight;
            }
            else
            {
                nValue = Convert.ToInt64(strValue);
            }
            return nValue;
        }
    }
}
