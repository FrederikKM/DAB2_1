//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAB2_2.Lib
{
    using System;
    using System.Collections.Generic;
    
    public partial class TelephoneCompany
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TelephoneCompany()
        {
            this.TelephoneNumbers = new HashSet<TelephoneNumber>();
        }
    
        public int TelephoneCompanyId { get; set; }
        public string Company { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TelephoneNumber> TelephoneNumbers { get; set; }
    }
}
