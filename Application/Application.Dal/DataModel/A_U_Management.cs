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
    
    public partial class A_U_Management
    {
        public int UserUID { get; set; }
        public string StudentId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public Nullable<System.DateTime> DateofBirth { get; set; }
        public Nullable<int> Qualification { get; set; }
        public Nullable<int> Occupation { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public Nullable<int> UserRole { get; set; }
        public bool IsActive { get; set; }
        public Nullable<System.DateTime> LastUpdated { get; set; }
    }
}
