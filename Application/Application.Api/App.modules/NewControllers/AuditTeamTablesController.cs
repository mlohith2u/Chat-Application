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
    public class AuditTeamTablesController : ApiController
    {
        private UserMgmtEntities db = new UserMgmtEntities();

        // GET: api/AuditTeamTables
        public object GetAuditTeamTables()
        {
            List<string> ll=new List<string>();
            var a = db.AuditTeamTables.ToList();
            //for (int i = 0; i < a.Count; i++)
            //{
            //    if (a[i].TeamName==a[i+1].TeamName)
            //    {
            //        ll.Add(a[i].AssisantName);
            //    }
            //}
            var result = String.Join(", ", ll.ToArray());

            var b = db.AuditTeamTables.Distinct()
                .ToList();

            return Ok(b);
        }

        // GET: api/AuditTeamTables/5
        [ResponseType(typeof(AuditTeamTable))]
        public async Task<IHttpActionResult> GetAuditTeamTable(int id)
        {
            AuditTeamTable auditTeamTable = await db.AuditTeamTables.FindAsync(id);
            if (auditTeamTable == null)
            {
                return NotFound();
            }

            return Ok(auditTeamTable);
        }

        // GET: api/AuditTeamTables/5
        [HttpPost]
        [ResponseType(typeof(AuditTeamTable))]
        public async Task<IHttpActionResult> AuditLeaderDetails(AuditPlan name)
        {
            AuditTeamTable auditTeamTable = db.AuditTeamTables.Where(c => c.TeamName == name.teamName).FirstOrDefault();
            
           // AuditTeamTable auditTeamTable = await db.AuditTeamTables.FindAsync(name);
            //if (auditTeamTable == null)
            //{
            //    return NotFound();
            //}

            return Ok(auditTeamTable);
        }

        // PUT: api/AuditTeamTables/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutAuditTeamTable( AuditTeamTable auditTeamTable)
        {
            var id = auditTeamTable.ID;
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != auditTeamTable.ID)
            {
                return BadRequest();
            }

            db.Entry(auditTeamTable).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AuditTeamTableExists(id))
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

        // POST: api/AuditTeamTables
        [ResponseType(typeof(AuditTeamTable))]
        public async Task<IHttpActionResult> PostAuditTeamTable(AuditTeamTable auditTeamTable)
        {
            //long CntctNum = auditTeamTable.ContactNumber;
            //var att = new AuditTeamTable()
            //{
            //    AssisantName = auditTeamTable.AssisantName,
            //    ContactNumber = (int)CntctNum,
            //    Month = auditTeamTable.Month,
            //    TeamLeader = auditTeamTable.TeamLeader,
            //    TeamLeaderEmail = auditTeamTable.TeamLeaderEmail,
            //    TeamName = auditTeamTable.TeamName,
            //    TeamStrength = auditTeamTable.TeamStrength,
            //    Year = auditTeamTable.Year
            //};
            //var team = auditTeamTable.AssisantName.Split(',');
            //for (int i = 0; i < team.Length; i++)
            //{
            //    auditTeamTable.AssisantName = team[i];
                db.AuditTeamTables.Add(auditTeamTable);
                await db.SaveChangesAsync();
            //}
         

            return CreatedAtRoute("DefaultApi", new { id = auditTeamTable.ID }, auditTeamTable);
        }

        // DELETE: api/AuditTeamTables/5
        [ResponseType(typeof(AuditTeamTable))]
        public async Task<IHttpActionResult> DeleteAuditTeamTable(int id)
        {
            AuditTeamTable auditTeamTable = await db.AuditTeamTables.FindAsync(id);
            if (auditTeamTable == null)
            {
                return NotFound();
            }

            db.AuditTeamTables.Remove(auditTeamTable);
            await db.SaveChangesAsync();

            return Ok(auditTeamTable);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AuditTeamTableExists(int id)
        {
            return db.AuditTeamTables.Count(e => e.ID == id) > 0;
        }
    }
    //public class AuditTeamTableVM
    //{
    //    public int ID { get; set; }
    //    public string TeamName { get; set; }
    //    public string TeamLeader { get; set; }
    //    public string TeamLeaderEmail { get; set; }
    //    public string ContactNumber { get; set; }
    //    public string AssisantName { get; set; }
    //    public Nullable<int> Year { get; set; }
    //    public string Month { get; set; }
    //    public Nullable<int> TeamStrength { get; set; }
    //}
}