using System;
using System.Collections.Generic;

namespace UpshawP0.Models
{
    public partial class Inventory
    {
        public int InventoryId { get; set; }
        public int StoreInventory { get; set; }
        public int ItemInInventory { get; set; }
        public int? ProductCurrentQuantity { get; set; }

        public virtual Products ItemInInventoryNavigation { get; set; }
        public virtual Stores StoreInventoryNavigation { get; set; }
    }
}
