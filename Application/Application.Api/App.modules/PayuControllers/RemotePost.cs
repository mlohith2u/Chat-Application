using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace Application.Api.App.modules.PayuControllers
{
    public class RemotePost
    {
        public NameValueCollection Inputs = new NameValueCollection();

        public List<DataViewObj> dvo = new List<DataViewObj>();

        public string Url = "https://secure.payu.in/_payment";
        public string Method = "post";
        public string FormName = "form1";
        public RemotePost Inputss { get; set; }
        public void Add(string name, string value)
        {
            Inputs.Add(name, value);
            DataViewObj obje = new DataViewObj();
            obje.name = name;
            obje.value = value;
            dvo.Add(obje);
        }
        public void Post()
        {

            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.Write("<html><head>");
            HttpContext.Current.Response.Write(string.Format("</head><body onload=\"document.{0}.submit()\">", FormName));
            HttpContext.Current.Response.Write(string.Format("<form name=\"{0}\" method=\"{1}\" action=\"{2}\" >", FormName, Method, Url));
            for (int i = 0; i < Inputs.Keys.Count; i++)
            {
                System.Web.HttpContext.Current.Response.Write(string.Format("<input name=\"{0}\" type=\"hidden\" value=\"{1}\">", HttpUtility.HtmlEncode(Inputs.Keys[i]), HttpUtility.HtmlEncode(Inputs[Inputs.Keys[i]])));
            }
            HttpContext.Current.Response.Write("</form>");
            HttpContext.Current.Response.Write("</body></html>");

            HttpContext.Current.Response.End();

        }
        //Hash generation Algorithm
        public string Generatehash512(string text)
        {
            byte[] message = Encoding.UTF8.GetBytes(text);
            UnicodeEncoding UE = new UnicodeEncoding();
            byte[] hashValue;
            SHA512Managed hashString = new SHA512Managed();
            string hex = "";
            hashValue = hashString.ComputeHash(message);
            foreach (byte x in hashValue)
            {
                hex += String.Format("{0:x2}", x);
            }
            return hex;
        }
        public string Generatetxnid()
        {

            Random rnd = new Random();
            string strHash = Generatehash512(rnd.ToString() + DateTime.Now);
            string txnid1 = strHash.ToString().Substring(0, 20);

            return txnid1;
        }

        public NameValueCollection GetNameValuePair()
        {
            return Inputs;
        }
    }
}