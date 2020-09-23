﻿using System;
using System.Collections.Generic;

namespace UpshawP0.Models
{
    public partial class Products
    {
        public Products()
        {
            Inventory = new HashSet<Inventory>();
            Orders = new HashSet<Orders>();
        }

        public int Skunum { get; set; }
        public string ProductName { get; set; }
        public string ProductDescrip { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal ProductDiscount { get; set; }
        public bool IsInBundle { get; set; }
        public bool IsBundle { get; set; }
        public int BundleId { get; set; }

        public Products(decimal price, decimal discount)
        {
            Skunum = 90;
            ProductName = "Thing";
            ProductDescrip = "Thing thing";
            UnitPrice = price;
            ProductDiscount = discount;
            IsBundle = false;
            IsInBundle = false;
            BundleId = 0;
        }
        public virtual ICollection<Inventory> Inventory { get; set; }
        public virtual ICollection<Orders> Orders { get; set; }
    }
}