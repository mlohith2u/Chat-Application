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
    public class DistrictOfficeTablesController : ApiController
    {
        private UserMgmtEntities db = new UserMgmtEntities();

        // GET: api/DistrictOfficeTables
        public async Task<IHttpActionResult> GetDistrictOfficeTables()
        {
            var data = db.DistrictOfficeTables.ToList();
            return Ok(data);
        }

        // GET: api/DistrictOfficeTables/5
        [ResponseType(typeof(DistrictOfficeTable))]
        public async Task<IHttpActionResult> GetDistrictOfficeTable(int id)
        {
            DistrictOfficeTable districtOfficeTable = await db.DistrictOfficeTables.FindAsync(id);
            if (districtOfficeTable == null)
            {
                return NotFound();
            }

            return Ok(districtOfficeTable);
        }

        // PUT: api/DistrictOfficeTables/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutDistrictOfficeTable(DistrictOfficeTable districtOfficeTable)
        {
            var id = districtOfficeTable.ID;
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != districtOfficeTable.ID)
            {
                return BadRequest();
            }

            db.Entry(districtOfficeTable).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DistrictOfficeTableExists(id))
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

        // POST: api/DistrictOfficeTables
        [ResponseType(typeof(DistrictOfficeTable))]
        public async Task<IHttpActionResult> PostDistrictOfficeTable(DistrictOfficeTable districtOfficeTable)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.DistrictOfficeTables.Add(districtOfficeTable);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = districtOfficeTable.ID }, districtOfficeTable);
        }

        // DELETE: api/DistrictOfficeTables/5
        [ResponseType(typeof(DistrictOfficeTable))]
        public async Task<IHttpActionResult> DeleteDistrictOfficeTable(int id)
        {
            DistrictOfficeTable districtOfficeTable = await db.DistrictOfficeTables.FindAsync(id);
            if (districtOfficeTable == null)
            {
                return NotFound();
            }

            db.DistrictOfficeTables.Remove(districtOfficeTable);
            await db.SaveChangesAsync();

            return Ok(districtOfficeTable);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DistrictOfficeTableExists(int id)
        {
            return db.DistrictOfficeTables.Count(e => e.ID == id) > 0;
        }
    }
}