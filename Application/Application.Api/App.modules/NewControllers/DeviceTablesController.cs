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
    public class DeviceTablesController : ApiController
    {
        private UserMgmtEntities db = new UserMgmtEntities();

        // GET: api/DeviceTables
        public IQueryable<DeviceTable> GetDeviceTables()
        {
            return db.DeviceTables;
        }

        // GET: api/DeviceTables/5
        [ResponseType(typeof(DeviceTable))]
        public async Task<IHttpActionResult> GetDeviceTable(int id)
        {
            DeviceTable deviceTable = await db.DeviceTables.FindAsync(id);
            if (deviceTable == null)
            {
                return NotFound();
            }

            return Ok(deviceTable);
        }

        // PUT: api/DeviceTables/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutDeviceTable(DeviceTable deviceTable)
        {
            var id = deviceTable.ID;
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != deviceTable.ID)
            {
                return BadRequest();
            }

            db.Entry(deviceTable).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DeviceTableExists(id))
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

        // POST: api/DeviceTables
        [ResponseType(typeof(DeviceTable))]
        public async Task<IHttpActionResult> PostDeviceTable(DeviceTable deviceTable)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.DeviceTables.Add(deviceTable);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = deviceTable.ID }, deviceTable);
        }

        // DELETE: api/DeviceTables/5
        [ResponseType(typeof(DeviceTable))]
        public async Task<IHttpActionResult> DeleteDeviceTable(int id)
        {
            DeviceTable deviceTable = await db.DeviceTables.FindAsync(id);
            if (deviceTable == null)
            {
                return NotFound();
            }

            db.DeviceTables.Remove(deviceTable);
            await db.SaveChangesAsync();

            return Ok(deviceTable);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DeviceTableExists(int id)
        {
            return db.DeviceTables.Count(e => e.ID == id) > 0;
        }
    }
}