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
    
    public partial class Proc_WorkFLow_Get_SentMail_Result
    {
        public int WTM_MasID { get; set; }
        public Nullable<int> WTD_TransID { get; set; }
        public Nullable<System.DateTime> WTD_TransDate { get; set; }
        public Nullable<int> WTD_SentOn { get; set; }
        public Nullable<int> WTD_TransFrom { get; set; }
        public string WTD_To { get; set; }
        public string WTD_Remarks { get; set; }
        public Nullable<int> WTD_WFStatsID { get; set; }
        public Nullable<int> WTD_WFActionID { get; set; }
        public Nullable<int> WTD_SentBy { get; set; }
        public string WTD_WFStatus { get; set; }
        public string FullName { get; set; }
        public string WTM_Subject { get; set; }
        public Nullable<int> WTM_WorkFlowID { get; set; }
        public Nullable<int> WTM_DOCID { get; set; }
        public string WTM_ReadFlg { get; set; }
        public string WTM_TrnStatus { get; set; }
        public string WTM_FormCode { get; set; }
    }
}
