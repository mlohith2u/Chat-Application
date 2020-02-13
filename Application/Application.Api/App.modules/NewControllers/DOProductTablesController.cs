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
    public class DOProductTablesController : ApiController
    {
        private UserMgmtEntities db = new UserMgmtEntities();

        // GET: api/DOProductTables
        public IQueryable<DOProductTable> GetDOProductTables()
        {
            return db.DOProductTables;
        }

        // GET: api/DOProductTables/5
        [ResponseType(typeof(DOProductTable))]
        public async Task<IHttpActionResult> GetDOProductTable(int id)
        {
            DOProductTable dOProductTable = await db.DOProductTables.FindAsync(id);
            if (dOProductTable == null)
            {
                return NotFound();
            }

            return Ok(dOProductTable);
        }

        // PUT: api/DOProductTables/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutDOProductTable(int id, DOProductTable dOProductTable)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != dOProductTable.Id)
            {
                return BadRequest();
            }

            db.Entry(dOProductTable).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DOProductTableExists(id))
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

        // POST: api/DOProductTables
        [ResponseType(typeof(DOProductTable))]
        public async Task<IHttpActionResult> PostDOProductTable(DOProductTable dOProductTable)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.DOProductTables.Add(dOProductTable);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = dOProductTable.Id }, dOProductTable);
        }

        // DELETE: api/DOProductTables/5
        [ResponseType(typeof(DOProductTable))]
        public async Task<IHttpActionResult> DeleteDOProductTable(int id)
        {
            DOProductTable dOProductTable = await db.DOProductTables.FindAsync(id);
            if (dOProductTable == null)
            {
                return NotFound();
            }

            db.DOProductTables.Remove(dOProductTable);
            await db.SaveChangesAsync();

            return Ok(dOProductTable);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DOProductTableExists(int id)
        {
            return db.DOProductTables.Count(e => e.Id == id) > 0;
        }
    }
}