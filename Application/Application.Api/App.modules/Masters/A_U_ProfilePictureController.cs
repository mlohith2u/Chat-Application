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
    public class A_U_ProfilePictureController : ApiController
    {
        private srichidacademyEntities db = new srichidacademyEntities();

        // GET: api/A_U_ProfilePicture
        public IQueryable<A_U_ProfilePicture> GetA_U_ProfilePicture()
        {
            return db.A_U_ProfilePicture;
        }

        // GET: api/A_U_ProfilePicture/5
        [ResponseType(typeof(A_U_ProfilePicture))]
        public async Task<IHttpActionResult> GetA_U_ProfilePicture(int id)
        {
            A_U_ProfilePicture a_U_ProfilePicture = await db.A_U_ProfilePicture.FindAsync(id);
            if (a_U_ProfilePicture == null)
            {
                return NotFound();
            }

            return Ok(a_U_ProfilePicture);
        }

        // PUT: api/A_U_ProfilePicture/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutA_U_ProfilePicture(int id, A_U_ProfilePicture a_U_ProfilePicture)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != a_U_ProfilePicture.ID)
            {
                return BadRequest();
            }

            db.Entry(a_U_ProfilePicture).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!A_U_ProfilePictureExists(id))
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

        // POST: api/A_U_ProfilePicture
        [ResponseType(typeof(A_U_ProfilePicture))]
        public async Task<IHttpActionResult> PostA_U_ProfilePicture(A_U_ProfilePicture a_U_ProfilePicture)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            string arr = a_U_ProfilePicture.Image.Substring(23);
            a_U_ProfilePicture.Image = arr;
            db.A_U_ProfilePicture.Add(a_U_ProfilePicture);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = a_U_ProfilePicture.ID }, a_U_ProfilePicture);
        }

        // DELETE: api/A_U_ProfilePicture/5
        [ResponseType(typeof(A_U_ProfilePicture))]
        public async Task<IHttpActionResult> DeleteA_U_ProfilePicture(int id)
        {
            A_U_ProfilePicture a_U_ProfilePicture = await db.A_U_ProfilePicture.FindAsync(id);
            if (a_U_ProfilePicture == null)
            {
                return NotFound();
            }

            db.A_U_ProfilePicture.Remove(a_U_ProfilePicture);
            await db.SaveChangesAsync();

            return Ok(a_U_ProfilePicture);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool A_U_ProfilePictureExists(int id)
        {
            return db.A_U_ProfilePicture.Count(e => e.ID == id) > 0;
        }
    }
}