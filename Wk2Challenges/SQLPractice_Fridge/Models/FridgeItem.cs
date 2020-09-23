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
    class FridgeItem
    {
        
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] //Makes the FridgeItem ID an identity 
        public int FridgeItemId { get; set; } //primary key
        public int itemCount { get; set; } //Number of each item
        public string itemType { get; set; }//type of food 
        public string itemName { get; set; }//Name of item

        public FridgeItem()
        {
            itemCount = 1;
            itemType = "Misc";
            itemName = "Unknown";
        }
        public FridgeItem(int Count, string Type, string Name)
        {
            itemCount = Count;
            itemType = Type;
            itemName = Name;
        }
        public FridgeItem(string Type, string Name)
        {
            itemCount = 1;
            itemType = Type;
            itemName = Name;
        }
        public FridgeItem(int Count, string Name)
        {
            itemCount = Count;
            itemType = "Misc";
            itemName = Name;
        }
        public FridgeItem(string Type, int Count)
        {
            itemCount = Count;
            itemType = Type;
            itemName = "Unknown";
        }

        //FridgeItem addItemToFridge(FridgeItem newItem)
        //{
        //    using (var item = new FridgeContext())
        //    {
        //        string strTester;
        //        int intTester;
        //        Console.WriteLine("Adding a new item to the fridge...");
        //        do
        //        {
        //            Console.WriteLine("What's the name of the item you're adding?");
        //            strTester = Console.ReadLine();
        //            //Make sure that the user entry isnt null and isnt a number
        //            if (int.TryParse(strTester, out intTester)) { Console.WriteLine("Invalid Entry, please retry!"); }
        //            //create new item name otherwise
        //            else { newItem.itemName = strTester; }
        //        } while (int.TryParse(strTester, out intTester) || strTester == null);
        //        do
        //        {
        //            Console.WriteLine("How many of that item are you storing?");
        //            strTester = Console.ReadLine();
        //            //Make sure that the user entry isnt null and is a number
        //            if (!int.TryParse(strTester, out intTester)) { Console.WriteLine("Invalid Entry, please retry!"); }
        //            //create new fridge item count otherwise
        //            else { newItem.itemCount = intTester; }
        //        } while (int.TryParse(strTester, out intTester) || strTester == null);
        //        do
        //        {
        //            Console.WriteLine("What kind of item are you adding?");
        //            strTester = Console.ReadLine();
        //            //Make sure that the user entry isnt null and isnt a number
        //            if (int.TryParse(strTester, out intTester)) { Console.WriteLine("Invalid Entry, please retry!"); }
        //            //add item type to new fridge item otherwise
        //            else { newItem.itemType = strTester; }
        //        } while (int.TryParse(strTester, out intTester) || strTester == null);
        //        //Add this newly created fridgeitem to the table and save it there
        //        return newItem;
        //    }//end of using loop
        //}//end addItem func
    }
}
