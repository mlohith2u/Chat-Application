using Application.Bal.PasswordHashing;
using Application.Dal.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web.Http;

namespace Application.Api.App.modules.NewControllers
{
    public class StudentDetailsController : ApiController
    {
        private ChatAppEntities db = new ChatAppEntities();

        [HttpPost]
        public async Task<IHttpActionResult> PostRegistration(tblStudentDetail data)
        {
             var isMobileExist = db.A_U_Management.Any(c => c.PhoneNumber == data.ContactNumber);
            var isEmailExist = db.A_U_Management.Any(c => c.Email == data.Email);
            if (isMobileExist)
            {
                return Ok("2");
            }
            if (isEmailExist)
            {
                return Ok("3");
            }
            var SID = GenerateCID();
            data.Password = PasswordHashingHealper.CreateHash(data.Password);
            A_U_Management det = new A_U_Management
            {
                FullName = data.FullName,
                Email = data.Email,
                PhoneNumber = data.ContactNumber,
                Password = data.Password,
                IsActive = true,
                LastUpdated = DateTime.Now,
                UserRole = 3,
                StudentId = SID
            };
           
            db.A_U_Management.Add(det);
            await db.SaveChangesAsync();

            try
            {
                data.StudentUID = SID;
                data.CreatedOn = DateTime.Now;
                db.tblStudentDetails.Add(data);
                await db.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
            return Ok("0");
        }


        [HttpPost]

        public async Task<IHttpActionResult> PostEmail(tblStudentDetail email)
        {

            tblStudentDetail managementdata = db.tblStudentDetails.Where(c => c.Email == email.Email).FirstOrDefault();
            var userid = managementdata.ID;

            SendMail(email.Email, "Reset Password Link", "http://localhost:4200/resetpassword/" + userid.ToString());


            return Ok();
        }


        [HttpPost]
        public async Task<IHttpActionResult> PostUserInfoforResetpw(tblStudentDetail reset)
        {
            var id = reset.StudentUID;
            A_U_Management data = db.A_U_Management.Where(c => c.StudentId == id).FirstOrDefault();
            data.Password = PasswordHashingHealper.CreateHash(data.Password);
            if (data != null)
            {
                try
                {
                    db.Entry(data).State = System.Data.Entity.EntityState.Modified;
                    await db.SaveChangesAsync();
                }
                catch (Exception e)
                {
                    throw;
                }
            }
            return Ok("1");
        }



        public static void SendMail(string mailTo, string subject, string body)
        {
            try
            {

                string fromMail = "info@srichidtechnologies.com";
                MailMessage message = new MailMessage(fromMail, mailTo, subject, body);
                SmtpClient client = new SmtpClient();
                client.Host = "smtp.gmail.com";

                //System.Net.Mail.Attachment attachment;
                //attachment = new System.Net.Mail.Attachment(@"C:\Users\v-gaguba\Documents\Attachment.txt");
                //message.Attachments.Add(attachment);

                client.Port = 587;
                client.EnableSsl = true;
                client.UseDefaultCredentials = false;
                client.Credentials = new System.Net.NetworkCredential(fromMail, "Srichid@123");
                client.Send(message);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string GenerateCID()
        {
            var OID = "";
            var data = db.A_U_Management.Max(c => c.StudentId);
            if (data != null)
            {
                string digits = new string(data.Where(char.IsDigit).ToArray());
                string letters = new string(data.Where(char.IsLetter).ToArray());
                int number;
                if (!int.TryParse(digits, out number)) //int.Parse would do the job since only digits are selected
                {
                    return null;
                }
                OID = letters + (++number).ToString("D7");
            }
            else
            {
                OID = "CID0000001";
            }
            return OID;
        }
        [HttpGet]
        public async Task<IHttpActionResult> getCourses()
        {
            var data = db.tblCourseMasters.Where(c => c.ID > 5033).ToList();
            return Ok(data);
        }

        [HttpPost]
        public async Task<IHttpActionResult> postStudentCourses(tblStudentCours data)
        {
            try
            {
                data.StartedOn = DateTime.Now;
                db.tblStudentCourses.Add(data);
                db.SaveChanges();
                return Ok("1");
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [HttpPost]
        public async Task<IHttpActionResult> postgetmycourses(tblStudentCours data)
        {
            try
            {
                var response = db.tblStudentCourses.Where(c => c.StudentId == data.StudentId).ToList();
                return Ok(response);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
      
    }
}
