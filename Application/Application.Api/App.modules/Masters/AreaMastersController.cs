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
    public class AreaMastersController : ApiController
    {
        private srichidacademyEntities db = new srichidacademyEntities();

        // GET: api/AreaMasters
        public IQueryable<AreaMaster> GetAreaMasters()
        {
            return db.AreaMasters;
        }

        // GET: api/AreaMasters/5
        [ResponseType(typeof(AreaMaster))]
        public async Task<IHttpActionResult> GetAreaMaster(int id)
        {
            AreaMaster areaMaster = await db.AreaMasters.FindAsync(id);
            if (areaMaster == null)
            {
                return NotFound();
            }

            return Ok(areaMaster);
        }

        [HttpGet]
        public IHttpActionResult GetAreas(int id)
        {
            var aa = db.AreaMasters.Where(c => c.DistrictId == id).ToList();
            return Ok(aa);
        }

        // PUT: api/AreaMasters/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutAreaMaster(int id, AreaMaster areaMaster)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != areaMaster.Id)
            {
                return BadRequest();
            }

            db.Entry(areaMaster).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AreaMasterExists(id))
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

        // POST: api/AreaMasters
        [ResponseType(typeof(AreaMaster))]
        public async Task<IHttpActionResult> PostAreaMaster(AreaMaster areaMaster)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.AreaMasters.Add(areaMaster);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = areaMaster.Id }, areaMaster);
        }

        // DELETE: api/AreaMasters/5
        [ResponseType(typeof(AreaMaster))]
        public async Task<IHttpActionResult> DeleteAreaMaster(int id)
        {
            AreaMaster areaMaster = await db.AreaMasters.FindAsync(id);
            if (areaMaster == null)
            {
                return NotFound();
            }

            db.AreaMasters.Remove(areaMaster);
            await db.SaveChangesAsync();

            return Ok(areaMaster);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AreaMasterExists(int id)
        {
            return db.AreaMasters.Count(e => e.Id == id) > 0;
        }
    }
}