using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Http;
using static Application.Api.App.modules.Controllers.CustomerRegistrationsController;

namespace Application.Api.App.modules.Controllers
{
    public class SendEmailMobileotpController : ApiController
    {
        public static void SendSMS(CustomerViewModel custom, string motp)
        {
            //Your authentication key
            string authKey = "15406AN4p5ZIRBZ59ede653";
            //Multiple mobiles numbers separated by comma
            string mobileNumber = custom.MobileNumber;
            //Sender ID,While using route4 sender id should be 6 characters long.
            string senderId = "611332";
            //Your message to send, Add URL encoding here.
            string messages = "Hello " + custom.CustomerName + " Mobile OTP:" + motp + "";
            string message = HttpUtility.UrlEncode(messages);

            //Prepare you post parameters
            StringBuilder sbPostData = new StringBuilder();
            sbPostData.AppendFormat("authkey={0}", authKey);
            sbPostData.AppendFormat("&mobiles={0}", mobileNumber);
            sbPostData.AppendFormat("&message={0}", message);
            sbPostData.AppendFormat("&sender={0}", senderId);
            sbPostData.AppendFormat("&route={0}", "default");

            try
            {
                //Call Send SMS API
                string sendSMSUri = "http://sms.ssdindia.com/api/sendhttp.php";
                //Create HTTPWebrequest
                HttpWebRequest httpWReq = (HttpWebRequest)WebRequest.Create(sendSMSUri);
                //Prepare and Add URL Encoded data
                UTF8Encoding encoding = new UTF8Encoding();
                byte[] data = encoding.GetBytes(sbPostData.ToString());
                //Specify post method
                httpWReq.Method = "POST";
                httpWReq.ContentType = "application/x-www-form-urlencoded";
                httpWReq.ContentLength = data.Length;
                using (Stream stream = httpWReq.GetRequestStream())
                {
                    stream.Write(data, 0, data.Length);
                }
                //Get the response
                HttpWebResponse response = (HttpWebResponse)httpWReq.GetResponse();
                StreamReader reader = new StreamReader(response.GetResponseStream());
                string responseString = reader.ReadToEnd();

                //Close the response
                reader.Close();
                response.Close();
            }
            catch (SystemException ex)
            {
                // MessageBox.Show(ex.Message.ToString());
            }

        }

    }
}
