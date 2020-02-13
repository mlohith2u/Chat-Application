using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Bal.Viewmodels
{
    public class UsersList
    {
        public int UserUID { get; set; }
        public string StudentId { get; set; }
        public string FullName { get; set; }
        public Nullable<bool> LoggedIn { get; set; }
        public Nullable<System.DateTime> LoggedInTime { get; set; }
        public Nullable<System.DateTime> LoggedOutTime { get; set; }
        public string CustomerID { get; set; }
    }
}
