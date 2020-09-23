using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SQLPractice_Fridge.Models
{
    class FridgeContext : DbContext
    {
        //Constructor for fridgecontext
        public FridgeContext() { }

        protected override void OnConfiguring(DbContextOptionsBuilder options) {    
            options.UseSqlServer("Data Source=LAPTOP-5TFSV06B;Initial Catalog=FridgeDB;Integrated Security=True");
            base.OnConfiguring(options);
            }

        public DbSet<Fridge> Fridge { get; set; }
        public DbSet<FridgeItem> FridgeItem { get; set; }
        public DbSet<FridgeShelf> FridgeShelf { get; set; }
    }
}
