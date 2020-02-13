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
using Application.Dal.DataModel;

namespace Application.Api.App.modules.Controllers
{
    public class AddressbooksController : ApiController
    {
        private UserMgmtEntities db = new UserMgmtEntities();

        // GET: api/Addressbooks
        public IQueryable<Addressbook> GetAddressbooks()
        {
            return db.Addressbooks;
        }

        // GET: api/Addressbooks/5
        [ResponseType(typeof(Addressbook))]
        public async Task<IHttpActionResult> GetAddressbook(int id)
        {
            Addressbook addressbook = await db.Addressbooks.FindAsync(id);
            if (addressbook == null)
            {
                return NotFound();
            }

            return Ok(addressbook);
        }

        // PUT: api/Addressbooks/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutAddressbook(Addressbook addressbook)
        {
            int id = addressbook.Id;
            db.Entry(addressbook).State = EntityState.Modified;        
            await db.SaveChangesAsync();
            var aa = db.Addressbooks.Where(c=>c.Id == addressbook.Id).FirstOrDefault();
            
            return Ok(aa);
        }

        // POST: api/Addressbooks
        [ResponseType(typeof(Addressbook))]
        public async Task<IHttpActionResult> PostAddressbook(Addressbook addressbook)
        {
            var dd = db.A_U_Management.Where(c => c.UserName == addressbook.UserName).Select(c => c.PhoneNumber).FirstOrDefault();
            var CID = db.CustomerRegistrations.Where(d => d.MobileNumber == dd).Select(d => d.CustomerId).FirstOrDefault();

            addressbook.CustomerId = CID;
            addressbook.LastUpdated = DateTime.Now;
            db.Addressbooks.Add(addressbook);
            await db.SaveChangesAsync();
            
            return CreatedAtRoute("DefaultApi", new { id = addressbook.Id }, addressbook);
        }

        [HttpGet]
        public IHttpActionResult Addresslist(string id)
        {
            var dd = db.A_U_Management.Where(c => c.UserName == id).Select(c => c.PhoneNumber).FirstOrDefault();
            var CID = db.CustomerRegistrations.Where(d => d.MobileNumber == dd).Select(d => d.CustomerId).FirstOrDefault();
            var data = db.Addressbooks.Where(c => c.CustomerId == CID).ToList();
            return Ok(data);
        }

        // DELETE: api/Addressbooks/5
        [ResponseType(typeof(Addressbook))]
        public async Task<IHttpActionResult> DeleteAddressbook(int id)
        {
            Addressbook addressbook = await db.Addressbooks.FindAsync(id);
            if (addressbook == null)
            {
                return NotFound();
            }

            db.Addressbooks.Remove(addressbook);
            await db.SaveChangesAsync();

            return Ok(addressbook);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AddressbookExists(int id)
        {
            return db.Addressbooks.Count(e => e.Id == id) > 0;
        }
    }
}