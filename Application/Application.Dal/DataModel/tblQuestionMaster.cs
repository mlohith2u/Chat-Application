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
    
    public partial class tblQuestionMaster
    {
        public int ID { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
        public Nullable<int> Domain { get; set; }
        public Nullable<int> Technology { get; set; }
        public Nullable<int> Chapter { get; set; }
        public Nullable<int> Course { get; set; }
        public bool IsEnabled { get; set; }
        public int LevelID { get; set; }
        public Nullable<int> ExamLevel { get; set; }
    }
}
