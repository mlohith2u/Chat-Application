using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Application.Api.App.modules.ViewModels
{
    public class UserData
    {
        public int userID { get; set; }
        public string firstName { get; set; }
        public string middleName { get; set; }
        public string lastName { get; set; }
        public string userName { get; set; }
        public string password { get; set; }
        public string confirmPassword { get; set; }
        public string email { get; set; }
        public string phoneNumber { get; set; }
        public Nullable<int> userRole { get; set; }
        public bool isActive { get; set; }
        public Nullable<System.DateTime> lastUpdated { get; set; }
        public Nullable<bool> isPhoneNumberConfirmed { get; set; }
        public string district { get; set; }
        public Nullable<int> AreaId { get; set; }
    }
}