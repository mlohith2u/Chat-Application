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
    public class AuditCommencementandClosureInfoesController : ApiController
    {
        private UserMgmtEntities db = new UserMgmtEntities();

        // GET: api/AuditCommencementandClosureInfoes
        public IQueryable<AuditCommencementandClosureInfo> GetAuditCommencementandClosureInfoes()
        {
            return db.AuditCommencementandClosureInfoes;
        }

        // GET: api/AuditCommencementandClosureInfoes/5
        [ResponseType(typeof(AuditCommencementandClosureInfo))]
        public async Task<IHttpActionResult> GetAuditCommencementandClosureInfo(int id)
        {
            AuditCommencementandClosureInfo auditCommencementandClosureInfo = await db.AuditCommencementandClosureInfoes.FindAsync(id);
            if (auditCommencementandClosureInfo == null)
            {
                return NotFound();
            }

            return Ok(auditCommencementandClosureInfo);
        }

        // PUT: api/AuditCommencementandClosureInfoes/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutAuditCommencementandClosureInfo(int id, AuditCommencementandClosureInfo auditCommencementandClosureInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != auditCommencementandClosureInfo.ID)
            {
                return BadRequest();
            }

            db.Entry(auditCommencementandClosureInfo).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AuditCommencementandClosureInfoExists(id))
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

        // POST: api/AuditCommencementandClosureInfoes
        [ResponseType(typeof(AuditCommencementandClosureInfo))]
        public async Task<IHttpActionResult> PostAuditCommencementandClosureInfo(AuditCommencementandClosureInfo auditCommencementandClosureInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.AuditCommencementandClosureInfoes.Add(auditCommencementandClosureInfo);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = auditCommencementandClosureInfo.ID }, auditCommencementandClosureInfo);
        }

        // DELETE: api/AuditCommencementandClosureInfoes/5
        [ResponseType(typeof(AuditCommencementandClosureInfo))]
        public async Task<IHttpActionResult> DeleteAuditCommencementandClosureInfo(int id)
        {
            AuditCommencementandClosureInfo auditCommencementandClosureInfo = await db.AuditCommencementandClosureInfoes.FindAsync(id);
            if (auditCommencementandClosureInfo == null)
            {
                return NotFound();
            }

            db.AuditCommencementandClosureInfoes.Remove(auditCommencementandClosureInfo);
            await db.SaveChangesAsync();

            return Ok(auditCommencementandClosureInfo);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AuditCommencementandClosureInfoExists(int id)
        {
            return db.AuditCommencementandClosureInfoes.Count(e => e.ID == id) > 0;
        }
    }
}