using System;
using System.Collections.Generic;

namespace UpshawP0.Models
{
    public partial class Stores
    {
        public Stores()
        {
            Inventory = new HashSet<Inventory>();
            Orders = new HashSet<Orders>();
        }

        public int StoreId { get; set; }
        public string PhoneNumber { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Street { get; set; }
        public decimal Zip { get; set; }

        public virtual ICollection<Inventory> Inventory { get; set; }
        public virtual ICollection<Orders> Orders { get; set; }
    }
}
