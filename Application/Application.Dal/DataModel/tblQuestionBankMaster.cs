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
    
    public partial class tblQuestionBankMaster
    {
        public int ID { get; set; }
        public Nullable<int> Domain { get; set; }
        public Nullable<int> Technology { get; set; }
        public Nullable<int> Course { get; set; }
        public string QuestionBankName { get; set; }
        public string Description { get; set; }
        public string Version { get; set; }
        public bool IsEnabled { get; set; }
        public string Question { get; set; }
    }
}