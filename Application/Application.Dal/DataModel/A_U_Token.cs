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
    
    public partial class A_U_Token
    {
        public string ID { get; set; }
        public string Subject { get; set; }
        public string ClientId { get; set; }
        public Nullable<System.DateTime> IssuedUTC { get; set; }
        public Nullable<System.DateTime> ExpireUTC { get; set; }
        public string ProtectedTicket { get; set; }
    }
}
