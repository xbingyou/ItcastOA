using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CZBK.ItcastOA.Common.BaseValidator
{
    /// <summary>
	/// 数据校验结果的编码定义。
	/// </summary>
	public class BaseValidationCode
    {
        public BaseValidationCode()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }

        public const int VALIDATION_CODE_SUCCESS = 0; // 校验通过

        public const int VALIDATION_CODE_FAIL = 1; // 校验失败
    }
}
