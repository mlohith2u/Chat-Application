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
using Application.Dal.DataModel;

namespace Application.Api.App.modules.Masters
{
    public class CompanyDetailsController : ApiController
    {
        private srichidacademyEntities db = new srichidacademyEntities();

        // GET: api/CompanyDetails
        public IQueryable<CompanyDetail> GetCompanyDetails()
        {
            return db.CompanyDetails;
        }

        // GET: api/CompanyDetails/5
        [ResponseType(typeof(CompanyDetail))]
        public async Task<IHttpActionResult> GetCompanyDetail(int id)
        {
            CompanyDetail companyDetail = await db.CompanyDetails.FindAsync(id);
            if (companyDetail == null)
            {
                return NotFound();
            }

            return Ok(companyDetail);
        }

        // PUT: api/CompanyDetails/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutCompanyDetail(CompanyDetail companyDetail)
        {
            var id = companyDetail.Id;
            db.Entry(companyDetail).State = EntityState.Modified;
            try
            {
                await db.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
            return Ok("1");
        }

        // POST: api/CompanyDetails
        [HttpPost]
        [ResponseType(typeof(CompanyDetail))]
        public async Task<IHttpActionResult> PostCompanyDetail()
        {
            var httpRequest = HttpContext.Current.Request;
            byte[] fileData = null;
            HttpPostedFile hpf;

            HttpFileCollection hfc = HttpContext.Current.Request.Files;
            for (int iCnt = 0; iCnt <= hfc.Count - 1; iCnt++)
            {
                hpf = hfc[iCnt];
                using (var binaryReader = new BinaryReader(hpf.InputStream))
                {
                    fileData = binaryReader.ReadBytes(hpf.ContentLength);
                }
            }
            CompanyDetail aa = new CompanyDetail
            {
                CompanyName = httpRequest["CompanyName"],
                Companylogo = fileData,
                AboutCompany=httpRequest["AboutCompany"],
                Addressone = httpRequest["Addressone"],
                Addresstwo = httpRequest["Addresstwo"],
                Email = httpRequest["Email"],
                Mobile1 = httpRequest["Mobile1"],
                Mobile2 = httpRequest["Mobile2"],
            };
            db.CompanyDetails.Add(aa);
            await db.SaveChangesAsync();

            return Ok("1");
        }

        // DELETE: api/CompanyDetails/5
        [ResponseType(typeof(CompanyDetail))]
        public async Task<IHttpActionResult> DeleteCompanyDetail(int id)
        {
            CompanyDetail companyDetail = await db.CompanyDetails.FindAsync(id);
            if (companyDetail == null)
            {
                return NotFound();
            }

            db.CompanyDetails.Remove(companyDetail);
            await db.SaveChangesAsync();

            return Ok(companyDetail);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CompanyDetailExists(int id)
        {
            return db.CompanyDetails.Count(e => e.Id == id) > 0;
        }
    }
}