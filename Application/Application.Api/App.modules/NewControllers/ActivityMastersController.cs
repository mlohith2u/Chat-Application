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

namespace Application.Api.App.modules.NewControllers
{
    public class ActivityMastersController : ApiController
    {
        private UserMgmtEntities db = new UserMgmtEntities();

        // GET: api/ActivityMasters
        public IQueryable<ActivityMaster> GetActivityMasters()
        {
            return db.ActivityMasters;
        }

        // GET: api/ActivityMasters/5
        [ResponseType(typeof(ActivityMaster))]
        public async Task<IHttpActionResult> GetActivityMaster(int id)
        {
            ActivityMaster activityMaster = await db.ActivityMasters.FindAsync(id);
            if (activityMaster == null)
            {
                return NotFound();
            }

            return Ok(activityMaster);
        }

        // PUT: api/ActivityMasters/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutActivityMaster(ActivityMaster activityMaster)
        {
            var id = activityMaster.ID;
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != activityMaster.ID)
            {
                return BadRequest();
            }

            db.Entry(activityMaster).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ActivityMasterExists(id))
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

        // POST: api/ActivityMasters
        [ResponseType(typeof(ActivityMaster))]
        public async Task<IHttpActionResult> PostActivityMaster(ActivityMaster activityMaster)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ActivityMasters.Add(activityMaster);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = activityMaster.ID }, activityMaster);
        }

        // DELETE: api/ActivityMasters/5
        [ResponseType(typeof(ActivityMaster))]
        public async Task<IHttpActionResult> DeleteActivityMaster(int id)
        {
            ActivityMaster activityMaster = await db.ActivityMasters.FindAsync(id);
            if (activityMaster == null)
            {
                return NotFound();
            }

            db.ActivityMasters.Remove(activityMaster);
            await db.SaveChangesAsync();

            return Ok(activityMaster);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ActivityMasterExists(int id)
        {
            return db.ActivityMasters.Count(e => e.ID == id) > 0;
        }
    }
}