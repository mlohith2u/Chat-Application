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
    public class UOMMastersController : ApiController
    {
        private srichidacademyEntities db = new srichidacademyEntities();

        // GET: api/UOMMasters
        public IQueryable<UOMMaster> GetUOMMasters()
        {
            return db.UOMMasters;
        }

        // GET: api/UOMMasters/5
        [ResponseType(typeof(UOMMaster))]
        public async Task<IHttpActionResult> GetUOMMaster(int id)
        {
            UOMMaster uOMMaster = await db.UOMMasters.FindAsync(id);
            if (uOMMaster == null)
            {
                return NotFound();
            }

            return Ok(uOMMaster);
        }

        // PUT: api/UOMMasters/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutUOMMaster(int id, UOMMaster uOMMaster)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != uOMMaster.Id)
            {
                return BadRequest();
            }

            db.Entry(uOMMaster).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UOMMasterExists(id))
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

        // POST: api/UOMMasters
        [ResponseType(typeof(UOMMaster))]
        public async Task<IHttpActionResult> PostUOMMaster(UOMMaster uOMMaster)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.UOMMasters.Add(uOMMaster);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = uOMMaster.Id }, uOMMaster);
        }

        // DELETE: api/UOMMasters/5
        [ResponseType(typeof(UOMMaster))]
        public async Task<IHttpActionResult> DeleteUOMMaster(int id)
        {
            UOMMaster uOMMaster = await db.UOMMasters.FindAsync(id);
            if (uOMMaster == null)
            {
                return NotFound();
            }

            db.UOMMasters.Remove(uOMMaster);
            await db.SaveChangesAsync();

            return Ok(uOMMaster);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UOMMasterExists(int id)
        {
            return db.UOMMasters.Count(e => e.Id == id) > 0;
        }
    }
}