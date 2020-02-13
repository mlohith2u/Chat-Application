using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Diagnostics;
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
    public class TasksTablesController : ApiController
    {
        private UserMgmtEntities db = new UserMgmtEntities();

        // GET: api/TasksTables
        public IQueryable<TasksTable> GetTasksTables()
        {
            return db.TasksTables;
        }

        // GET: api/TasksTables/5
        [ResponseType(typeof(TasksTable))]
        public async Task<IHttpActionResult> GetTasksTable(int id)
        {
            TasksTable tasksTable = await db.TasksTables.FindAsync(id);
            if (tasksTable == null)
            {
                return NotFound();
            }

            return Ok(tasksTable);
        }

        [HttpPost]
        [ResponseType(typeof(TasksTable))]
        public async Task<IHttpActionResult> AuditTable(Plan PID)
        {

            List<TasksTable> at = new List<TasksTable>();
            try
            {
                var tasks = db.TasksTables.Where(c => c.AuditPlan == PID.auditPlan).ToList();
                for (int j = 0; j < tasks.Count; j++)
                {
                    at.Add(tasks[j]);
                }


            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Ok(at);
        }


        [HttpPost]
        [ResponseType(typeof(TasksTable))]
        public async Task<IHttpActionResult> AuditPlanTable(PlanTask Plan)
        {

            List<TasksTable> at = new List<TasksTable>();
            try
            {
                var tasks = db.TasksTables.Where(c => c.AuditPlan == Plan.auditPlan && c.Status != "Finnished" && c.AuditorName == Plan.auditorName).ToList();
                for (int j = 0; j < tasks.Count; j++)
                {
                    at.Add(tasks[j]);
                }


            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Ok(at);
        }


        [HttpPost]
        [ResponseType(typeof(TasksTable))]
        public async Task<IHttpActionResult> AuditPlanDetails(TaskDetails Plan)
        {
            TasksTable task;

            try
            {
                task = db.TasksTables.Where(c => c.AuditPlan == Plan.auditPlan && c.TaskName == Plan.taskName && c.AuditorName == Plan.auditorName).FirstOrDefault();
                
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Ok(task);
        }


        // PUT: api/TasksTables/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutTasksTable(TasksTable tasksTable)
        {
            var id = tasksTable.ID;
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tasksTable.ID)
            {
                return BadRequest();
            }

            db.Entry(tasksTable).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TasksTableExists(id))
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

        // POST: api/TasksTables
        [ResponseType(typeof(TasksTable))]
        public async Task<IHttpActionResult> PostTasksTable(TasksTable tasksTable)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TasksTables.Add(tasksTable);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = tasksTable.ID }, tasksTable);
        }

        // DELETE: api/TasksTables/5
        [ResponseType(typeof(TasksTable))]
        public async Task<IHttpActionResult> DeleteTasksTable(int id)
        {
            TasksTable tasksTable = await db.TasksTables.FindAsync(id);
            if (tasksTable == null)
            {
                return NotFound();
            }

            db.TasksTables.Remove(tasksTable);
            await db.SaveChangesAsync();

            return Ok(tasksTable);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TasksTableExists(int id)
        {
            return db.TasksTables.Count(e => e.ID == id) > 0;
        }

        [HttpPost]
        public async Task<IHttpActionResult> WishlistDetails(Details customerWishlistDetail)
        {
            CustomerWishlistDetail WL = new CustomerWishlistDetail();

            var MachineID = GenerateMachineId();
            WL.ItemId = customerWishlistDetail.ItemId;
            WL.Quantity = customerWishlistDetail.Quantity;
            WL.MachineId = MachineID;
            WL.IsMovedtoCart = false;
            WL.LastUpdated = DateTime.Now;
            try

            {
                db.CustomerWishlistDetails.Add(WL);
                db.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }
            var dd = db.CustomerWishlistDetails.Where(c => c.MachineId == MachineID).ToList();
            //return CreatedAtRoute("DefaultApi", new { id = customerWishlistDetail.Id }, customerWishlistDetail);
            return Ok(dd);
        }
        public string GenerateMachineId()
        {
            Process process = new Process();
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = "CMD.exe";
            startInfo.Arguments = "/C wmic csproduct get UUID";
            process.StartInfo = startInfo;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.Start();
            process.WaitForExit();
            string output = process.StandardOutput.ReadToEnd();
            return output;
        }
        public class Details
        {
            public string ItemId { get; set; }
            public int Quantity { get; set; }
        }
    }
}