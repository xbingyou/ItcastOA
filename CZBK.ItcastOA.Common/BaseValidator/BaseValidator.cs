using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CZBK.ItcastOA.Common.BaseValidator
{
    /// <summary>
	/// BaseValidator 的摘要说明。
	/// </summary>
	public class BaseValidator
    {
        // 可以为空
        protected bool _IsCanNull = true;

        // Message
        protected string _strMessage = "";

        /// <summary>
        /// 编码
        /// </summary>
        protected int _intValidationCode = BaseValidationCode.VALIDATION_CODE_SUCCESS;

        /// <summary>
        /// 校验后返回的值
        /// </summary>
        protected object _objValidatedValue = null;

        // 检测失败时的错误信息
        private string _strInValidMessage = null;

        public BaseValidator()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }

        /// <summary>
        /// 获得返回值
        /// </summary>
        /// <returns></returns>
        virtual public object GetValidatedValue()
        {
            return _objValidatedValue;
        }

        /// <summary>
        /// 获得返回描述
        /// </summary>
        /// <returns></returns>
        virtual public string GetMessage()
        {
            return _strMessage;
        }

        /// <summary>
        /// 获得返回自定义码
        /// </summary>
        /// <returns></returns>
        virtual public int GetValidationCode()
        {
            return _intValidationCode;
        }

        /// <summary>
        /// 允许为空
        /// </summary>
        public bool IsCanNull
        {
            set
            {
                _IsCanNull = value;
            }
            get
            {
                return _IsCanNull;
            }
        }

        /// <summary>
        /// 校验失败时的信息
        /// </summary>
        public string InValideMessage
        {
            set
            {
                this._strInValidMessage = value;
            }
            get
            {
                return this._strInValidMessage;
            }
        }
    }
}
