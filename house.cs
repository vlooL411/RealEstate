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
    
    public partial class house
    {
        public int Id { get; set; }
        public Nullable<int> land_Id { get; set; }
        public double TotalFloors { get; set; }
    
        public virtual land land { get; set; }
    }
}
