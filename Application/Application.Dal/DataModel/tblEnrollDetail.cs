//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Application.Dal.DataModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblEnrollDetail
    {
        public int ID { get; set; }
        public string USNNumber { get; set; }
        public Nullable<int> Domain { get; set; }
        public Nullable<int> Technology { get; set; }
        public Nullable<int> Course { get; set; }
        public Nullable<int> Duration { get; set; }
        public Nullable<int> Price { get; set; }
        public Nullable<int> StudentID { get; set; }
        public bool IsPaid { get; set; }
        public Nullable<System.DateTime> StartedOn { get; set; }
        public bool IsDefault { get; set; }
    }
}
