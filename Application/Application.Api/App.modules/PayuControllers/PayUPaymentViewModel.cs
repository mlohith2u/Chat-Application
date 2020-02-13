using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Application.Api.App.modules.PayuControllers
{
    public class PayUPaymentViewModel
    {
        public string Fname { get; set; }
        public string Lname { get; set; }
        public string Email { get; set; }
        public string Mobileno { get; set; }
        public string Amount { get; set; }
        public string DesBusiness { get; set; }
        public string OrderId { get; set; }
        public string CustomerId { get; set; }
    }
}