//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RealEstate
{
    using System;
    using System.Collections.Generic;
    
    public partial class supply
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public supply()
        {
            this.deals = new HashSet<deal>();
        }
    
        public int Id { get; set; }
        public Nullable<decimal> Price { get; set; }
        public Nullable<int> AgentId { get; set; }
        public Nullable<int> ClientId { get; set; }
        public Nullable<int> RealEstateId { get; set; }
    
        public virtual agent agent { get; set; }
        public virtual client client { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<deal> deals { get; set; }
        public virtual land land { get; set; }
    }
}
