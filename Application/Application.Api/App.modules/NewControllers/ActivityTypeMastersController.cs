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
    public class ActivityTypeMastersController : ApiController
    {
        private UserMgmtEntities db = new UserMgmtEntities();

        // GET: api/ActivityTypeMasters
        public IQueryable<ActivityTypeMaster> GetActivityTypeMasters()
        {
            return db.ActivityTypeMasters;
        }

        // GET: api/ActivityTypeMasters/5
        [ResponseType(typeof(ActivityTypeMaster))]
        public async Task<IHttpActionResult> GetActivityTypeMaster(int id)
        {
            ActivityTypeMaster activityTypeMaster = await db.ActivityTypeMasters.FindAsync(id);
            if (activityTypeMaster == null)
            {
                return NotFound();
            }

            return Ok(activityTypeMaster);
        }

        // PUT: api/ActivityTypeMasters/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutActivityTypeMaster(ActivityTypeMaster activityTypeMaster)
        {
            var id = activityTypeMaster.ID;
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != activityTypeMaster.ID)
            {
                return BadRequest();
            }

            db.Entry(activityTypeMaster).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ActivityTypeMasterExists(id))
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

        // POST: api/ActivityTypeMasters
        [ResponseType(typeof(ActivityTypeMaster))]
        public async Task<IHttpActionResult> PostActivityTypeMaster(ActivityTypeMaster activityTypeMaster)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ActivityTypeMasters.Add(activityTypeMaster);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = activityTypeMaster.ID }, activityTypeMaster);
        }

        // DELETE: api/ActivityTypeMasters/5
        [ResponseType(typeof(ActivityTypeMaster))]
        public async Task<IHttpActionResult> DeleteActivityTypeMaster(int id)
        {
            ActivityTypeMaster activityTypeMaster = await db.ActivityTypeMasters.FindAsync(id);
            if (activityTypeMaster == null)
            {
                return NotFound();
            }

            db.ActivityTypeMasters.Remove(activityTypeMaster);
            await db.SaveChangesAsync();

            return Ok(activityTypeMaster);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ActivityTypeMasterExists(int id)
        {
            return db.ActivityTypeMasters.Count(e => e.ID == id) > 0;
        }
    }
}