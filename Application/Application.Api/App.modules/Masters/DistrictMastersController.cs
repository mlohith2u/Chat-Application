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
    public class DistrictMastersController : ApiController
    {
        private srichidacademyEntities db = new srichidacademyEntities();

        // GET: api/DistrictMasters
        public IQueryable<DistrictMaster> GetDistrictMasters()
        {
            return db.DistrictMasters;
        }

        // GET: api/DistrictMasters/5
        [ResponseType(typeof(DistrictMaster))]
        public async Task<IHttpActionResult> GetDistrictMaster(int id)
        {
            DistrictMaster districtMaster = await db.DistrictMasters.FindAsync(id);
            if (districtMaster == null)
            {
                return NotFound();
            }

            return Ok(districtMaster);
        }

        // PUT: api/DistrictMasters/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutDistrictMaster(int id, DistrictMaster districtMaster)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != districtMaster.Id)
            {
                return BadRequest();
            }

            db.Entry(districtMaster).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DistrictMasterExists(id))
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

        // POST: api/DistrictMasters
        [ResponseType(typeof(DistrictMaster))]
        public async Task<IHttpActionResult> PostDistrictMaster(DistrictMaster districtMaster)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.DistrictMasters.Add(districtMaster);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = districtMaster.Id }, districtMaster);
        }

        // DELETE: api/DistrictMasters/5
        [ResponseType(typeof(DistrictMaster))]
        public async Task<IHttpActionResult> DeleteDistrictMaster(int id)
        {
            DistrictMaster districtMaster = await db.DistrictMasters.FindAsync(id);
            if (districtMaster == null)
            {
                return NotFound();
            }

            db.DistrictMasters.Remove(districtMaster);
            await db.SaveChangesAsync();

            return Ok(districtMaster);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DistrictMasterExists(int id)
        {
            return db.DistrictMasters.Count(e => e.Id == id) > 0;
        }
    }
}