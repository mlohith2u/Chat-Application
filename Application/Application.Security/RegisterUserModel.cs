using System;

namespace Application.Security
{
    public class RegisterUserModel
    {
        public string CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public Nullable<int> DistrictId { get; set; }
        public Nullable<int> CityId { get; set; }
        public Nullable<int> AreaId { get; set; }
        public string ConfirmPassword { get; set; }
        public string MiddleName { get; set; }
        public bool IsActive { get; set; }
        public int UserRole { get; set; }
        public string Address { get; set; }
        public string Pincode { get; set; }
        public bool IsPhoneNumberConfirmed { get; set; }
    }
}
