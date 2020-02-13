using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Application.Api.App.modules.ViewModels;
using Application.Dal.DataModel;
using Application.Security.PasswordHashing;

namespace Application.Api.App.modules.Manageuser.Controllers
{
    public class AuManagementController : ApiController
    {
        private readonly srichidacademyEntities db = new srichidacademyEntities();

        // GET: api/A_U_Management
        public List<A_U_Management> GetA_U_Management()
        {
            List<A_U_Management> list = new List<A_U_Management>();
            var data = db.A_U_Management.Where(c => c.CustomerId.Substring(0, 3) == "STF").ToList();
            foreach (var item in data)
            {
                var dataa = new A_U_Management
                {
                    UserID = item.UserID,
                    FirstName = item.FirstName,
                    MiddleName = item.MiddleName,
                    LastName = item.LastName,
                    UserName = item.UserName,
                    Password = item.Password,
                    ConfirmPassword = item.ConfirmPassword,
                    Email = item.Email,
                    PhoneNumber = item.PhoneNumber,
                    UserRole = item.UserRole,
                    RoleName = db.A_U_RoleMaster.Where(c => c.RoleID == item.UserRole).Select(c => c.RoleName).FirstOrDefault(),
                    IsActive = item.IsActive,
                    LastUpdated = item.LastUpdated,
                    IsPhoneNumberConfirmed = item.IsPhoneNumberConfirmed,
                    District = item.District,
                    DistrictName = db.DistrictMasters.Where(c=>c.Id == item.District).Select(c=>c.DistrictName).FirstOrDefault(),
                    AreaId = item.AreaId,
                    AreaName = db.AreaMasters.Where(c => c.Id == item.AreaId).Select(c => c.Area).FirstOrDefault(),
                };
                list.Add(dataa);
            }
            return list;

            //var userdata = db.A_U_Management.ToList();

            //foreach (var data in userdata)
            //{
            //    UserList ulist = new UserList
            //    {
            //        UserID = data.UserID,
            //        FirstName = data.FirstName,

            //    };
            //}


            //return Ok(ulist);
        }
        
        // GET: api/A_U_Management/5
       // [ResponseType(typeof(A_U_Management))]
        public async Task<IHttpActionResult> GetA_U_Management(int id)
        {

            A_U_Management aUManagement = await db.A_U_Management.FindAsync(id);
            if (aUManagement == null)
            {
                return NotFound();
            }
            
                UserData udata = new UserData
                {
                    userID = aUManagement.UserID,
                    firstName = aUManagement.FirstName,
                    middleName = aUManagement.MiddleName,
                    lastName = aUManagement.LastName,
                    userName = aUManagement.UserName,
                    password = aUManagement.Password,
                    confirmPassword = aUManagement.ConfirmPassword,
                    email = aUManagement.Email,
                    phoneNumber = aUManagement.PhoneNumber,
                    userRole = aUManagement.UserRole,
                    isActive = aUManagement.IsActive,
                    lastUpdated = aUManagement.LastUpdated,
                    isPhoneNumberConfirmed = aUManagement.IsPhoneNumberConfirmed,
                    district = aUManagement.District.ToString(),
                    AreaId = aUManagement.AreaId,
                };
            

            return Ok(udata);
        }

        // PUT: api/A_U_Management/5
        [ResponseType(typeof(Boolean))]
        public async Task<IHttpActionResult> PutA_U_Management(A_U_Management aUManagement)
        {
            var id = aUManagement.UserID;
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != aUManagement.UserID)
            {
                return BadRequest();
            }

            db.Entry(aUManagement).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!A_U_ManagementExists(id))
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

        // POST: api/A_U_Management
        [ResponseType(typeof(A_U_Management))]
        public async Task<IHttpActionResult> PostA_U_Management(A_U_Management aUManagement)
        {
            aUManagement.Password = SecurePasswordHasher.Hash(aUManagement.Password);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            db.A_U_Management.Add(aUManagement);
            db.SaveChanges();

            string fileplan = DateTime.Today.Year + "/" + DateTime.Today.Month + "/" + DateTime.Today.Day + "/" + aUManagement.UserID;
            A_U_Files pfd = new A_U_Files
            {
                FileName = fileplan,
                UserID = aUManagement.UserID,
                CreatedBy = 1025,
                FileDescription = fileplan,
                CreatedOn = DateTime.Now
            };
            db.A_U_Files.Add(pfd);
            db.SaveChanges();

            var FilePlanDetails = db.A_U_Files.Where(c => c.UserID == aUManagement.UserID).FirstOrDefault();
            if (FilePlanDetails != null)
            {
                string[] name = { "Scanned Documnets", "Bill Payments", "Prescriptions" };
                string[] desc = { "Scanned Documents like X-RAY, ECG and etc", "Bills and Payments", "Prescription Files From Doctor" };

                for (int i = 0; i < 3; i++)
                {
                    A_U_Folders pfcd = new A_U_Folders
                    {
                        FileID = FilePlanDetails.ID,
                        FolderName = name[i],
                        FolderDescription = desc[i],
                        CreatedBy = 1025,
                        CreatedOn = DateTime.Now
                    };
                    try
                    {
                        db.A_U_Folders.Add(pfcd);
                        db.SaveChanges();
                    }
                    catch (Exception e)
                    {
                        var msg = e.Message;
                    }
                }
            }
            return CreatedAtRoute("DefaultApi", new { id = aUManagement.UserID }, aUManagement);
        }

        [HttpPost]
        public IHttpActionResult SaveUser(A_U_Management data)
        {
            data.CustomerId = GenerateStaffId();
            data.Password = SecurePasswordHasher.Hash(data.Password);
            data.LastUpdated = DateTime.Now;
            data.IsActive = true;
            data.IsPhoneNumberConfirmed = true;
            db.A_U_Management.Add(data);
            db.SaveChanges();
            return Ok("1");
        }

        public string GenerateStaffId()
        {
            var OID = "";
            var aa = db.A_U_Management.Where(c => c.CustomerId.Substring(0, 3) == "STF").ToList();
            var data = aa.Max(c => c.CustomerId);
            if (data != null)
            {
                string digits = new string(data.Where(char.IsDigit).ToArray());
                string letters = new string(data.Where(char.IsLetter).ToArray());
                int number;
                if (!int.TryParse(digits, out number)) //int.Parse would do the job since only digits are selected
                {
                    return null;
                }
                OID = letters + (++number).ToString("D4");
            }
            else
            {
                //OID = "CID0000001";
                OID = "STF0001";
            }
            return OID;
        }

        // DELETE: api/A_U_Management/5
        [ResponseType(typeof(A_U_Management))]
        public async Task<IHttpActionResult> DeleteA_U_Management(int id)
        {
            A_U_Management aUManagement = await db.A_U_Management.FindAsync(id);
            if (aUManagement == null)
            {
                return NotFound();
            }

            db.A_U_Management.Remove(aUManagement);
            await db.SaveChangesAsync();

            return Ok(aUManagement);
        }

        //[HttpPost]
        //public async Task<IHttpActionResult> GetEmail(Email email)
        //{

        //    A_U_Management managementdata = db.A_U_Management.Where(c => c.Email == email.UserEmail).FirstOrDefault();

        //    var userid = managementdata.UserID;

        //    SendEMail.SendMail(email.UserEmail, "Reset Password Link", "http://localhost:18500/#/resetpsw?userid=" + userid);


        //    return Ok();
        //}

        [HttpGet]
        public List<CustomerRegistration> GetCustomers()
        {
            List<CustomerRegistration> list = new List<CustomerRegistration>();
            var data = db.CustomerRegistrations.ToList();
            foreach (var item in data)
            {
                var dataa = new CustomerRegistration
                {
                    CustomerId = item.CustomerId,
                    FirstName = item.FirstName,
                    LastName = item.LastName,
                    Email = item.Email,
                    MobileNumber = item.MobileNumber,
                    LastUpdated = item.LastUpdated,
                    DistrictId = item.DistrictId,
                    DistrictName = db.DistrictMasters.Where(c => c.Id == item.DistrictId).Select(c => c.DistrictName).FirstOrDefault(),
                    AreaId = item.AreaId,
                    AreaName = db.AreaMasters.Where(c => c.Id == item.AreaId).Select(c => c.Area).FirstOrDefault(),
                    Address = item.Address,
                    Pincode = item.Pincode, 
                    //Products = db.
                };
                list.Add(dataa);
            }
            return list;
        }

        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutUserInfoforResetpw(ResetPassword reset)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            A_U_Management data = db.A_U_Management.Where(c => c.UserID == reset.userId).FirstOrDefault();

            data.Password = SecurePasswordHasher.Hash(reset.Password);
            data.ConfirmPassword = reset.ConfirmPassword;

            db.Entry(data).State = EntityState.Modified;
            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserInformationforpwExists(reset.userId))
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

        public async Task<IHttpActionResult> PutUserInfo(UserInfo passwordchange)
        {
            var info = db.A_U_Management.Where(c => c.UserID == passwordchange.UserID).FirstOrDefault();

            info.UserName = passwordchange.UserName;
            info.Password = SecurePasswordHasher.Hash(passwordchange.Password);
            info.ConfirmPassword = passwordchange.ConfirmPassword;

            db.Entry(info).State = EntityState.Modified;
            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserInformationforpwExists(passwordchange.UserID))
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
        private bool UserInformationforpwExists(int id)
        {
            return db.A_U_Management.Count(e => e.UserID == id) > 0;
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool A_U_ManagementExists(int id)
        {
            return db.A_U_Management.Count(e => e.UserID == id) > 0;
        }

        [HttpGet]
        public IHttpActionResult GetUserDetails(string id)
        {
            var data = db.A_U_Management.Where(c => c.CustomerId == id).FirstOrDefault();
            return Ok(data);
        }

        [HttpPut]
        public IHttpActionResult PutUser(A_U_Management aa)
        {
            var bb = db.A_U_Management.Where(c => c.UserID == aa.UserID).FirstOrDefault();
            if (bb!=null)
            {
                bb.FirstName = aa.FirstName;
                bb.LastName = aa.LastName;
                bb.PhoneNumber = aa.PhoneNumber;
                bb.Email = aa.Email;

                db.Entry(bb).State = EntityState.Modified;
                db.SaveChangesAsync();
                return Ok("1");
            }
            else
            {
                return Ok();
            }       
        }

        [HttpPut]
        public IHttpActionResult Updatepassword(ResetPassword aa)
        {
            var bb = db.A_U_Management.Where(c => c.CustomerId == aa.CId).FirstOrDefault();
            if (bb != null)
            {
                bb.Password = SecurePasswordHasher.Hash(aa.Password);
                bb.ConfirmPassword = aa.ConfirmPassword;
                db.Entry(bb).State = EntityState.Modified;
                db.SaveChangesAsync();
                return Ok("1");
            }
            else
            {
                return Ok();
            }
        }
    }

    public class ResetPassword
    {
        public string CId { get; set; }
        public int userId { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
    public class UserInfo
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }

    public class UserList
    {
        public int UserID { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public Nullable<int> UserRole { get; set; }
        public bool IsActive { get; set; }
        public Nullable<System.DateTime> LastUpdated { get; set; }
        public Nullable<bool> IsPhoneNumberConfirmed { get; set; }
        public string District { get; set; }
    }
}