﻿using System;
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
    public class StateMastersController : ApiController
    {
        private srichidacademyEntities db = new srichidacademyEntities();

        // GET: api/StateMasters
        public IQueryable<StateMaster> GetStateMasters()
        {
            return db.StateMasters;
        }

        // GET: api/StateMasters/5
        [ResponseType(typeof(StateMaster))]
        public async Task<IHttpActionResult> GetStateMaster(int id)
        {
            StateMaster stateMaster = await db.StateMasters.FindAsync(id);
            if (stateMaster == null)
            {
                return NotFound();
            }

            return Ok(stateMaster);
        }

        // PUT: api/StateMasters/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutStateMaster( StateMaster stateMaster)
        {
            var id = stateMaster.Id;
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != stateMaster.Id)
            {
                return BadRequest();
            }

            db.Entry(stateMaster).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StateMasterExists(id))
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

        // POST: api/StateMasters
        [ResponseType(typeof(StateMaster))]
        public async Task<IHttpActionResult> PostStateMaster(StateMaster stateMaster)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.StateMasters.Add(stateMaster);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = stateMaster.Id }, stateMaster);
        }

        // DELETE: api/StateMasters/5
        [ResponseType(typeof(StateMaster))]
        public async Task<IHttpActionResult> DeleteStateMaster(int id)
        {
            StateMaster stateMaster = await db.StateMasters.FindAsync(id);
            if (stateMaster == null)
            {
                return NotFound();
            }

            db.StateMasters.Remove(stateMaster);
            await db.SaveChangesAsync();

            return Ok(stateMaster);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool StateMasterExists(int id)
        {
            return db.StateMasters.Count(e => e.Id == id) > 0;
        }
    }
}