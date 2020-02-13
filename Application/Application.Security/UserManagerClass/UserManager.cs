using System;
using System.Linq;
using System.Threading.Tasks;
using Application.Bal.PasswordHashing;
using Application.Dal.DataModel;
using Application.Security.PasswordHashing;
using Application.Security.UserManagerInterface;
namespace Application.Security.UserManagerClass
{
    public class UserManager : IUserManager, IDisposable
    {
        readonly ChatAppEntities _db;
        readonly SecurityInfo _info;
        public UserManager()
        {
            _db = new ChatAppEntities();
            _info = new SecurityInfo();
        }

        public SecurityInfo Login(LoginUserModel model)
        {
            throw new NotImplementedException();
        }

        public SecurityInfo Register(RegisterUserModel model)
        {
            return _info.CreateUserAsync(model, _db, _info);
        }
        public bool FindUserbyUserId(string userid)
        {
            throw new NotImplementedException();
        }

        public bool FindUserbyEmailId(string emailid)
        {
            throw new NotImplementedException();
        }

        public bool FindUserbyMobileNumber(string mobilenumber)
        {
            throw new NotImplementedException();
        }

        public bool ChangePasswordusingemail(string emailid)
        {
            throw new NotImplementedException();
        }

        public bool ChangePasswordusingMobile(string mobilenumber)
        {
            throw new NotImplementedException();
        }

        public bool ChangePasswordusingLogin(string userid)
        {
            throw new NotImplementedException();
        }

        public LogginDetails GetLogindetails(string userid)
        {
            throw new NotImplementedException();
        }

        public string ConvertPasswordtohash(string password)
        {
            throw new NotImplementedException();
        }

        public string Converthashtopassword(string hashpassword)
        {
            throw new NotImplementedException();
        }

        //public UserDetails LoggedinUserDetails(string userid)
        //{
        //    throw new NotImplementedException();
        //}

        public bool ChangeEmailId(string emailid)
        {
            throw new NotImplementedException();
        }

        public bool VerifyEmailId(string emailid)
        {
            throw new NotImplementedException();
        }

        public bool ChangeMobileNumber(string mobilenumber)
        {
            throw new NotImplementedException();
        }

        public bool VerifyMobileNumber(string mobilenumber)
        {
            throw new NotImplementedException();
        }

        public bool LockUserAccount(UserLockDetails userid)
        {
            throw new NotImplementedException();
        }

        public bool UnLockUserAccount(UserLockDetails userid)
        {
            throw new NotImplementedException();
        }


        SecurityInfo IUserManager.Register(RegisterUserModel model)
        {
            throw new NotImplementedException();
        }

        public Task<A_U_Token> FindRefreshToken(string hashedTokenId)
        {
            throw new NotImplementedException();
        }

        public bool RemoveRefreshToken(string hashedTokenId)
        {
            var token = _db.A_U_Token.FirstOrDefault(c => c.ID == hashedTokenId);

            _db.A_U_Token.Remove(token);
            _db.SaveChanges();
            return true;
        }

        public bool AddRefreshToken(A_U_Token token)
        {
            _db.A_U_Token.Add(token);
            _db.SaveChanges();
            return true;
        }

        public  A_U_Management FindUser(string uid, string pwd)
        {
            var isTrue = false;
            var dataToView = new A_U_Management();
            var hasedValue = _db.A_U_Management.Where(c => c.Email == uid).FirstOrDefault();
            var operatorValue = _db.A_U_Management.FirstOrDefault(c => c.Email == uid);

            if (hasedValue != null)
            {
                isTrue = PasswordHashingHealper.ValidatePassword(pwd, operatorValue.Password);
            }
            if (!isTrue) return dataToView;
            dataToView.FullName = operatorValue.FullName;
            dataToView.Email = operatorValue.Email;
            dataToView.StudentId = Convert.ToString(operatorValue.StudentId);
            dataToView.UserRole = operatorValue.UserRole;
            if (isTrue)
            {
                dataToView.IsActive = true;

            }
            if (operatorValue != null) dataToView.StudentId = operatorValue.StudentId;
            return dataToView;
        }

        public A_U_Client FindClient(string clientId)
        {
            var client = _db.A_U_Client.Find(clientId);
            return client;
        }

        public void Dispose()
        {
        }

        public string GetRole(A_U_Management user)
        {
            int roleid = Convert.ToInt32(user.UserRole);
            return _db.tblRoleMasters.Where(c => c.ID == roleid).Select(c => c.Role).FirstOrDefault();
        }
    }
}
