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
    
    public partial class land_demand
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public land_demand()
        {
            this.live_demand = new HashSet<live_demand>();
        }
    
        public int Id { get; set; }
        public Nullable<int> demand_Id { get; set; }
        public Nullable<double> MinArea { get; set; }
        public Nullable<double> MaxArea { get; set; }
    
        public virtual demand demand { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<live_demand> live_demand { get; set; }
    }
}
