using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Application.Bal.Viewmodels;
using Application.Dal.DataModel;

namespace Application.Api.App.modules.Controllers
{
    public class CustomerCartDetailsController : ApiController
    {
        private UserMgmtEntities db = new UserMgmtEntities();

        // GET: api/CustomerCartDetails
        public IQueryable<CustomerCartDetail> GetCustomerCartDetails()
        {
            return db.CustomerCartDetails;
        }

        public IHttpActionResult GetCartlist()
        {
            List<CartDetails> data = new List<CartDetails>();
            var MachineID = GenerateMachineId();
            var aa = db.CustomerCartDetails.Where(c => c.MachineId == MachineID && c.IsOrdered==false).ToList();
            foreach (var item in aa)
            {
                CartDetails _pdd = new CartDetails
                {
                    CustomerId = item.CustomerId,
                    Id = item.Id,
                    IsOrdered = item.IsOrdered,
                    ItemId = item.ItemId,
                    LastUpdated = item.LastUpdated,
                    MachineId = item.MachineId,
                    Image = db.MenuCategories.Where(c => c.MenuId == item.ItemId).Select(c => c.Image).FirstOrDefault(),
                    MenuName = db.MenuCategories.Where(c => c.MenuId == item.ItemId).Select(c => c.MenuName).FirstOrDefault(),
                    Quantity = item.Quantity,
                    RatePerItem = item.RatePerItem,
                    TotalAmount = item.TotalAmount
                };
                data.Add(_pdd);
            }
            return Ok(data);
        }

        // GET: api/CustomerCartDetails/5
        [ResponseType(typeof(CustomerCartDetail))]
        public async Task<IHttpActionResult> GetCustomerCartDetail(int id)
        {
            CustomerCartDetail customerCartDetail = await db.CustomerCartDetails.FindAsync(id);
            if (customerCartDetail == null)
            {
                return NotFound();
            }

            return Ok(customerCartDetail);
        }

        // PUT: api/CustomerCartDetails/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutCustomerCartDetail(int id, CustomerCartDetail customerCartDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != customerCartDetail.Id)
            {
                return BadRequest();
            }

            db.Entry(customerCartDetail).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerCartDetailExists(id))
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

        // POST: api/CustomerCartDetails
        [ResponseType(typeof(CustomerCartDetail))]
        public async Task<IHttpActionResult> PostCustomerCartDetail(CustomerCartDetail customerCartDetail)
        {
            var MachineID = GenerateMachineId();
            customerCartDetail.IsOrdered = false;
            customerCartDetail.MachineId = MachineID;
            customerCartDetail.LastUpdated = DateTime.Now;
            db.CustomerCartDetails.Add(customerCartDetail);
            await db.SaveChangesAsync();

            var dd = db.CustomerCartDetails.Where(c => c.MachineId == MachineID).ToList();
            return Ok(dd);
            //return CreatedAtRoute("DefaultApi", new { id = customerCartDetail.Id }, customerCartDetail);
        }

        [HttpGet]
        public IHttpActionResult ReduceItem(int id)
        {
            var dd = db.CustomerCartDetails.Where(c => c.Id == id).FirstOrDefault();
            if (dd != null)
            {
                dd.Quantity = dd.Quantity - 1;
                db.Entry(dd).State = EntityState.Modified;
                db.SaveChanges();
            }
            var data = db.CustomerCartDetails.Where(c => c.Id == id).FirstOrDefault();
            return Ok(data);
        }

        // DELETE: api/CustomerCartDetails/5
        [ResponseType(typeof(CustomerCartDetail))]
        [HttpDelete]
        public async Task<IHttpActionResult> DeleteCustomerCartDetail(int id)
        {
            CustomerCartDetail customerCartDetail = await db.CustomerCartDetails.FindAsync(id);
            if (customerCartDetail == null)
            {
                return NotFound();
            }

            db.CustomerCartDetails.Remove(customerCartDetail);
            await db.SaveChangesAsync();

            return Ok(customerCartDetail);
        }

        [HttpGet]
        public IHttpActionResult PostMovetocart(string id)
        {
            var data = db.CustomerWishlistDetails.Where(c => c.ItemId == id).FirstOrDefault();
            if (data != null)
            {
                data.IsMovedtoCart = true;
                db.Entry(data).State = EntityState.Modified;
                db.SaveChanges();
            }
            var cc = new CustomerCartDetail
            {
                MachineId = data.MachineId,
                LastUpdated = DateTime.Now,
                ItemId = data.ItemId,
                Quantity = data.Quantity,
                RatePerItem = data.RatePerItem,
                TotalAmount = data.TotalAmount,
                IsOrdered = false
            };
            db.CustomerCartDetails.Add(cc);
            db.SaveChanges();
            return Ok();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CustomerCartDetailExists(int id)
        {
            return db.CustomerCartDetails.Count(e => e.Id == id) > 0;
        }

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

        [HttpGet]
        public IHttpActionResult AddItem(int id)
        {
            var dd = db.CustomerCartDetails.Where(c => c.Id == id).FirstOrDefault();
            if (dd != null)
            {
                dd.Quantity = dd.Quantity + 1;
                db.Entry(dd).State = EntityState.Modified;
                db.SaveChanges();
            }
            var data= db.CustomerCartDetails.Where(c => c.Id == id).FirstOrDefault();
            return Ok(data);
        }

        public class Details
        {
            public string ItemId { get; set; }
            public int Quantity { get; set; }
        }
    }
}