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
    
    public partial class A_WorkflowTransMailBoxes
    {
        public int ID { get; set; }
        public decimal WTM_MasID { get; set; }
        public Nullable<decimal> WTM_TransID { get; set; }
        public string WTM_InwardFileNo { get; set; }
        public Nullable<decimal> WTM_TrnFrom { get; set; }
        public Nullable<decimal> WTM_TrnTo { get; set; }
        public string WTM_UsrOrGrp { get; set; }
        public string WTM_ReadFlg { get; set; }
        public string WTM_TrnStatus { get; set; }
    }
}