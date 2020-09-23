using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Migrations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SQLPractice_Fridge.Models
{
    class Fridge
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] //Makes the FridgeItem ID an identity 
        public int FridgeId { get; set; }//Primary Key, signifies which shelf is which (shelfID 1==Dairy, 2==Meat, 3==Fruit etc...)
        public string shelfType { get; set; } //Determines what kind of items can be stored on a shelf (ID 1 = Dairy, ID 2 = Meat etc...)
        public int shelfCapacity { get; set; }//Every shelf can only store so much stuff 
        //By creating FridgeShelf, we can store MANY items on ONE shelves (because each shelf is for a single type of item)
        //public List<FridgeItem> shelfInventory { get; set; } 
    }
}
