using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Migrations;
using System.ComponentModel.DataAnnotations;

namespace SQLPractice_Fridge.Models
{
    class FridgeShelf
    {
        public int FridgeShelfId { get; set; } //Foreign key that refers to the shelfId(corresponds to what kind of item can be stored there) 
        public int FridgeItemId { get; set; } //Foreign key that refers to the item id (which corresponds to what the item is)
    }
}
