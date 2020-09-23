using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Migrations;
using SQLPractice_Fridge.Models;

namespace SQLPractice_Fridge
{
    class Program
    {

        static void Main(string[] args)
        {
            //addShelfToFridge();
            using (var context = new FridgeContext())
            {
                var newItem = new FridgeItem();
                addItemToFridge(newItem);
                context.FridgeItem.Add(newItem);
                context.SaveChanges();
                Console.WriteLine("Item added to the fridge!");
            }
        }//end of main 

        public static FridgeItem addItemToFridge(FridgeItem newitem)
        {
            using (var item = new FridgeContext())
            {
                string strtester;
                int inttester;
                Console.WriteLine("adding a new item to the fridge...");
                do
                {
                    Console.WriteLine("what's the name of the item you're adding?");
                    strtester = Console.ReadLine();
                    //make sure that the user entry isnt null and isnt a number
                    if (int.TryParse(strtester, out inttester)) { Console.WriteLine("invalid entry, please retry!"); }
                    //create new item name otherwise
                    else { newitem.itemName = strtester; }
                } while (int.TryParse(strtester, out inttester) || strtester == null);
                do
                {
                    Console.WriteLine("how many of that item are you storing?");
                    strtester = Console.ReadLine();
                    //make sure that the user entry isnt null and is a number
                    if (!int.TryParse(strtester, out inttester)) { Console.WriteLine("invalid entry, please retry!"); }
                    //create new fridge item count otherwise
                    else { newitem.itemCount = inttester; }
                } while (!int.TryParse(strtester, out inttester) || strtester == null);
                do
                {
                    Console.WriteLine("what kind of item are you adding?");
                    strtester = Console.ReadLine();
                    //make sure that the user entry isnt null and isnt a number
                    if (int.TryParse(strtester, out inttester)) { Console.WriteLine("invalid entry, please retry!"); }
                    //add item type to new fridge item otherwise
                    else { newitem.itemType = strtester; }
                } while (int.TryParse(strtester, out inttester) || strtester == null);
                return newitem;

            }//end of using loop
        } //end additem func
        void addShelfToFridge()
        {
            using(var context = new FridgeContext())
            {
       
            }
        }

    }//end of program class

    
}//end of namespace
