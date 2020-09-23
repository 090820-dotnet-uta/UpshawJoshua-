using System;
using System.Collections.Generic;

namespace UpshawP0.Models
{
    public partial class Customers
    {
        public Customers()
        {
            Orders = new HashSet<Orders>();
        }

        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Pword { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Street { get; set; }
        public decimal Zip { get; set; }
        public string AptNum { get; set; }
        public int DefaultStore { get; set; }

        public virtual ICollection<Orders> Orders { get; set; }
    }
}
