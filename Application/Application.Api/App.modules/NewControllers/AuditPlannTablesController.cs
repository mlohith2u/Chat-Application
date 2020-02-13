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
using Castle.Components.DictionaryAdapter;

namespace Application.Api.App.modules.NewControllers
{
    public class AuditPlannTablesController : ApiController
    {
      private UserMgmtEntities db = new UserMgmtEntities();

        // GET: api/AuditPlannTables
        public IQueryable<AuditPlannTable> GetAuditPlannTables()
        {
            return db.AuditPlannTables;
        }

        // GET: api/AuditPlannTables/5
        [ResponseType(typeof(AuditPlannTable))]
        public async Task<IHttpActionResult> GetAuditPlannTable(int id)
        {
            AuditPlannTable auditPlannTable = await db.AuditPlannTables.FindAsync(id);
            
            return Ok(auditPlannTable);
        }

        //[Route("api/AuditPlannTables/GetAuditPlann/{assistantsTable}")]
        [HttpPost]
        public async Task<IHttpActionResult> PostAuditPlanns(List<Auditors> assistantsTable)
        {
            List<AuditPlannTable> LA= new List<AuditPlannTable>();
            try
            {
                for (var i = 0; i < assistantsTable.Count; i++)
                {
                    var tname = assistantsTable[i].teamName;
                    var auditPlans = db.AuditPlannTables.Where(c => c.TeamName == tname).ToList();
                    for (int j = 0; j < auditPlans.Count; j++)
                    {
                        LA.Add(auditPlans[j]);
                    }

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

          


            return Ok(LA);
        }

        [HttpPost]
        
        public async Task<IHttpActionResult> PostDistPlanns(DistAgents dist)
        {

            List<AuditPlannTable> plan = new List<AuditPlannTable>();
            try
            {
                var comments = db.AuditPlannTables.Where(c => c.DistrictOffice == dist.DistrictOffice).ToList();
                for (int j = 0; j < comments.Count; j++)
                {
                    plan.Add(comments[j]);
                }


            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Ok(plan);
        }

        [HttpPost]

        public async Task<IHttpActionResult> TeamPlans(AuditPlan team)
        {

            List<AuditPlannTable> plan = new List<AuditPlannTable>();
            try
            {
                var comments = db.AuditPlannTables.Where(c => c.TeamName == team.teamName).ToList();
                for (int j = 0; j < comments.Count; j++)
                {
                    plan.Add(comments[j]);
                }


            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Ok(plan);
        }

        [HttpPost]

        public async Task<IHttpActionResult> PlansUsingPlanID(Plan PID)
        {
                AuditPlannTable plan = db.AuditPlannTables.Where(c => c.PlanID == PID.auditPlan).FirstOrDefault();
               
            return Ok(plan);
        }

        // PUT: api/AuditPlannTables/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutAuditPlannTable(AuditPlannTable auditPlannTable)
        {
            var id = auditPlannTable.Id;
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != auditPlannTable.Id)
            {
                return BadRequest();
            }

            db.Entry(auditPlannTable).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AuditPlannTableExists(id))
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

        // POST: api/AuditPlannTables
        [ResponseType(typeof(AuditPlannTable))]
        public async Task<IHttpActionResult> PostAuditPlannTable(AuditPlannTable auditPlannTable)
        {
            db.AuditPlannTables.Add(auditPlannTable);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = auditPlannTable.Id }, auditPlannTable);
        }

        // DELETE: api/AuditPlannTables/5
        [ResponseType(typeof(AuditPlannTable))]
        public async Task<IHttpActionResult> DeleteAuditPlannTable(int id)
        {
            AuditPlannTable auditPlannTable = await db.AuditPlannTables.FindAsync(id);
            if (auditPlannTable == null)
            {
                return NotFound();
            }

            db.AuditPlannTables.Remove(auditPlannTable);
            await db.SaveChangesAsync();

            return Ok(auditPlannTable);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AuditPlannTableExists(int id)
        {
            return db.AuditPlannTables.Count(e => e.Id == id) > 0;
        }
    }
}