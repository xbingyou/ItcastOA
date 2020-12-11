using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CZBK.ItcastOA.Common.BaseValidator
{
    public class DoubleValidator : BaseValidator, IBaseValidator
    {
        // 只能是正数
        private bool _IsPositiveNumber = false;

        public DoubleValidator()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }


        #region IBaseValidation 成员

        public bool IsValid(object objValue)
        {
            // 如果是null，则验证通过
            if (objValue == null || objValue == System.DBNull.Value || objValue.ToString() == "")
            {
                if (_IsCanNull == false)
                {
                    _strMessage = "不能为空！";
                    _intValidationCode = BaseValidationCode.VALIDATION_CODE_FAIL;
                }
                else
                {
                    _strMessage = "数据校验通过！";
                }
                return _IsCanNull;
            }


            // 把数据转换成字符串
            string strValue = objValue.ToString();

            // 设置正则表达式对象实例
            string strPattern = "^(-?\\d+)(\\.\\d+)?$";
            _strMessage = "必须是数字！";

            // 非负数
            if (_IsPositiveNumber)
            {
                strPattern = "^\\d+(\\.\\d+)?$";
                _strMessage = "必须是非负数！";
            }
            Regex regex = new Regex(strPattern, RegexOptions.IgnoreCase);

            bool bRet = regex.IsMatch(strValue);
            if (bRet == true)
            {
                try
                {
                    this._objValidatedValue = System.Double.Parse(strValue);
                }
                catch (Exception ex)
                {
                    _strMessage = "必须是数字！（请注意全角半角）";
                    Console.WriteLine(_strMessage+ex.Message);
                    return false;
                }
                _strMessage = "数据校验通过！";
            }
            else
            {
                _intValidationCode = BaseValidationCode.VALIDATION_CODE_FAIL;
            }
            return bRet;
        }
        #endregion

        /// <summary>
        /// 非负数
        /// </summary>
        public bool IsPositiveNumber
        {
            set
            {
                _IsPositiveNumber = value;
            }
            get
            {
                return _IsPositiveNumber;
            }
        }

    }
}
