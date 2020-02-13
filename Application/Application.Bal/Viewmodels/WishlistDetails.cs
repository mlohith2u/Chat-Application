using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Bal.Viewmodels
{
    public class WishlistDetails
    {
        public int Id { get; set; }
        public string CustomerId { get; set; }
        public string MenuName { get; set; }
        public string MachineId { get; set; }
        public string ItemId { get; set; }
        public Nullable<int> Quantity { get; set; }
        public Nullable<int> RatePerItem { get; set; }
        public Nullable<int> TotalAmount { get; set; }
        public Nullable<bool> IsMovedtoCart { get; set; }
        public Nullable<System.DateTime> LastUpdated { get; set; }
        public byte[] Image { get; set; }
    }
}
