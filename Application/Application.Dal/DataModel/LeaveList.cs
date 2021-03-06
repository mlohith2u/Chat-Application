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
    
    public partial class LeaveList
    {
        public int LeaveConditionID { get; set; }
        public Nullable<int> EmpID { get; set; }
        public Nullable<int> LeaveTypeID { get; set; }
        public string LeaveCredited { get; set; }
        public string LeaveDebited { get; set; }
        public string BalanceRemaining { get; set; }
        public string BasicPayOnLeave { get; set; }
        public string LeaveEncashed { get; set; }
        public Nullable<System.DateTime> LeaveStartingDate { get; set; }
        public Nullable<System.DateTime> LeaveEndingDate { get; set; }
        public string AdvanceCredit { get; set; }
        public string SalaryDeductionInPercentage { get; set; }
        public string SalaryDeductionInRupees { get; set; }
        public string MinLeave { get; set; }
        public string MaxLeave { get; set; }
        public string Reason { get; set; }
    
        public virtual LeaveMaster LeaveMaster { get; set; }
    }
}
