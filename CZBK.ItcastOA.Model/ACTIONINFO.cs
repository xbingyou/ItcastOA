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
    
    public partial class ACTIONINFO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ACTIONINFO()
        {
            this.R_DEPARTMENT_ACTIONINFO = new HashSet<R_DEPARTMENT_ACTIONINFO>();
            this.R_ROLEINFO_ACTIONINFO = new HashSet<R_ROLEINFO_ACTIONINFO>();
            this.R_USERINFO_ACTIONINFO = new HashSet<R_USERINFO_ACTIONINFO>();
        }
    
        public decimal ID { get; set; }
        public Nullable<System.DateTime> SUBTIME { get; set; }
        public Nullable<decimal> DELFLAG { get; set; }
        public string MODIFIEDON { get; set; }
        public string REMARK { get; set; }
        public string URL { get; set; }
        public string HTTPMETHOD { get; set; }
        public string ACTIONMETHODNAME { get; set; }
        public string CONTROLLERNAME { get; set; }
        public string ACTIONINFONAME { get; set; }
        public string SORT { get; set; }
        public Nullable<decimal> ACTIONTYPEENUM { get; set; }
        public string MENUICON { get; set; }
        public Nullable<decimal> ICONWIDTH { get; set; }
        public Nullable<decimal> ICONHEIGHT { get; set; }
        public Nullable<decimal> BELONGMENU { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
    	[Newtonsoft.Json.JsonIgnore]
        public virtual ICollection<R_DEPARTMENT_ACTIONINFO> R_DEPARTMENT_ACTIONINFO { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
    	[Newtonsoft.Json.JsonIgnore]
        public virtual ICollection<R_ROLEINFO_ACTIONINFO> R_ROLEINFO_ACTIONINFO { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
    	[Newtonsoft.Json.JsonIgnore]
        public virtual ICollection<R_USERINFO_ACTIONINFO> R_USERINFO_ACTIONINFO { get; set; }
    }
}
