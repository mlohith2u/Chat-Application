using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.IO;
using System.Threading.Tasks;
using Application.Dal.DataModel;

namespace TabBanking.API.Controllers.DocumentUpload
{
    public class FileUploadController : ApiController
    {
        srichidacademyEntities db = new srichidacademyEntities();
        [HttpPost()]
        public string UploadSpecimensignature([FromUri(Name = "id")]string id)
        {
            var data = id.Split(',');
            int iUploadedCnt = 0;
            byte[] fileData = null;
            
            string sPath = "";
            sPath = System.Web.Hosting.HostingEnvironment.MapPath("~/locker/");

            System.Web.HttpFileCollection hfc = System.Web.HttpContext.Current.Request.Files;

            //// CHECK THE FILE COUNT.
            //for (int iCnt = 0; iCnt <= hfc.Count - 1; iCnt++)
            //{
                System.Web.HttpPostedFile hpf = hfc[0];
                using (var binaryReader = new BinaryReader(hpf.InputStream))
                {
                    fileData = binaryReader.ReadBytes(hpf.ContentLength);
                }
                if (fileData.Length > 0)
                {
                    A_U_Documents doc = new A_U_Documents()
                    {
                        CreatedBy = Convert.ToInt32(data[0]),
                        CreatedOn = DateTime.Now,
                        DocumentData = fileData,
                        DocumentName = data[3],
                        DocumentSize = Convert.ToInt32(data[4]),
                        DocumentType = data[5],
                        FileID = Convert.ToInt32(data[1]),
                        FolderID = Convert.ToInt32(data[2]),
                        UserID = Convert.ToInt32(data[0])
                    };
                    db.A_U_Documents.Add(doc);
                    try
                    {
                        db.SaveChanges();
                    }
                    catch (Exception e)
                    {
                        var msg = e.Message;
                        throw;
                    }
                }
            //}
            if (iUploadedCnt > 0)
            {
                return iUploadedCnt + " Files Uploaded Successfully";
            }
            else
            {
                return "Files Uploaded Successfully";
            }
        }
    }
}
