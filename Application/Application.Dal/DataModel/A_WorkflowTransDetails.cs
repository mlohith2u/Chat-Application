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
    
    public partial class A_WorkflowTransDetails
    {
        public int ID { get; set; }
        public int WTM_MasID { get; set; }
        public Nullable<int> WTD_TransID { get; set; }
        public string WTD_InwardFileNo { get; set; }
        public Nullable<System.DateTime> WTD_TransDate { get; set; }
        public Nullable<int> WTD_TransFrom { get; set; }
        public string WTD_To { get; set; }
        public string WTD_Remarks { get; set; }
        public Nullable<int> WTD_WFStatsID { get; set; }
        public Nullable<int> WTD_WFActionID { get; set; }
        public Nullable<int> WTD_SentBy { get; set; }
        public string WTD_WFStatus { get; set; }
        public Nullable<int> WTD_SentOn { get; set; }
    }
}
