using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Xml.Schema;
using UpshawP0.Models;

namespace UpshawP0
{ 
    class Program
    {
        static void Main(string[] args)
        {
            using (var DBcontext = new SGDB2Context())
            {
                int firstMenuChoice;
                int secondMenuChoice;
                Customers CurrentlyLoggedIn = new Customers(); //Create a customer object specifically for whoever is currently logged in 
                StoreMethods storeMethods = new StoreMethods();
                do //First loop for starting login menu
                {
                    storeMethods.MenuAscii();
                    firstMenuChoice = storeMethods.UserMenuChoice();
                    if(firstMenuChoice == 1)
                    {
                        Customers newCust = new Customers();
                        CurrentlyLoggedIn = storeMethods.Login(DBcontext);
                    }
                    else if(firstMenuChoice ==2)
                    {
                        Customers newCust = new Customers();
                        //CustomerAddress newAddress = new CustomerAddress();
                        CurrentlyLoggedIn = storeMethods.SignUpNewCustomer(newCust, DBcontext); //After you sign up you are automatically logged in 
                        //CurrentlyLoggedIn = NewCustomerAddress(DBcontext);
                        DBcontext.Customers.Add(CurrentlyLoggedIn);
                        //DBcontext.CustomerAddress.Add(newAddress);
                        //CurrentlyLoggedIn.CustomerAdd = newAddress.CustAddId;       //TODO GET THE ADDRESS SHIT TO WORK MAYBE (NOT A PRIORITY)!!! Sets the customer's address to be the newly entered address 
                        DBcontext.SaveChanges();
                    }
                    else if(firstMenuChoice == 3)
                    {
                        storeMethods.GoodbyeAscii();
                        break;
                    }
                    do
                    {
                        secondMenuChoice = storeMethods.SecondMenu();
                        if(secondMenuChoice == 1)
                        {
                            storeMethods.RetrieveOrderHistory(CurrentlyLoggedIn, DBcontext);
                        }
                        else if(secondMenuChoice == 2)
                        {
                            storeMethods.SearchForUser(DBcontext);
                        }
                        else if(secondMenuChoice == 3)
                        {
                            storeMethods.GetStoreInventory(DBcontext);
                        }
                        else if (secondMenuChoice == 4)
                        {
                            storeMethods.SetSelectedStore(CurrentlyLoggedIn, DBcontext);
                            DBcontext.SaveChanges();
                        }
                        else if (secondMenuChoice == 5)
                        {
                            storeMethods.PlaceOrders(CurrentlyLoggedIn, DBcontext);
                            DBcontext.SaveChanges();
                        }
                        else if(secondMenuChoice == 6)
                        {
                                break;
                        }
                    } while (secondMenuChoice != 6);
                } while (firstMenuChoice != 3);
            }//End of using dbcontext
        }//End of main
    }//end of class program
} //End of namespace
