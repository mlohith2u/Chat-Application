using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using Application.Api.App.modules.ViewModels;
using Application.Dal.DataModel;

namespace Application.Api.App.modules.NewControllers
{
    public class AuditDocumentsController : ApiController
    {
        private UserMgmtEntities db = new UserMgmtEntities();

        // GET: api/AuditDocuments
        public IQueryable<AuditDocument> GetAuditDocuments()
        {
            return db.AuditDocuments;
        }

        // GET: api/AuditDocuments/5
        [ResponseType(typeof(AuditDocument))]
        public async Task<IHttpActionResult> GetAuditDocument(int id)
        {
            AuditDocument auditDocument = await db.AuditDocuments.FindAsync(id);
            if (auditDocument == null)
            {
                return NotFound();
            }

            return Ok(auditDocument);
        }

        [HttpPost]
        [ResponseType(typeof(TasksTable))]
        public async Task<IHttpActionResult> AuditDocuments(Plan PID)
        {

            List<AuditDocument> at = new List<AuditDocument>();
            try
            {
                var tasks = db.AuditDocuments.Where(c => c.PlanID == PID.auditPlan).ToList();
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
        public async Task<IHttpActionResult> DownloadDocuments(DID ID)
        {
            var path = "";


            AuditDocument auditDocument = await db.AuditDocuments.FindAsync(ID.docid);

            byte[] bytes = auditDocument.DocumentFile;
            //string strPath = System.Web.Hosting.HostingEnvironment.MapPath("~");
            //path = "C:\\Users\\Srichid\\Downloads\\AuditDocs\\" + auditDocument.FileName + "."+auditDocument.FileType;
            path = "C:\\Divya\\audit\\UserManagement + DMS + Workflow + Image Capturing\\25-9-18\\Audit_angular\\audit\\Downloads\\" + auditDocument.FileName + "." + auditDocument.FileType;
            File.WriteAllBytes(path, bytes);
            var obspath = ".\\Downloads\\" + auditDocument.FileName + "." + auditDocument.FileType;
            return Ok(obspath);
        }

        [HttpPost]
        
        public async Task<IHttpActionResult> DeleteDocuments(Plan FN)
        {
            //FileInfo fi = new FileInfo(Server.MapPath("C:\\Divya\\audit\\UserManagement + DMS + Workflow + Image Capturing\\25-9-18\\Audit_angular\\audit\\Downloads\\"+ filename));
            //fi.Delete()
            File.Delete("C:\\Divya\\audit\\UserManagement + DMS + Workflow + Image Capturing\\25-9-18\\Audit_angular\\audit\\Downloads\\" + FN.auditPlan);
            return Ok();
        }

        public IHttpActionResult UploadImage()
        {
            string imageName = null;
            var httpRequest = HttpContext.Current.Request;
            byte[] fileData = null;
            string[] fileName = null;
            string fname = null;
            HttpPostedFile hpf;

            HttpFileCollection hfc = HttpContext.Current.Request.Files;
            for (int iCnt = 0; iCnt <= hfc.Count - 1; iCnt++)
            {
                hpf = hfc[iCnt];
                using (var binaryReader = new BinaryReader(hpf.InputStream))
                {
                    fileData = binaryReader.ReadBytes(hpf.ContentLength);
                    fname = hpf.FileName;
                    fileName = fname.Split('.');
                }
            }

            AuditDocument audio = new AuditDocument
            {
                ID = 0,
                PlanID = httpRequest["PID"],
                DocumentFile = fileData,
                DocumentName = httpRequest["FileName"],
                FileName = fileName[0],
                FileType = fileName[1],
                Remarks = httpRequest["Caption"],
                CreatedOn = DateTime.Now,
                CreatedBy = httpRequest["UserName"],
            };
            //var MenuID = db.MenuCategories.Select(c => c.MenuId).Max();
            //if (MenuID == null)
            //{
            //    var ID = 1001;
            //    audio.MenuId = ID;
            //}
            //else
            //{
            //    audio.MenuId = MenuID + 1;
            //}
            try
            {
                db.AuditDocuments.Add(audio);
                db.SaveChanges();
            }
            catch (Exception e)
            {
                var msg = e.Message;
                throw;
            }
            return Ok("File Uploaded Successfully");
        }

        // PUT: api/AuditDocuments/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutAuditDocument(int id, AuditDocument auditDocument)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != auditDocument.ID)
            {
                return BadRequest();
            }

            db.Entry(auditDocument).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AuditDocumentExists(id))
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

        // POST: api/AuditDocuments
        [ResponseType(typeof(AuditDocument))]
        public async Task<IHttpActionResult> PostAuditDocument(AuditDocument auditDocument)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.AuditDocuments.Add(auditDocument);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = auditDocument.ID }, auditDocument);
        }

        // DELETE: api/AuditDocuments/5
        [ResponseType(typeof(AuditDocument))]
        public async Task<IHttpActionResult> DeleteAuditDocument(int id)
        {
            AuditDocument auditDocument = await db.AuditDocuments.FindAsync(id);
            if (auditDocument == null)
            {
                return NotFound();
            }

            db.AuditDocuments.Remove(auditDocument);
            await db.SaveChangesAsync();

            return Ok(auditDocument);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AuditDocumentExists(int id)
        {
            return db.AuditDocuments.Count(e => e.ID == id) > 0;
        }
    }
}