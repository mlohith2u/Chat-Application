using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Application.Api.App.modules.Manageuser.Controllers;
using Application.Dal.DataModel;
using Application.Security.PasswordHashing;

namespace Application.Api.App.modules.Controllers
{
    public class CustomerRegistrationsController : ApiController
    {
        private srichidacademyEntities db = new srichidacademyEntities();
        public string otp;
        // GET: api/CustomerRegistrations
        public IQueryable<CustomerRegistration> GetCustomerRegistrations()
        {
            return db.CustomerRegistrations;
        }

        // GET: api/CustomerRegistrations/5
        [ResponseType(typeof(CustomerRegistration))]
        public async Task<IHttpActionResult> GetCustomerRegistration(int id)
        {
            CustomerRegistration customerRegistration = await db.CustomerRegistrations.FindAsync(id);
            if (customerRegistration == null)
            {
                return NotFound();
            }

            return Ok(customerRegistration);
        }

        // PUT: api/CustomerRegistrations/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutCustomerRegistration(int id, CustomerRegistration customerRegistration)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != customerRegistration.Id)
            {
                return BadRequest();
            }

            db.Entry(customerRegistration).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerRegistrationExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }


        [HttpGet]
        public IHttpActionResult UpdateMembershipstatus(string cid)
        {
            var collections = db.CustomerRegistrations.Where(c => c.CustomerId == cid).FirstOrDefault();
            collections.IsMember = true;
            db.Entry(collections).State = EntityState.Modified;
            db.SaveChanges();
            return Ok();
        }



        // POST: api/CustomerRegistrations
        [ResponseType(typeof(CustomerRegistration))]
        public async Task<IHttpActionResult> SaveCustomerRegistration(CustomerRegistration customerRegistration)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            customerRegistration.CustomerId = GenerateCID();
            db.CustomerRegistrations.Add(customerRegistration);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = customerRegistration.Id }, customerRegistration);
        }

        public string GenerateCID()
        {
            var OID = "";
            var data = db.CustomerRegistrations.Max(c => c.CustomerId);
            if (data != null)
            {
                string digits = new string(data.Where(char.IsDigit).ToArray());
                string letters = new string(data.Where(char.IsLetter).ToArray());
                int number;
                if (!int.TryParse(digits, out number)) //int.Parse would do the job since only digits are selected
                {
                    return null;
                }
                OID = letters + (++number).ToString("D7");
            }
            else
            {
                OID = "CID0000001";
            }
            return OID;
        }
        // DELETE: api/CustomerRegistrations/5
        [ResponseType(typeof(CustomerRegistration))]
        public async Task<IHttpActionResult> DeleteCustomerRegistration(int id)
        {
            CustomerRegistration customerRegistration = await db.CustomerRegistrations.FindAsync(id);
            if (customerRegistration == null)
            {
                return NotFound();
            }

            db.CustomerRegistrations.Remove(customerRegistration);
            await db.SaveChangesAsync();

            return Ok(customerRegistration);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CustomerRegistrationExists(int id)
        {
            return db.CustomerRegistrations.Count(e => e.Id == id) > 0;
        }

        [HttpGet]
        public IHttpActionResult GetPaymentTypes()
        {
            var data = db.PaymentTypes.ToList();
            return Ok(data);
        }
        [HttpGet]
        public IHttpActionResult SendOtp(string mbl)
        {
            var aa = db.A_U_Management.Where(c => c.PhoneNumber == mbl).FirstOrDefault();
            var length = 6;
            otp = GenerateOtp(length);
            try
            {
                CustomerViewModel cust = new CustomerViewModel()
                {
                    CustomerName = aa.FirstName,
                    MobileNumber = aa.PhoneNumber
                };
                SendEmailMobileotpController.SendSMS(cust, otp);

                MobileOTP newotp = new MobileOTP()
                {
                    CustomerID = aa.CustomerId,
                    Mobile = aa.PhoneNumber,
                    OTP = otp,
                    OTPStartingTime = System.DateTime.Now,
                    OTPExpiryTime = System.DateTime.Now.AddMinutes(5)
                };
                db.MobileOTPs.Add(newotp);
                db.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }
            return Ok("0");
        }

        [HttpPost]
        public async Task<string> OTPValidation(MobileOTP aa)
        {
            var OtpFromApp = aa.OTP;
            var expiryTime = db.MobileOTPs.Where(c => c.Mobile == aa.CustomerID).OrderByDescending(c => c.OTPExpiryTime).Select(c => c.OTPExpiryTime).FirstOrDefault();
            var OTPid = db.MobileOTPs.Where(c => c.Mobile == aa.CustomerID).Select(c => c.Id).Max();
            var OTP = db.MobileOTPs.Where(c => c.Id == OTPid).Select(c => c.OTP).FirstOrDefault();

            if (expiryTime >= DateTime.Now)
            {
                if (OtpFromApp == OTP)
                {
                    return "0";
                }
                else
                {
                    return "1";
                }
            }
            else
            {
                return "2";
            }
        }

        [HttpPost]
        public IHttpActionResult MobileValidation(MobileOTP bb)
        {
            var cc = db.A_U_Management.Where(c => c.PhoneNumber == bb.CustomerID).FirstOrDefault();
            if (cc!=null)
            {
                SendOtp(bb.CustomerID);
                return Ok("0");
            }
            else
            {
                return Ok("1");
            }
        }

        [HttpPut]
        public IHttpActionResult UpdatePassword(ResetPassword aa)
        {
            var bb = db.A_U_Management.Where(c => c.PhoneNumber == aa.CId).FirstOrDefault();
            if (bb != null)
            {
                bb.Password = SecurePasswordHasher.Hash(aa.Password);
                bb.ConfirmPassword = aa.ConfirmPassword;
                db.Entry(bb).State = EntityState.Modified;
                db.SaveChangesAsync();
                return Ok("1");
            }
            else
            {
                return Ok();
            }
        }

        public string GenerateOtp(int length)
        {
            var random = new Random();
            var randomnumber = random.Next(100000, 999999);
            return randomnumber.ToString();
        }

        public class CustomerViewModel
        {
            public string CustomerName { get; set; }
            public string MobileNumber { get; set; }
        }
    }
}