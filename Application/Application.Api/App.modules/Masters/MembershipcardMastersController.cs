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

namespace Application.Api.App.modules.Masters
{
    public class MembershipcardMastersController : ApiController
    {
        private srichidacademyEntities db = new srichidacademyEntities();

        // GET: api/MembershipcardMasters
        public IQueryable<MembershipcardMaster> GetMembershipcardMasters()
        {
            return db.MembershipcardMasters;
        }

        // GET: api/MembershipcardMasters/5
        [ResponseType(typeof(MembershipcardMaster))]
        public async Task<IHttpActionResult> GetMembershipcardMaster(int id)
        {
            MembershipcardMaster membershipcardMaster = await db.MembershipcardMasters.FindAsync(id);
            if (membershipcardMaster == null)
            {
                return NotFound();
            }

            return Ok(membershipcardMaster);
        }

        // PUT: api/MembershipcardMasters/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutMembershipcardMaster(int id, MembershipcardMaster membershipcardMaster)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != membershipcardMaster.Id)
            {
                return BadRequest();
            }

            db.Entry(membershipcardMaster).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MembershipcardMasterExists(id))
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

        // POST: api/MembershipcardMasters
        [ResponseType(typeof(MembershipcardMaster))]
        public async Task<IHttpActionResult> PostMembershipcardMaster(MembershipcardMaster membershipcardMaster)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.MembershipcardMasters.Add(membershipcardMaster);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = membershipcardMaster.Id }, membershipcardMaster);
        }

        // DELETE: api/MembershipcardMasters/5
        [ResponseType(typeof(MembershipcardMaster))]
        public async Task<IHttpActionResult> DeleteMembershipcardMaster(int id)
        {
            MembershipcardMaster membershipcardMaster = await db.MembershipcardMasters.FindAsync(id);
            if (membershipcardMaster == null)
            {
                return NotFound();
            }

            db.MembershipcardMasters.Remove(membershipcardMaster);
            await db.SaveChangesAsync();

            return Ok(membershipcardMaster);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MembershipcardMasterExists(int id)
        {
            return db.MembershipcardMasters.Count(e => e.Id == id) > 0;
        }
        //[HttpGet]
        //public IHttpActionResult GetCustomerCardDetails(string name)
        //{
        //    var dd = db.A_U_Management.Where(c => c.UserName == name).Select(c => c.PhoneNumber).FirstOrDefault();
        //    var CID = db.CustomerRegistrations.Where(d => d.MobileNumber == dd).Select(d => d.CustomerId).FirstOrDefault();
        //    var data = db.Customercards.Where(c => c.CustomerId == CID && c.Paid == false).FirstOrDefault();
        //    return Ok(data);
        //}
    }
}