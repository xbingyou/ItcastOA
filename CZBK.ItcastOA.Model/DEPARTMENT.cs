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
    
    public partial class DEPARTMENT
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DEPARTMENT()
        {
            this.R_DEPARTMENT_ACTIONINFO = new HashSet<R_DEPARTMENT_ACTIONINFO>();
            this.R_USERINFO_DEPARTMENT = new HashSet<R_USERINFO_DEPARTMENT>();
        }
    
        public decimal ID { get; set; }
        public string DEPNAME { get; set; }
        public Nullable<decimal> PARENTID { get; set; }
        public string TREEPATH { get; set; }
        public Nullable<decimal> LEVELN { get; set; }
        public Nullable<decimal> ISLEAF { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
    	[Newtonsoft.Json.JsonIgnore]
        public virtual ICollection<R_DEPARTMENT_ACTIONINFO> R_DEPARTMENT_ACTIONINFO { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
    	[Newtonsoft.Json.JsonIgnore]
        public virtual ICollection<R_USERINFO_DEPARTMENT> R_USERINFO_DEPARTMENT { get; set; }
    }
}