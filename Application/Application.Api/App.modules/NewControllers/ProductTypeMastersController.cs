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
    public class ProductTypeMastersController : ApiController
    {
        private UserMgmtEntities db = new UserMgmtEntities();

        // GET: api/ProductTypeMasters
        public IQueryable<ProductTypeMaster> GetProductTypeMasters()
        {
            return db.ProductTypeMasters;
        }

        // GET: api/ProductTypeMasters/5
        [ResponseType(typeof(ProductTypeMaster))]
        public async Task<IHttpActionResult> GetProductTypeMaster(int id)
        {
            ProductTypeMaster productTypeMaster = await db.ProductTypeMasters.FindAsync(id);
            if (productTypeMaster == null)
            {
                return NotFound();
            }

            return Ok(productTypeMaster);
        }

        // PUT: api/ProductTypeMasters/5
        
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutProductTypeMaster(ProductTypeMaster productTypeMaster)
        {
            var id = productTypeMaster.ID;
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != productTypeMaster.ID)
            {
                return BadRequest();
            }

            db.Entry(productTypeMaster).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductTypeMasterExists(id))
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

        // POST: api/ProductTypeMasters
        [ResponseType(typeof(ProductTypeMaster))]
        public async Task<IHttpActionResult> PostProductTypeMaster(ProductTypeMaster productTypeMaster)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ProductTypeMasters.Add(productTypeMaster);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = productTypeMaster.ID }, productTypeMaster);
        }

        // DELETE: api/ProductTypeMasters/5
        [ResponseType(typeof(ProductTypeMaster))]
        public async Task<IHttpActionResult> DeleteProductTypeMaster(int id)
        {
            ProductTypeMaster productTypeMaster = await db.ProductTypeMasters.FindAsync(id);
            if (productTypeMaster == null)
            {
                return NotFound();
            }

            db.ProductTypeMasters.Remove(productTypeMaster);
            await db.SaveChangesAsync();

            return Ok(productTypeMaster);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProductTypeMasterExists(int id)
        {
            return db.ProductTypeMasters.Count(e => e.ID == id) > 0;
        }
    }
}