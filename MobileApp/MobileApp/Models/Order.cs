//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MobileApp.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Order
    {
        public System.Guid Id { get; set; }
        public Nullable<System.Guid> userId { get; set; }
        public string Address { get; set; }
        public Nullable<System.DateTime> OrderDate { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
        public Nullable<System.Guid> CreatedBy { get; set; }
        public Nullable<System.Guid> UpdatedBy { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
        public string OrderStatus { get; set; }
    }
}
