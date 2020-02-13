using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Bal.Viewmodels
{
    public class Message
    {
        public class Messages
        {
            public string clientuniqueid { get; set; }
            public string type { get; set; }
            public string message { get; set; }
            public DateTime date { get; set; }
            public string FromUser { get; set; }
            public string ToUser { get; set; }

        }
    }
}
