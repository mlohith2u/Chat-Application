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
    
    public partial class CourseImage
    {
        public int ID { get; set; }
        public Nullable<int> CourseID { get; set; }
        public string CourseName { get; set; }
        public byte[] CourseIcons { get; set; }
    }
}
