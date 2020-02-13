using System;
using System.Data.Entity.Infrastructure;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using Application.Dal.DataModel;
using Application.Security.PasswordHashing;
using Newtonsoft.Json;

namespace Application.Security
{
    public class SecurityInfo
    {
        private ChatAppEntities db = new ChatAppEntities();
        public SecurityInfo()
        {
        }
        public bool IsSucceed { get; set; }
        internal SecurityInfo CreateUserAsync(RegisterUserModel model, ChatAppEntities db, SecurityInfo info)
        {
            var CID = "";
            A_U_Management user = new A_U_Management
            {
                //LastName = model.LastName,
                //FirstName = model.FirstName,
                ConfirmPassword = model.Password,
                FullName = model.FirstName,
                Email = model.Email,
                //MiddleName = model.MiddleName,
                PhoneNumber = model.PhoneNumber,
                //AreaId = model.AreaId,
                LastUpdated = DateTime.Now,
                Password = SecurePasswordHasher.Hash(model.Password),
                //UserName = model.UserName,
                UserRole = 40,
                //IsPhoneNumberConfirmed = true,
                IsActive = true,
                //CustomerId = CID
            };

            tblStudentDetail aa = new tblStudentDetail
            {
                Address = model.Address,
                //AreaId = model.AreaId,
                //CityId = model.CityId,
                //DistrictId = model.DistrictId,
                //CustomerId = CID,
                Email = model.Email,
                //MobileNumber = model.PhoneNumber,
                //FirstName = model.FirstName,
                //CustomerName = model.FirstName,
                //LastName = model.LastName,
                //Pincode = model.Pincode,
                //LastUpdated = DateTime.Now,
            };

            try
            {
                //db.tblStudentDetail.Add(aa);
                db.A_U_Management.Add(user);
                int status = db.SaveChanges();
                if (status == 1)
                { info.IsSucceed = true; }
            }
            catch (DbUpdateConcurrencyException ex)
            {
                var msg = ex.Message;
                throw;
            }
            return info;
        }

    

        public string GenerateId()
        {
            return Guid.NewGuid().ToString("N");
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }



        internal A_U_Management FinduserByuseridandpassword(string uname, string pwd, ChatAppEntities Db)
        {
            A_U_Management users = Db.A_U_Management.FirstOrDefault(c => c.Email == uname && c.ConfirmPassword == pwd);
            return users;
        }

        //public string GenerateCID()
        //{
        //    var OID = "";
        //    var data = db.CustomerRegistrations.Max(c => c.CustomerId);
        //    if (data != null)
        //    {
        //        string digits = new string(data.Where(char.IsDigit).ToArray());
        //        string letters = new string(data.Where(char.IsLetter).ToArray());
        //        int number;
        //        if (!int.TryParse(digits, out number)) //int.Parse would do the job since only digits are selected
        //        {
        //            return null;
        //        }
        //        OID = letters + (++number).ToString("D7");
        //    }
        //    else
        //    {
        //        OID = "CID0000001";
        //    }
        //    return OID;
        //}

        
    }
}