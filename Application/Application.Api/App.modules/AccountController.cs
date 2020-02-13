using System;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;
using Application.Dal.DataModel;
using Application.Security;
using Application.Security.UserManagerClass;
using Newtonsoft.Json;

namespace Application.Api.App.modules
{
    [RoutePrefix("api/Account")]
    public class AccountController : ApiController
    {
        private ChatAppEntities db = new ChatAppEntities();
        readonly UserManager _manager;
        public AccountController()
        {
            _manager = new UserManager();
        }
        //[AllowAnonymous]
        //[Route("Register")]
        //public SecurityInfo Register(RegisterUserModel userModel)
        //{
        //    var result = _manager.Register(userModel);
        //    if (result != null)
        //    {
        //        var Cid = db.CustomerRegistrations.Where(c => c.MobileNumber == userModel.PhoneNumber).Select(c=>c.CustomerId).FirstOrDefault();
        //        CustomerData fd = new CustomerData
        //        {
        //            CustomerId = Cid,
        //            MachineId = GenerateMachineId(),
        //            Firstname = userModel.FirstName,
        //            Address = userModel.Address,
        //            PhoneNumber = userModel.PhoneNumber,
        //            Pincode = userModel.Pincode,
        //            City = userModel.CityId.ToString()
        //        };
        //        HttpClient client = new HttpClient
        //        {
        //            BaseAddress = new Uri("http://localhost:2222/")
        //        };
        //        client.DefaultRequestHeaders.Accept.Clear();
        //        client.DefaultRequestHeaders.Accept.Add(new
        //            MediaTypeWithQualityHeaderValue("application/json"));
        //        var url = "api/CustomerCartDetails/UpdateCartDetails";
        //        HttpResponseMessage response = client.PostAsJsonAsync(url, fd).Result;
        //        var Result = response.Content.ReadAsStringAsync().Result;
        //        var jobject = JsonConvert.DeserializeObject<string>(Result);
        //    }
        //    return result;
        //}

        public string GenerateMachineId()
        {
            Process process = new Process();
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = "CMD.exe";
            startInfo.Arguments = "/C wmic csproduct get UUID";
            process.StartInfo = startInfo;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.Start();
            process.WaitForExit();
            string output = process.StandardOutput.ReadToEnd();
            return output;
        }
        public class CustomerData
        {
            public string CustomerId { get; set; }
            public string MachineId { get; set; }
            public string Firstname { get; set; }
            public string PhoneNumber { get; set; }
            public string Address { get; set; }
            public string Pincode { get; set; }
            public string City { get; set; }
        }
    }
}
