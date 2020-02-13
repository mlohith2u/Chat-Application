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
    public class A_U_FoldersController : ApiController
    {
        private srichidacademyEntities db = new srichidacademyEntities();

        // GET: api/A_U_Folders
        public IQueryable<A_U_Folders> GetA_U_Folders()
        {
            return db.A_U_Folders;
        }

        // GET: api/A_U_Folders/5
        [ResponseType(typeof(A_U_Folders))]
        public async Task<IHttpActionResult> GetA_U_Folders(int id)
        {
            
            var a_U_Folders = db.A_U_Folders.Where(c=>c.FileID == id).ToList();
            if (a_U_Folders == null)
            {
                return NotFound();
            }

            return Ok(a_U_Folders);
        }

        // PUT: api/A_U_Folders/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutA_U_Folders(int id, A_U_Folders a_U_Folders)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != a_U_Folders.ID)
            {
                return BadRequest();
            }

            db.Entry(a_U_Folders).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!A_U_FoldersExists(id))
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

        // POST: api/A_U_Folders
        [ResponseType(typeof(A_U_Folders))]
        public async Task<IHttpActionResult> PostA_U_Folders(A_U_Folders a_U_Folders)
        {
            a_U_Folders.CreatedOn = DateTime.Now;
            db.A_U_Folders.Add(a_U_Folders);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = a_U_Folders.ID }, a_U_Folders);
        }

        // DELETE: api/A_U_Folders/5
        [ResponseType(typeof(A_U_Folders))]
        public async Task<IHttpActionResult> DeleteA_U_Folders(int id)
        {
            A_U_Folders a_U_Folders = await db.A_U_Folders.FindAsync(id);
            if (a_U_Folders == null)
            {
                return NotFound();
            }
            a_U_Folders.CreatedOn = DateTime.Now;
            db.A_U_Folders.Remove(a_U_Folders);
            await db.SaveChangesAsync();

            return Ok(a_U_Folders);
        }

        [Route("api/A_U_Folders/GetFolders/{file}")]
        public IHttpActionResult GetFolders(int file)
        {
            var a_U_Folders = db.A_U_Folders.Where(c => c.FileID == file).ToList();
            return Ok(a_U_Folders);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool A_U_FoldersExists(int id)
        {
            return db.A_U_Folders.Count(e => e.ID == id) > 0;
        }
    }
}