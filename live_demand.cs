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
    
    public partial class live_demand
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public live_demand()
        {
            this.MinFloor = 0;
            this.MaxFloor = 0;
            this.MinRoom = 0;
            this.MaxRoom = 0;
        }
    
        public int Id { get; set; }
        public Nullable<int> landDemandId { get; set; }
        public Nullable<int> MinFloor { get; set; }
        public Nullable<int> MaxFloor { get; set; }
        public Nullable<int> MinRoom { get; set; }
        public Nullable<int> MaxRoom { get; set; }
    
        public virtual land_demand land_demand { get; set; }
    }
}
