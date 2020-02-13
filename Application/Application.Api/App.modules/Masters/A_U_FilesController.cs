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
    public class A_U_FilesController : ApiController
    {
        private srichidacademyEntities db = new srichidacademyEntities();

        // GET: api/A_U_Files
        public IQueryable<A_U_Files> GetA_U_Files()
        {
            return db.A_U_Files;
        }

        // GET: api/A_U_Files/5
        [ResponseType(typeof(A_U_Files))]
        public async Task<IHttpActionResult> GetA_U_Files(int id)
        {
            A_U_Files a_U_Files = await db.A_U_Files.FindAsync(id);
            if (a_U_Files == null)
            {
                return NotFound();
            }

            return Ok(a_U_Files);
        }

        // PUT: api/A_U_Files/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutA_U_Files(int id, A_U_Files a_U_Files)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != a_U_Files.ID)
            {
                return BadRequest();
            }

            db.Entry(a_U_Files).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!A_U_FilesExists(id))
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

        // POST: api/A_U_Files
        [ResponseType(typeof(A_U_Files))]
        public async Task<IHttpActionResult> PostA_U_Files(A_U_Files a_U_Files)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.A_U_Files.Add(a_U_Files);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = a_U_Files.ID }, a_U_Files);
        }

        // DELETE: api/A_U_Files/5
        [ResponseType(typeof(A_U_Files))]
        public async Task<IHttpActionResult> DeleteA_U_Files(int id)
        {
            A_U_Files a_U_Files = await db.A_U_Files.FindAsync(id);
            if (a_U_Files == null)
            {
                return NotFound();
            }

            db.A_U_Files.Remove(a_U_Files);
            await db.SaveChangesAsync();

            return Ok(a_U_Files);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool A_U_FilesExists(int id)
        {
            return db.A_U_Files.Count(e => e.ID == id) > 0;
        }
    }
}