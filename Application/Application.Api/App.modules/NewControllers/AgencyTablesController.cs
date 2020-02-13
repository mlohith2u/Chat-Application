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
using Application.Api.App.modules.ViewModels;
using Application.Dal.DataModel;

namespace Application.Api.App.modules.NewControllers
{
    public class AgencyTablesController : ApiController
    {
        private UserMgmtEntities db = new UserMgmtEntities();

        // GET: api/AgencyTables
        public IQueryable<AgencyTable> GetAgencyTables()
        {
            return db.AgencyTables;
        }

        // GET: api/AgencyTables/5
        [ResponseType(typeof(AgencyTable))]
        public async Task<IHttpActionResult> GetAgencyTable(int id)
        {
            AgencyTable agencyTable = await db.AgencyTables.FindAsync(id);
            if (agencyTable == null)
            {
                return NotFound();
            }

            return Ok(agencyTable);
        }

        [HttpPost]
        [ResponseType(typeof(AgencyTable))]
        public async Task<IHttpActionResult> DistcAgents(DistAgents dstofc)
        {

            List<AgencyTable> DA = new List<AgencyTable>();
            try
            {
                var agents = db.AgencyTables.Where(c => c.DistrictOffice == dstofc.DistrictOffice).ToList();
                for (int j = 0; j < agents.Count; j++)
                {
                    DA.Add(agents[j]);
                }


            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Ok(DA);
        }


        // PUT: api/AgencyTables/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutAgencyTable(AgencyTable agencyTable)
        {
            var id = agencyTable.ID;
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != agencyTable.ID)
            {
                return BadRequest();
            }

            db.Entry(agencyTable).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AgencyTableExists(id))
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

        // POST: api/AgencyTables
        [ResponseType(typeof(AgencyTable))]
        public async Task<IHttpActionResult> PostAgencyTable(AgencyTable agencyTable)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.AgencyTables.Add(agencyTable);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = agencyTable.ID }, agencyTable);
        }

        // DELETE: api/AgencyTables/5
        [ResponseType(typeof(AgencyTable))]
        public async Task<IHttpActionResult> DeleteAgencyTable(int id)
        {
            AgencyTable agencyTable = await db.AgencyTables.FindAsync(id);
            if (agencyTable == null)
            {
                return NotFound();
            }

            db.AgencyTables.Remove(agencyTable);
            await db.SaveChangesAsync();

            return Ok(agencyTable);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AgencyTableExists(int id)
        {
            return db.AgencyTables.Count(e => e.ID == id) > 0;
        }
    }
}