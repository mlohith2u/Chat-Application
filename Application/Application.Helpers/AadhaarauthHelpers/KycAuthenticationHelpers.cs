using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Web;
using System.Xml;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Xml.Linq;
using System.Security;
using System.Security.Cryptography.Xml;

namespace Application.Helpers.AadhaarauthHelpers
{
    public class KycAuthenticationHelpers
    {
        public string Work(string aAdhaarNumber, string fullName, string birthYear, string gender, string email, string phoneNumber)
        {
            try
            {
                string xmlns = "http://www.uidai.gov.in/authentication/uid-auth-request/1.0";
                SignXML xmlSign = new SignXML();
                System.Security.Cryptography.AesCryptoServiceProvider crypto = new System.Security.Cryptography.AesCryptoServiceProvider();
                crypto.KeySize = 256;
                crypto.GenerateKey();
                byte[] SessionKey = crypto.Key;
                string ts = DateTime.UtcNow.ToString("s") + "Z";
                string sessionkeyval = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString();
                string datavaluexml = "<Pid ts='" + ts + "' ver='1.0'>";
                datavaluexml = datavaluexml + "<Demo lang=''>";
                datavaluexml = datavaluexml + "<Pi ms='E' mv='100' name='" + fullName + "' lname='' lmv='90' gender='" + gender + "' dob='" + birthYear + "' dobt='' age='' phone='" + phoneNumber + "' email='" + email + "'/>";
                datavaluexml = datavaluexml + "</Demo></Pid>";

                string skeyvalue = EncryptSessionKey(SessionKey);
                string datavalue = EncryptData(datavaluexml, SessionKey);
                string hmacvalue = EncryptDatabyte(GetSHA256(UTF8Encoding.UTF8.GetBytes(datavaluexml)), SessionKey);

                string signKeyStore = @"E:\AGMTEAM\HMS\Application.Web\Application.Helpers\AadhaarauthHelpers\Certificates\Staging_Signature_PrivateKey.p12";

                string xml = "<?xml version='1.0' encoding='utf-8' ?>";
                xml = xml + "<Auth xmlns='" + xmlns + "' uid ='" + aAdhaarNumber + "' tid='public' ac='public' sa='public' ver='1.6' txn='" + sessionkeyval + "' lk='MBFWjkJHNF-fLidl8oOHtUwgL5p1ZjDbWrqsMEVEJLVEDpnlNj_CZTg'>";
                xml = xml + "<Uses pi='y' pa='n' pfa='n' bio='n' bt='' pin='n' otp='n'/>";
                xml = xml + "<Meta udc='UIDAI\\:SampleClient' fdc='NA' idc='NA' pip='127.0.0.1' lot='P' lov='560103'/>";
                xml = xml + "<Skey ci='20200916'>" + skeyvalue + "</Skey>";
                xml = xml + "<Data type='X'>" + datavalue + "</Data>";
                xml = xml + "<Hmac>" + hmacvalue + "</Hmac></Auth>";

                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(xml);
                xmlDoc.Save(@"E:\1.xml");

                xmlSign.SignFilefrompath("");

                string uri = "https://59.163.223.205/TIN/LinkToAadhaarSubAua";

                string postdata = string.Concat("A99", GetTextFromXMLFile(@"E:\test.xml"));

                var dictinary = new Dictionary<string, string>();
                dictinary.Add("eXml", postdata);

                return HttpPostRequest(uri, dictinary);
            }
            catch
            {
                return "Failure";
            }
        }

        private string HttpPostRequest(string url, Dictionary<string, string> postParameters)
        {
            string Status = string.Empty;
            try
            {
                string postData = "";

                foreach (string key in postParameters.Keys)
                {
                    postData += HttpUtility.UrlEncode(key) + "="
                          + HttpUtility.UrlEncode(postParameters[key]);
                }

                HttpWebRequest myHttpWebRequest = (HttpWebRequest)HttpWebRequest.Create(url);
                myHttpWebRequest.Method = "POST";
                System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) { return true; };
                byte[] data = Encoding.UTF8.GetBytes(postData);

                myHttpWebRequest.ContentType = "application/x-www-form-urlencoded";
                myHttpWebRequest.ContentLength = data.Length;

                Stream requestStream = myHttpWebRequest.GetRequestStream();
                requestStream.Write(data, 0, data.Length);
                requestStream.Close();

                HttpWebResponse myHttpWebResponse = (HttpWebResponse)myHttpWebRequest.GetResponse();

                Stream responseStream = myHttpWebResponse.GetResponseStream();

                StreamReader myStreamReader = new StreamReader(responseStream, Encoding.UTF8);

                string pageContent = myStreamReader.ReadToEnd();

                myStreamReader.Close();
                responseStream.Close();

                myHttpWebResponse.Close();
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(pageContent);
                if (xmlDoc.ChildNodes[1].Attributes != null && xmlDoc.ChildNodes[1].Attributes["ret"].Value == "y")
                {
                    Status = "Success";
                }
                else
                {
                    Status = "Failure";
                }
            }
            catch
            {
                Status = "Failure";
            }
            finally
            {

            }
            return Status;
        }

        private string GetTextFromXMLFile(string file)
        {

            StreamReader reader = new StreamReader(file);
            string ret = reader.ReadToEnd();
            reader.Close();
            return ret;

        }


        private string EncryptData(string input, byte[] SessionKey)
        {
            AesCryptoServiceProvider AES = new AesCryptoServiceProvider();
            byte[] keyArray = SessionKey; // 256-AES key
                                          //convert PIDXml to Byte Array  
            byte[] toEncryptArray = UTF8Encoding.UTF8.GetBytes(input);
            AES.Key = keyArray;
            AES.Mode = CipherMode.ECB;
            AES.Padding = PaddingMode.PKCS7;
            ICryptoTransform cTransform = AES.CreateEncryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);

            return Convert.ToBase64String(resultArray);

        }
        private string EncryptDatabyte(byte[] toEncryptArray, byte[] SessionKey)
        {
            AesCryptoServiceProvider AES = new AesCryptoServiceProvider();
            byte[] keyArray = SessionKey; // 256-AES key
            AES.Key = keyArray;
            AES.Mode = CipherMode.ECB;
            AES.Padding = PaddingMode.PKCS7;
            ICryptoTransform cTransform = AES.CreateEncryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);

            return Convert.ToBase64String(resultArray);

        }

        private byte[] GetSHA256(byte[] text)
        {
            byte[] hashValue;
            SHA256Managed hashString = new SHA256Managed();
            string hex = "";
            hashValue = hashString.ComputeHash(text);
            foreach (byte x in hashValue)
            {
                hex += String.Format("{0:x2}", x);
            }
            return hashValue;

        }

        private string EncryptSessionKey(byte[] SessionKey)
        {
            byte[] encryptedSessionKey;
            X509Certificate2 x509 = new X509Certificate2(@"E:\AGMTEAM\HMS\Application.Web\Application.Helpers\AadhaarauthHelpers\Certificates\uidai_auth_stage.cer");
            RSACryptoServiceProvider rsa = (RSACryptoServiceProvider)x509.PublicKey.Key;
            encryptedSessionKey = rsa.Encrypt(SessionKey, false);

            return Convert.ToBase64String(encryptedSessionKey);
        }
    }
}
