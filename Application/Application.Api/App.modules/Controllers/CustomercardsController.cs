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
using Application.Api.App.modules.PayuControllers;
using Application.Dal.DataModel;

namespace Application.Api.App.modules.Controllers
{
    public class CustomercardsController : ApiController
    {
        private UserMgmtEntities db = new UserMgmtEntities();

        // GET: api/Customercards
        public IQueryable<Customercard> GetCustomercards()
        {
            return db.Customercards;
        }

        // GET: api/Customercards/5
        [ResponseType(typeof(Customercard))]
        public async Task<IHttpActionResult> GetCustomercard(int id)
        {
            Customercard customercard = await db.Customercards.FindAsync(id);
            if (customercard == null)
            {
                return NotFound();
            }

            return Ok(customercard);
        }

        // PUT: api/Customercards/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutCustomercard(int id, Customercard customercard)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != customercard.Id)
            {
                return BadRequest();
            }

            db.Entry(customercard).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomercardExists(id))
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

        // POST: api/Customercards
        [ResponseType(typeof(Customercard))]
        [HttpPost]
        public async Task<IHttpActionResult> PostCustomercard(Customercard customercard)
        {
            var dd = db.A_U_Management.Where(c => c.UserName == customercard.Username).Select(c => c.PhoneNumber).FirstOrDefault();
            var CID = db.CustomerRegistrations.Where(d => d.MobileNumber == dd).Select(d => d.CustomerId).FirstOrDefault();
            //var Options = db.CustomerRegistrations.Where(d => d.MobileNumber == dd).Select(c => new { cid = c.CustomerId, cname = c.CustomerName, mn = c.MobileNumber, em = c.Email }).FirstOrDefault();
            customercard.CustomerId = CID;
            db.Customercards.Add(customercard);
            await db.SaveChangesAsync();      

           return CreatedAtRoute("DefaultApi", new { id = customercard.Id }, customercard);
        }

        // DELETE: api/Customercards/5
        [ResponseType(typeof(Customercard))]
        public async Task<IHttpActionResult> DeleteCustomercard(int id)
        {
            Customercard customercard = await db.Customercards.FindAsync(id);
            if (customercard == null)
            {
                return NotFound();
            }

            db.Customercards.Remove(customercard);
            await db.SaveChangesAsync();

            return Ok(customercard);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CustomercardExists(int id)
        {
            return db.Customercards.Count(e => e.Id == id) > 0;
        }

        [HttpPost]
        public IHttpActionResult GetCustomerCardDetails(User aa)
        {
            var dd = db.A_U_Management.Where(c => c.UserName == aa.UserName).Select(c => c.PhoneNumber).FirstOrDefault();
            var Options = db.CustomerRegistrations.Where(d => d.MobileNumber == dd).Select(c => new  { cid = c.CustomerId, cname = c.CustomerName, mn = c.MobileNumber, em = c.Email }).FirstOrDefault();

            var data = db.Customercards.Where(c => c.CustomerId == Options.cid && c.Paid == false).FirstOrDefault();

            var bb = new Details
            {
                Cardtype = data.Cardtype,
                Username= aa.UserName,
                Amount= data.Amount,
                CustomerId= Options.cid,
                Paid= data.Paid,
                TotalAmount =data.TotalAmount,
                Id = data.Id,
                Email = Options.em,
                PhoneNumber= Options.mn
            };

            var paym = new PayUPaymentViewModel
            {
                Amount = data.TotalAmount.ToString(),
                DesBusiness = "Orders",
                Email = Options.em,
                Fname = aa.UserName,
                Lname = "",
                Mobileno = Options.mn,
                CustomerId = Options.cid,
                //OrderId = 
            };

            var pay = new Upay();

            var result = pay.PayAmount(paym);
            return Ok(result);
            //return Ok(bb);
        }

        public class User
        {
            public string UserName { get; set; }
        }

        public class Details
        {
            public int Id { get; set; }
            public string CustomerId { get; set; }
            public Nullable<int> Cardtype { get; set; }
            public Nullable<int> Amount { get; set; }
            public Nullable<int> TotalAmount { get; set; }
            public Nullable<bool> Paid { get; set; }
            public Nullable<System.DateTime> LastUpdated { get; set; }
            public string Username { get; set; }
            public string Email { get; set; }
            public string PhoneNumber { get; set; }
        }

        [HttpGet]
        public IHttpActionResult GetPaymentTypes()
        {
            var data = db.PaymentTypes.ToList();
            return Ok(data);
        }
    }
}