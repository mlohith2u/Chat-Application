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
using Newtonsoft.Json.Linq;

namespace Application.Api.App.modules.NewControllers
{
    public class AssistantsTablesController : ApiController
    {
        private UserMgmtEntities db = new UserMgmtEntities();

        // GET: api/AssistantsTables
        public IQueryable<AssistantsTable> GetAssistantsTables()
        {
            return db.AssistantsTables;
        }

        // GET: api/AssistantsTables/5
        [HttpPost]
        [ResponseType(typeof(AssistantsTable))]
        public async Task<IHttpActionResult> AssistantsTable(AuditPlan teamName)
        {
            
            List<AssistantsTable> tm = new List<AssistantsTable>();
            try
            {
                    var teamMembers = db.AssistantsTables.Where(c => c.TeamName == teamName.teamName).ToList();
                    for (int j = 0; j < teamMembers.Count; j++)
                    {
                        tm.Add(teamMembers[j]);
                    }

                
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Ok(tm);
        }

        // GET: api/AssistantsTables/5
        [ResponseType(typeof(AssistantsTable))]
        public async Task<IHttpActionResult> GetUserTeams(string name)
        {
            
            AssistantsTable assistantsTable = db.AssistantsTables.Where(c=> c.AssistantName == name).FirstOrDefault();
            if (assistantsTable == null)
            {
                return NotFound();
            }

            return Ok(assistantsTable);
        }

        // PUT: api/AssistantsTables/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutAssistantsTable(int id, AssistantsTable assistantsTable)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != assistantsTable.Id)
            {
                return BadRequest();
            }

            db.Entry(assistantsTable).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AssistantsTableExists(id))
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

        // POST: api/AssistantsTables
        [ResponseType(typeof(AssistantsTable))]
        public async Task<IHttpActionResult> PostAssistantsTable(AssistantsTable assistantsTable)
        {
            
            db.AssistantsTables.Add(assistantsTable);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = assistantsTable.Id }, assistantsTable);
        }

        // DELETE: api/AssistantsTables/5
        [ResponseType(typeof(AssistantsTable))]
        public async Task<IHttpActionResult> DeleteAssistantsTable(int id)
        {
            AssistantsTable assistantsTable = await db.AssistantsTables.FindAsync(id);
            if (assistantsTable == null)
            {
                return NotFound();
            }

            db.AssistantsTables.Remove(assistantsTable);
            await db.SaveChangesAsync();

            return Ok(assistantsTable);
        }


        [Route("api/AssistantsTables/GetTeams/{data}")]
        [HttpGet]
        public IHttpActionResult GetTeams(string data)
        {
            var dataa = db.AssistantsTables.Where(c => c.AssistantName == data).ToList();
            return Ok(dataa);
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AssistantsTableExists(int id)
        {
            return db.AssistantsTables.Count(e => e.Id == id) > 0;
        }
    }
}