using Application.Dal.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Application.Api.App.modules.PayuControllers
{
    public class Upay
    {
        public RemotePostvm PayAmount(PayUPaymentViewModel datafromView)
        {
            ChatAppEntities db = new ChatAppEntities();
            bool result = true;
            RemotePost myremotepost = new RemotePost();
            string txnid = myremotepost.Generatetxnid();
            if (result)
            {
                string key = "s4JBRM";
                string salt = "pETBFUBR";
                //posting all the parameters required for integration.
                //posting all the parameters required for integration.
                //string _amount = Convert.ToString(viewModel.CartTotal);
                myremotepost.Url = "https://secure.payu.in/_payment";
                myremotepost.Add("key", "s4JBRM");
                myremotepost.Add("txnid", txnid);
                myremotepost.Add("amount", datafromView.Amount);
                myremotepost.Add("productinfo", datafromView.DesBusiness);
                myremotepost.Add("firstname", datafromView.Fname);
                myremotepost.Add("phone", datafromView.Mobileno);
                myremotepost.Add("email", datafromView.Email);
                myremotepost.Add("surl", "http://localhost/academy/#/success");//Change the success url here depending upon the port number of your local system.
                myremotepost.Add("furl", "http://localhost/academy/#/success");//Change the failure url here depending upon the port number of your local system.
                myremotepost.Add("service_provider", "payu_paisa");
                string hashString = key + "|" + txnid + "|" + datafromView.Amount + "|" + datafromView.DesBusiness + "|" + datafromView.Fname + "|" + datafromView.Email + "|||||||||||" + salt;
                //string hashString = "3Q5c3q|2590640|3053.00|OnlineBooking|vimallad|ladvimal@gmail.com|||||||||||mE2RxRwx";
                string hash = myremotepost.Generatehash512(hashString);
                myremotepost.Add("hash", hash);

                TransactionTable tt = new TransactionTable();

                //tt.Amount = Convert.ToDecimal(datafromView.Amount);
                tt.Hash = hash;
                tt.TransactionId = txnid;
                tt.Date = DateTime.Now;
                //tt.CourseId = datafromView.OrderId;
                //tt.StudentId = datafromView.s;
                db.TransactionTables.Add(tt);
                db.SaveChanges();                
            }

            RemotePostvm vm = new RemotePostvm();
            vm.FormName = myremotepost.FormName;
            vm.Url = myremotepost.Url;
            vm.Method = myremotepost.Method;
            vm.valpair = myremotepost.dvo;

            return vm;
        }
    }
}