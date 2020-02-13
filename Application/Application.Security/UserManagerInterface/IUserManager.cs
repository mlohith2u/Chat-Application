namespace Application.Security.UserManagerInterface
{
    interface IUserManager
    {
        bool ChangeEmailId(string emailid);
        bool ChangeMobileNumber(string mobilenumber);
        bool ChangePasswordusingemail(string emailid);
        bool ChangePasswordusingLogin(string userid);
        bool ChangePasswordusingMobile(string mobilenumber);
        string Converthashtopassword(string hashpassword);
        string ConvertPasswordtohash(string password);
        bool FindUserbyEmailId(string emailid);
        bool FindUserbyMobileNumber(string mobilenumber);
        bool FindUserbyUserId(string userid);
        LogginDetails GetLogindetails(string userid);
        bool LockUserAccount(UserLockDetails userid);
        //UserDetails LoggedinUserDetails(string userid);
        SecurityInfo Login(LoginUserModel model);
        SecurityInfo Register(RegisterUserModel model);
        bool UnLockUserAccount(UserLockDetails userid);
        bool VerifyEmailId(string emailid);
        bool VerifyMobileNumber(string mobilenumber);
    }
}
