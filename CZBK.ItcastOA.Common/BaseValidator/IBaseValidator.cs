using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CZBK.ItcastOA.Common.BaseValidator
{
    /// <summary>
    /// 校验类接口
    /// </summary>
    public interface IBaseValidator
    {

        // 验证数据
        bool IsValid(object objValue);

        // 获取经验证器转换后的值(例如日期)
        object GetValidatedValue();

        // 获取验证结果信息
        string GetMessage();

        // 获取校验结果编码
        int GetValidationCode();
    }
}
