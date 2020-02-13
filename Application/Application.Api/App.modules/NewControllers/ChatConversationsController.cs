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
    public class ChatConversationsController : ApiController
    {
        private ChatAppEntities db = new ChatAppEntities();

        // GET: api/ChatConversations
        public IQueryable<ChatConversation> GetChatConversations()
        {
            return db.ChatConversations;
        }

        // GET: api/ChatConversations/5
        [ResponseType(typeof(ChatConversation))]
        public async Task<IHttpActionResult> GetChatConversation(int id)
        {
            ChatConversation chatConversation = await db.ChatConversations.FindAsync(id);
            if (chatConversation == null)
            {
                return NotFound();
            }

            return Ok(chatConversation);
        }

        // PUT: api/ChatConversations/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutChatConversation(int id, ChatConversation chatConversation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != chatConversation.ID)
            {
                return BadRequest();
            }

            db.Entry(chatConversation).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChatConversationExists(id))
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

        // POST: api/ChatConversations
        [ResponseType(typeof(ChatConversation))]
        public async Task<IHttpActionResult> PostChatConversation(ChatConversation chatConversation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ChatConversations.Add(chatConversation);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = chatConversation.ID }, chatConversation);
        }

        // DELETE: api/ChatConversations/5
        [ResponseType(typeof(ChatConversation))]
        public async Task<IHttpActionResult> DeleteChatConversation(int id)
        {
            ChatConversation chatConversation = await db.ChatConversations.FindAsync(id);
            if (chatConversation == null)
            {
                return NotFound();
            }

            db.ChatConversations.Remove(chatConversation);
            await db.SaveChangesAsync();

            return Ok(chatConversation);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ChatConversationExists(int id)
        {
            return db.ChatConversations.Count(e => e.ID == id) > 0;
        }
    }
}