//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace CZBK.ItcastOA.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class R_USERINFO_ROLEINFO
    {
        public decimal ID { get; set; }
        public Nullable<decimal> USERINFOID { get; set; }
        public Nullable<decimal> ROLEINFOID { get; set; }
    
        public virtual ROLEINFO ROLEINFO { get; set; }
        public virtual USERINFO USERINFO { get; set; }
    }
}
