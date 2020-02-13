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
    public class ProductMastersController : ApiController
    {
        private UserMgmtEntities db = new UserMgmtEntities();

        // GET: api/ProductMasters
        public async Task<IHttpActionResult> GetProductMasters()
        {
            var data = db.ProductMasters.ToList();
            return Ok(data);
        }

        // GET: api/ProductMasters/5
        [ResponseType(typeof(ProductMaster))]
        public async Task<IHttpActionResult> GetProductMaster(int id)
        {
            ProductMaster productMaster = await db.ProductMasters.FindAsync(id);
            if (productMaster == null)
            {
                return NotFound();
            }

            return Ok(productMaster);
        }

        // PUT: api/ProductMasters/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutProductMaster( ProductMaster productMaster)
        {
            var id = productMaster.Id;
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != productMaster.Id)
            {
                return BadRequest();
            }

            db.Entry(productMaster).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductMasterExists(id))
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

        // POST: api/ProductMasters
        [ResponseType(typeof(ProductMaster))]
        public async Task<IHttpActionResult> PostProductMaster(ProductMaster productMaster)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ProductMasters.Add(productMaster);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = productMaster.Id }, productMaster);
        }

        // DELETE: api/ProductMasters/5
        [ResponseType(typeof(ProductMaster))]
        public async Task<IHttpActionResult> DeleteProductMaster(int id)
        {
            ProductMaster productMaster = await db.ProductMasters.FindAsync(id);
            if (productMaster == null)
            {
                return NotFound();
            }

            db.ProductMasters.Remove(productMaster);
            await db.SaveChangesAsync();

            return Ok(productMaster);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProductMasterExists(int id)
        {
            return db.ProductMasters.Count(e => e.Id == id) > 0;
        }
    }
}