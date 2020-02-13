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
    public class TaskCommentsController : ApiController
    {
        private UserMgmtEntities db = new UserMgmtEntities();

        // GET: api/TaskComments
        public IQueryable<TaskComment> GetTaskComments()
        {
            return db.TaskComments;
        }

        // GET: api/TaskComments/5
        [ResponseType(typeof(TaskComment))]
        public async Task<IHttpActionResult> GetTaskComment(int id)
        {
            TaskComment taskComment = await db.TaskComments.FindAsync(id);
            if (taskComment == null)
            {
                return NotFound();
            }

            return Ok(taskComment);
        }

        // PUT: api/TaskComments/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutTaskComment(int id, TaskComment taskComment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != taskComment.Id)
            {
                return BadRequest();
            }

            db.Entry(taskComment).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TaskCommentExists(id))
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

        [HttpPost]
        [ResponseType(typeof(TaskComment))]
        public async Task<IHttpActionResult> TaskComments(Plan PID)
        {

            List<TaskComment> at = new List<TaskComment>();
            try
            {
                var comments = db.TaskComments.Where(c => c.AuditPlan == PID.auditPlan ).ToList();
                for (int j = 0; j < comments.Count; j++)
                {
                    at.Add(comments[j]);
                }


            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Ok(at);
        }

        // POST: api/TaskComments
        [ResponseType(typeof(TaskComment))]
        public async Task<IHttpActionResult> PostTaskComment(TaskComment taskComment)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}          
            try
            {
                db.TaskComments.Add(taskComment);
                await db.SaveChangesAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            return CreatedAtRoute("DefaultApi", new { id = taskComment.Id }, taskComment);
        }

        // DELETE: api/TaskComments/5
        [ResponseType(typeof(TaskComment))]
        public async Task<IHttpActionResult> DeleteTaskComment(int id)
        {
            TaskComment taskComment = await db.TaskComments.FindAsync(id);
            if (taskComment == null)
            {
                return NotFound();
            }

            db.TaskComments.Remove(taskComment);
            await db.SaveChangesAsync();

            return Ok(taskComment);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TaskCommentExists(int id)
        {
            return db.TaskComments.Count(e => e.Id == id) > 0;
        }
    }
}