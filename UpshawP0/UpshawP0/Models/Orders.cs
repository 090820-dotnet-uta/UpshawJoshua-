using System;
using System.Collections.Generic;

namespace UpshawP0.Models
{
    public partial class Orders
    {
        public int Pk { get; set; }
        public int OrderId { get; set; }
        public int OrderedProduct { get; set; }
        public int? StoreOrderedFrom { get; set; }
        public int WhoOrdered { get; set; }
        public int OrderedProductAmount { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal OrderTotal { get; set; }

        public virtual Products OrderedProductNavigation { get; set; }
        public virtual Stores StoreOrderedFromNavigation { get; set; }
        public virtual Customers WhoOrderedNavigation { get; set; }
    }
}
