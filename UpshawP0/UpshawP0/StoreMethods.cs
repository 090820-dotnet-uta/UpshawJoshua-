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
    public class StoreMethods
    {
        //Menu Ascii display 
        /// <summary>
        /// Prints out the ascii for the store because aesthetic matters
        /// </summary>
        public  void MenuAscii()
        {
            string ascii = @"
 (                                                                           
 )\ ) (                    )    )                 (                          
(()/( )\   )   (  (  (  ( /( ( /(    (  (     )   )\ )      )    )     (     
 /(_)|(_| /(  ))\ )\))( )\()))\())(  )( )\ ( /(  (()/(   ( /(   (     ))\(   
(_))  _ )(_))/((_|(_))\((_)\(_))/ )\(()((_))(_))  /(_))_ )(_))  )\  '/((_)\  
/ __|| ((_)_(_))( (()(_) |(_) |_ ((_)((_|_|(_)_  (_)) __((_)_ _((_))(_))((_) 
\__ \| / _` | || / _` || ' \|  _/ _ \ '_| / _` |   | (_ / _` | '  \() -_|_-< 
|___/|_\__,_|\_,_\__, ||_||_|\__\___/_| |_\__,_|    \___\__,_|_|_|_|\___/__/ 
                 |___/                                                        ";
            Console.WriteLine("\t\t\tWelcome to...\t");
            Console.WriteLine(ascii);
        }

        public  void OrdersAscii()
        {
            string ordersAscii = @"                              /|
                                     |\|
                                     |||
                                     |||
                                     |||
                                     |||
                                     |||
                                     |||
                                  ~-[{o}]-~
                                     |/|
                                     |/|
             ///~`     |\\_          `0'         =\\\\         . .
            ,  |='  ,))\_| ~-_                    _)  \      _/_/|
           / ,' ,;((((((    ~ \                  `~~~\-~-_ /~ (_/\
         /' -~/~)))))))'\_   _/'                      \_  /'  D   |
        (       (((((( ~-/ ~-/                          ~-;  /    \--_
         ~~--|   ))''    ')  `                            `~~\_    \   )
             :        (_  ~\           ,                    /~~-     ./
              \        \_   )--__  /(_/)                   |    )    )|
    ___       |_     \__/~-__    ~~   ,'      /,_;,   __--(   _/      |
  //~~\`\    /' ~~~----|     ~~~~~~~~'        \-  ((~~    __-~        |
((()   `\`\_(_     _-~~-\                      ``~~ ~~~~~~   \_      /
 )))     ~----'   /      \                                   )       )
  (         ;`~--'        :                                _-    ,;;(
            |    `\       |                             _-~    ,;;;;)
            |    /'`\     ;                          _-~          _/
           /~   /    |    )                         /;;;''  ,;;:-~
          |    /     / | /                         |;;'   ,''
          /   /     |  \\|                         |   ,;(              
        _/  /'       \  \_)                   .---__\_    \,--._______
       ( )|'         (~-_|                   (;;'  ;;;~~~/' `;;|  `;;;\
        ) `\_         |-_;;--__               ~~~----__/'    /'_______/
        `----'       (   `~--_ ~~~;;------------~~~~~ ;;;'_/'
                     `~~~~~~~~'~~~-----....___;;;____---~~";
            Console.WriteLine("\t\t\tIt's time to spend some money!\n");
            Console.WriteLine($"\t{ordersAscii}");
        }

        public  void GoodbyeAscii()
        {
            string Goodbye = @"





                            .-""""-.
                           F       `Y
                          F          Y
                          I GOODBYE! I
                          L          J          ##
                           L        J          ###
                       #    `-.__.-'          ####
              _____   ##                 .---#####-...__
          .--'     `-###          .--..-'    ######     ""`---....
 _____.----.        ###`.._____ .'          #######
 a:f                ###       /       -.    ####### _.---
                    ###     .(              #######
                     #      : `--...        ######
                     #       `.     ``.     ######
                           _   :       :.    #####
                          ( )            )    ###
                         ,- -.           /    ##
                        |,   .|          |   .##
                        || ' |;         |     '
                     .  ((_, J         <
                   .'    | | |         |
                  /      | ; )         |
                 '       |_ -          .
                                        `
       ";
            Console.WriteLine($"\t\t\t{Goodbye}");
        }

        public  void PurchaseAscii()
        {
            string Purchase = @"             -='''--.._
              ''--...._\        ,b: --....---.
 
                        ||      //'''------''
                      _.l + ----.//

                  .& $''' .''=.. '.
                    /  |  |   )    \
              _.- '@_.'  '@_/      |
             .'             '       \

       -._,-'^'''^' -,               `.
        ,\''-- - ___ | .._.--._,    \
    .-'(,_\_''' _.' ' _,-; '`    `
        '   ''''  '''' |             | __
                       ,+             | -.`o
                     o''/|            #|  oO
                    Oo'./           (#|
                       | '|_,
                       | '|>
                       \             /
                        `l         ,'
                         |,-----|| ' pjy
                        lj lJ
                       o @o      o @o
                        ''        ''
";
            Console.WriteLine($"\t\t{Purchase}\n\tThanks for having the courage to take a chance on us!");
        }

        //Function for getting the users decision in the actual menu
        /// <summary>
        /// Gets the input for what a customer wants to do at the start menu
        /// </summary>
        /// <returns>User choice (int)</returns>
        public int UserMenuChoice()
        {
            bool isInputInt;
            int userChoice;
            do
            {
                System.Console.WriteLine("\t\tPlease select one:\n\t\t1)Login\n\t\t2)Sign up\n\t\t3)Exit");
                string tester = Console.ReadLine();
                isInputInt = int.TryParse(tester, out userChoice);
            } while (!isInputInt || userChoice < 1 || userChoice > 3);
            return userChoice;
        }

        /// <summary>
        /// Used to verify someone's username and pass is existing
        /// </summary>
        /// <param name="dbContext"></param>
        /// <returns>Returns a customer object</returns>
        public Customers Login(SGDB2Context dbContext)
        {
            Customers cust = new Customers();
            string userName;
            string Password;
            int matchWasFound = 0;
            do
            {
                Console.WriteLine("What is your username?");
                userName = Console.ReadLine();
                if (userName.Length == 0)
                {
                    userName = null;
                    Console.WriteLine("Username length was 0");
                }
                if (dbContext.Customers.ToList().Count == 0) //If theres no rows in the database
                {
                    Console.WriteLine("Sorry, looks like theres no customers in the database!");
                    userName = null;
                }
                else
                {
                    foreach (var x in dbContext.Customers) //Loops through customers to find a match between the entered username and an existing one
                    {
                        if (x.UserName == userName) //If a match is found, do nothing and continue onto password
                        {
                            matchWasFound++;
                            break;
                        }
                    }
                    if (matchWasFound == 0) //Match wasn't found
                    {
                        Console.WriteLine("User not found");
                        userName = null;
                    }
                }
            } while (userName == null);//Username can't be empty
            do //Same thing for password
            {
                matchWasFound = 0;
                Console.WriteLine("What is your password?");
                Password = Console.ReadLine();
                if (Password.Length == 0)
                {
                    Password = null;
                }
                if (dbContext.Customers.ToList().Count == 0) //If theres no rows in the database
                {
                    Password = null;
                }
                else
                {
                    foreach (var x in dbContext.Customers) //Loops through customers to find a match between the entered username and an existing one
                    {
                        if (x.Pword == Password && x.UserName == userName) //Need to be sure we are entering the correct username, not someone elses
                        {
                            matchWasFound++;
                            break;
                        }
                    }
                    if (matchWasFound == 0) //Match wasn't found
                    {
                        Console.WriteLine("Password incorrect");
                        Password = null;
                    }
                }
            } while (Password == null);//password can't be empty
            //'Where' brings out all the rows of the table
            //First of Default selects the one that passes
            cust = dbContext.Customers.Where(x => x.UserName == userName && x.Pword == Password).FirstOrDefault();
            Console.WriteLine($"\t\tWelcome back {cust.FirstName}!");
            return cust;
        }


        /// <summary>
        /// Creates a new customer for the databse 
        /// </summary>
        /// <param name="dbContext"></param>
        /// <returns>Customer to be added</returns>
        public Customers SignUpNewCustomer(Customers newCust, SGDB2Context dbContext)
        {

            string fName;
            string lName;
            string user;
            string pass;
            string City;
            string State;
            string Street;
            int Zip;
            string Apartment;

            string test;
            bool isInputInt;
            int tester;
            int defaultStoreFound = 0;

            Customers newCustomer = new Customers();
            do //Get input on first name and validate it is not empty and not a number
            {
                Console.WriteLine("\tPlease enter your first name...");
                fName = Console.ReadLine();
                if (fName.Length == 0)
                {
                    fName = null;
                }
                isInputInt = int.TryParse(fName, out tester);
            } while (isInputInt || fName == null);
            do //get last name
            {
                Console.WriteLine("\tPlease enter your last name...");
                lName = Console.ReadLine();
                if (lName.Length == 0)
                {
                    lName = null;
                }
                isInputInt = int.TryParse(lName, out tester);
            } while (isInputInt || lName == null);
            do //get username 
            {
                Console.WriteLine("\tPlease enter a username...");
                user = Console.ReadLine();
                if (user.Length == 0)
                {
                    user = null;
                }
                foreach (var context in dbContext.Customers.ToList())
                {
                    if (user == context.UserName) //Checks if that username already exists 
                    {
                        Console.WriteLine("That username already exists, please enter a new one...");
                        user = null;
                        break;
                    }
                }
            } while (user == null);
            do //get password 
            {
                Console.WriteLine("\tPlease enter a password...");
                pass = Console.ReadLine();
                if (pass.Length == 0)
                {
                    pass = null;
                }
            } while (pass == null);
            do
            {
                Console.WriteLine("\tPlease enter your city:");
                City = Console.ReadLine();
                if (City.Length == 0)
                {
                    Console.WriteLine("\tEntry can't be empty, please reenter.");
                    City = null;
                }
                isInputInt = int.TryParse(City, out tester);
            } while (isInputInt || City == null);
            do
            {
                Console.WriteLine("\tPlease enter your state (abbreviated):");
                State = Console.ReadLine();
                if (State.Length == 0)
                {
                    State = null;
                }
                if (State.Length > 2)
                {
                    Console.WriteLine($"\t'{State}' not a valid entry. Please reenter.");
                    State = null;
                }
                isInputInt = int.TryParse(City, out tester);
            } while (State == null || State.Length > 2 || isInputInt);
            do
            {
                Console.WriteLine("\tPlease enter your street address:");
                Street = Console.ReadLine();
                if (Street.Length == 0)
                {
                    Console.WriteLine("\tEntry can't be empty, please reenter.");
                    Street = null;
                }
            } while (Street == null);
            do
            {
                Zip = -1;
                Console.WriteLine("\tPlease enter your zip code:");
                test = Console.ReadLine();
                if (test.Length == 0)
                {
                    Console.WriteLine("\tEntry can't be empty, please reenter.");
                    test = null;
                }
                isInputInt = int.TryParse(test, out tester);
                if (!isInputInt)
                {
                    Console.WriteLine("\tEntry must be a number");
                    test = null;
                }
                else
                {
                    Zip = tester;
                }
                if (Zip > 99999 || Zip < 0)
                {
                    Console.WriteLine("\tInvalid zip code");
                    Zip = 0;
                }
            } while (test == null || Zip == 0);
            do
            {
                Console.WriteLine("\tOptional: Please enter your apartment number (Leave empty to decline):");
                Apartment = Console.ReadLine();
                if (Apartment.Length == 0)
                {
                    Apartment = null;
                    break;
                }
                break;
            } while (Street == null);

            foreach (var stores in dbContext.Stores) //Giving a new user a default store based on their city
            {
                if (stores.City == newCustomer.City)
                {
                    newCustomer.DefaultStore = stores.StoreId;
                    defaultStoreFound++;
                    Console.WriteLine($"\tDefault store set to Store #{stores.StoreId}");
                }
            }
            if (defaultStoreFound == 0)
            {
                newCustomer.DefaultStore = 1;
                Console.WriteLine("\tDefault store set to Store #1");
            }
            newCustomer.FirstName = fName;
            newCustomer.LastName = lName;
            newCustomer.UserName = user;
            newCustomer.Pword = pass;
            newCustomer.City = City;
            newCustomer.State = State;
            newCustomer.Street = Street;
            newCustomer.Zip = Zip;
            newCustomer.AptNum = Apartment;

            return newCustomer;
        }

        /// <summary>
        /// Retreives the user choice for the second menu
        /// </summary>
        /// <returns>User choice (int)</returns>
        public int SecondMenu()
        {
            bool isInputInt;
            int userChoice;
            do
            {
                System.Console.WriteLine("\t\tPlease select one:\n\t\t1)Retrieve an order history\n\t\t2)Search for a user\n\t\t3)Retrieve a store's inventory\n\t\t4)Select a default store\n\t\t5)Place an order\n\t\t6)Exit");
                string tester = Console.ReadLine();
                isInputInt = int.TryParse(tester, out userChoice);
            } while (!isInputInt || userChoice < 1 || userChoice > 6);
            return userChoice;
        }

        /// <summary>
        /// Returns the order history of a store or the current user 
        /// </summary>
        public void RetrieveOrderHistory(Customers LoggedIn, SGDB2Context dbContext)
        {

            int choice = -1;
            int tester;
            string test;
            bool isInt;
            do
            {
                Console.WriteLine("\tWould you like to see...\n\t1)Your order history\n\t2)A store's order history");
                test = Console.ReadLine();
                if (test.Length == 0) //Make sure choice isn't empty
                {
                    Console.WriteLine("Entry can't be empty, please reenter");
                    test = null;
                }
                if (!int.TryParse(test, out tester)) //Make sure choice is an int
                {
                    Console.WriteLine("Invalid entry, please retry");
                    test = null;
                }
                else
                {
                    isInt = int.TryParse(test, out tester);
                    choice = tester;
                }
                if (choice != 1 && choice != 2) //Make sure choice is valid int
                {
                    Console.WriteLine("Invalid selection, please retry.");
                }
                else if (choice == 1) //Get current customers order history 
                {
                    int numOrdersFound = 0; //Counts to see if an order is found for the current customer
                    foreach (var order in dbContext.Orders)
                    {
                        if (order.WhoOrdered == LoggedIn.CustomerId) //Parse through the table of Orders and find all orders associated with the currently logged in customer
                        {
                            numOrdersFound++;
                            Console.WriteLine($"\tOrder ID #{order.OrderId} ordered from store #{order.StoreOrderedFrom} on {order.OrderDate}\n\t\tOrdered {order.OrderedProductAmount} of item #'{order.OrderedProduct}'\n\t\t");
                        }
                    }
                    if (numOrdersFound == 0) //if no orders were found after the foreach finishes
                    {
                        Console.WriteLine("\tSorry, looks like you haven't placed any orders!");
                    }
                }
                else if (choice == 2) //Get a selected store's order history 
                {
                    bool storeSelectionIsValid = false; //Bool used as a validation to confirm if the store chosen by the user is valid 
                    do //Do while loop to validate the user's choice of store
                    {
                        Console.WriteLine("\tSelect a store:");
                        foreach (var store in dbContext.Stores) //Prints out available stores to choose from
                        {
                            Console.WriteLine($"\tSlaughtoria Games location #{store.StoreId})\n\tLocated at...\n\t{store.Street}\n\t{store.City}\n\t{store.State}\n\t{store.Zip}\n");
                        }
                        test = Console.ReadLine();
                        if (test.Length == 0) //Make sure store choice isn't empty
                        {

                            test = null;
                        }
                        if (!int.TryParse(test, out tester)) //Make sure store choice is an int
                        {
                            Console.WriteLine("\tInvalid entry, please retry");
                            test = null;
                        }
                        else
                        {

                            isInt = int.TryParse(test, out tester); //If it is an int, convert and store in choice
                            choice = tester;
                        }
                        var orderSelect = (from Orders in dbContext.Orders
                                           where Orders.StoreOrderedFrom == choice
                                           select new
                                           {
                                               Orders.StoreOrderedFrom,
                                               Orders.OrderedProductAmount,
                                               Orders.OrderedProduct,
                                               Orders.WhoOrdered,
                                               Orders.OrderDate,
                                               Orders.OrderId,
                                               Orders.OrderTotal
                                           }).ToList();
                        //Now we get all the information about all our products (That arent included in a bundle)
                        var productInfo = (from products in dbContext.Products
                                           where products.IsInBundle == false
                                           select products).ToList();
                        if (orderSelect.Count != 0)
                        {
                            storeSelectionIsValid = true;
                            int numOrdersFound = 0;
                            Console.WriteLine($"\t\t\tRetrieving order information on store #{choice}...\n");
                            foreach (var orderInfo in orderSelect)
                            {
                                foreach (var product in productInfo)
                                {
                                    if (orderInfo.OrderedProduct == product.Skunum && orderInfo.OrderedProductAmount > 0) //make sure item is in the selected inventory and in stock
                                    {
                                        numOrdersFound = 1;
                                        Console.WriteLine($"\tOrder #{orderInfo.OrderId})\n\t\tOrdered by Customer ID #{orderInfo.WhoOrdered} on {orderInfo.OrderDate}\n\t\tProduct name: {product.ProductName}\n\t\tOrdered Amount: {orderInfo.OrderedProductAmount}\n");
                                    }
                                }
                            }
                            if (numOrdersFound == 0)
                            {
                                Console.WriteLine("\tNo orders found!");
                            }
                        }
                        else
                        {
                            Console.WriteLine("\tThe store you selected either doesn't exist or hasn't placed any orders!");
                        }
                        /*
                            foreach (var store in dbContext.Stores) //Make sure that the given store choice correlates to an existing store
                        
                            //TODO CANT HAVE TWO FOR EACH LOOPS ACCESSING CONTEXT WITHIN ONE ANOTHER
                            if(choice == store.StoreId) //The user input was valid, output all the existing orders placed at this location
                            {
                                storeSelectionIsValid = true;
                                //Select the store which corresponds to the user's input
                                var storeSelect = (from Stores in dbContext.Stores
                                                   where Stores.StoreId == choice
                                                   select Stores.StoreId).FirstOrDefault();
                                //Select the item names that correlate to the SKUNum of the product in the order, puts them in a list
                                //var itemInOrderName = (from Orders in dbContext.Orders
                                //                       from Products in dbContext.Products
                                //                       where Orders.OrderedProduct == Products.Skunum
                                //                       select Products.ProductName).ToList();

                                foreach(var order in dbContext.Orders) //Foreach loop to actually retrieve the order info for the selected store 
                                {
                                    if(storeSelect == order.StoreOrderedFrom)
                                    {
                                        numOrdersFound++;
                                        Console.WriteLine($"\tOrder #{order.OrderId}) Ordered by Customer ID#{order.OrderId} on {order.OrderDate}" +
                                            $"\n\t\tItem SKU #{order.OrderedProduct}\n\t\tOrdered Quantity: {order.OrderedProductAmount}\n\t\tOrdered item total: ${order.OrderTotal}");
                                    }
                                }
                                //If, after parsing through all the orders, the store didnt have any orders placed there
                                if(numOrdersFound == 0)
                                {
                                    Console.WriteLine("\tSorry, looks like no orders have been placed at that location!");
                                }
                            }//End of if statement for when the user input corresponds to a valid store 
                        }//End of for each loop that goes through the process of making sure user input corresponds to a valid store
                        */
                    } while (test == null || storeSelectionIsValid == false); //End of loop for outputting store's order history
                }//End of else-if for beginning to get store order history
            } while (choice != 1 || choice != 2);
        }//End of the GetOrderHistory function

        /// <summary>
        /// Searches for a customer based on user-defined criteria 
        /// </summary>
        /// <param name="dbContext"></param>
        public void SearchForUser(SGDB2Context dbContext)
        {
            string searchedName1;
            bool matchWasFound = false;
            int tester;
            bool isInt;
            do
            {
                Console.WriteLine("\tPlease enter the last name of the person you'd like to find: ");
                searchedName1 = Console.ReadLine();
                if (searchedName1.Length == 0) //make sure entry isnt empty
                {
                    Console.WriteLine("\tEntry can't be empty, please reenter!");
                    searchedName1 = null;
                }
                isInt = int.TryParse(searchedName1, out tester);
                if (isInt) //Make sure entry isnt an int
                {
                    Console.WriteLine($"\t'{searchedName1}' is not a valid entry, Please reenter");
                    searchedName1 = null;
                }
                else //If the entry is valid, search for the user
                {
                    //Takes all customers who meet the search criteria, groups and orders them by last name, and stores that in searchNameReturn as a list
                    var searchedNameReturn = (from Customers in dbContext.Customers
                                              where Customers.LastName.Contains(searchedName1)
                                              select new { Customers.LastName, Customers.FirstName }).ToList();
                    //Check to see if there are any matches (if the list is empty)
                    if (searchedNameReturn.Count == 0)
                    {
                        Console.WriteLine("Sorry, no matches found!");
                    }
                    //If matches were found, print them out
                    else
                    {
                        matchWasFound = true;
                        foreach (var name in searchedNameReturn)
                        {
                            Console.WriteLine($"\t{name.LastName}, {name.FirstName}");
                            //TODO MAKE SURE THE SEARCH RESULTS ARE PRINTING OUT PROPERLY AND WITH DECENT FORMAT
                        }
                    }//End of the else that prints out the results if matches were found
                }//End of else loop for beginning the search
            } while (isInt || searchedName1 == null || matchWasFound == false);
        }//End of SearchForUser function

        /// <summary>
        /// Prints to the console the list of items available in a store's inventory 
        /// </summary>
        /// <param name="dbContext"></param>
        public void GetStoreInventory(SGDB2Context dbContext)
        {
            int choice = -1;
            string test;
            int tester;
            bool storeSelectionIsValid = false; //Bool used as a validation to confirm if the store chosen by the user is valid 
            int productWasFound = 2;
            do //Do while loop to validate the user's choice of store
            {
                Console.WriteLine("\tSelect a store:");
                foreach (var store in dbContext.Stores) //Prints out available stores to choose from
                {
                    Console.WriteLine($"\tSlaughtoria Games location #{store.StoreId}: Located at...\n\t\t{store.Street}\n\t\t{store.City}\n\t\t{store.State}\n\t\t{store.Zip}");
                }
                test = Console.ReadLine();
                if (test.Length == 0) //Make sure store choice isn't empty
                {
                    Console.WriteLine("\tEntry can't be empty, please reenter");
                    test = null;
                }
                else if (!int.TryParse(test, out tester)) //Make sure store choice is an int
                {
                    Console.WriteLine("\tInvalid entry, please retry");
                    test = null;
                }
                else
                {
                    int.TryParse(test, out tester); //If it is an int, convert and store in choice
                    choice = tester;
                }
                //Selects the chosen store's inventory number from the inventory table along with associated Inventory SKU numbers
                var inventorySelect = (from Inventory in dbContext.Inventory
                                       where Inventory.StoreInventory == choice
                                       select new
                                       {
                                           Inventory.StoreInventory,
                                           Inventory.ItemInInventory,
                                           Inventory.ProductCurrentQuantity
                                       }).ToList();
                //Now we get all the information about all our products (That arent included in a bundle)
                var productInfo = (from products in dbContext.Products
                                   where products.IsInBundle == false
                                   select products).ToList();
                if (inventorySelect.Count == 0) //make sure a store inventory was located (meaning the input corresponds to a valid store)
                {
                    Console.WriteLine("\tYour selection did not correspond to an existing store");
                }
                else
                {
                    storeSelectionIsValid = true;
                    Console.WriteLine($"\t\t\tRetrieving inventory information on store #{choice}...\n");
                    foreach (var info in inventorySelect)
                    {
                        foreach (var product in productInfo)
                        {

                            if (info.ItemInInventory == product.Skunum && info.ProductCurrentQuantity > 0) //make sure item is in the selected inventory and in stock
                            {
                                productWasFound = 1;
                                Console.WriteLine($"Product name: {product.ProductName})\nDescription: {product.ProductDescrip}\n" +
                                         $"Product Price: ${product.UnitPrice}\nAmount in Stock: {info.ProductCurrentQuantity}\nProduct SKU: #{product.Skunum}\n");
                            }
                        }
                    }
                    if (productWasFound != 1) //if the store was valid but you leave the foreach loops without finding any products in the inventory 
                    {
                        Console.WriteLine("\tSorry! Looks like this store has nothing in stock! They've been picked clean!");
                    }
                }//End of the if-else for determining and printing out a stores inventory
            } while (test == null || storeSelectionIsValid == false); //End of loop for outputting store's order history
        }

        /// <summary>
        /// Users select a default store which is automatically called when ordering begins 
        /// </summary>
        /// <param name="dbContext"></param>
        /// <returns>Sets the users default store</returns>
        public void SetSelectedStore(Customers LoggedInCustomer, SGDB2Context dbContext)
        {
            int menuChoice;
            int storeChoice = -1;
            string tester;
            int convert;
            bool storeChoiceIsValid = false;
            do
            {
                Console.WriteLine($"\tCurrently, your selected store is store #{LoggedInCustomer.DefaultStore}");
                Console.WriteLine("\tWould you like to...\n\t1)Set a new default store\n\t2)Exit\n");
                tester = Console.ReadLine();
                if (tester.Length == 0)
                {
                    tester = null;
                }
                if (!int.TryParse(tester, out menuChoice))
                {
                    tester = null;
                    Console.WriteLine("\tInvalid entry, please reenter!");
                }
                else
                {
                    int.TryParse(tester, out convert);
                    menuChoice = convert;
                }
                if (menuChoice == 1) //if the user opted to select a new default store
                {
                    do
                    {
                        Console.WriteLine("\tPlease select a default store...");
                        foreach (var store in dbContext.Stores)
                        {
                            Console.WriteLine($"Store #{store.StoreId} located at:\n\t{store.Street}\n\t{store.City}\n\t{store.State}\n");
                        }
                        tester = Console.ReadLine();
                        if (tester.Length == 0) //Test for input validity
                        {
                            tester = null;
                        }
                        if (!int.TryParse(tester, out menuChoice))
                        {
                            tester = null;
                            Console.WriteLine("\tInvalid entry, please reenter!");
                        }
                        else
                        {
                            int.TryParse(tester, out convert);
                            storeChoice = convert;
                        }
                        //Query for all the StoreIds currently in the DB 
                        var storeList = (from Stores in dbContext.Stores
                                         select new { Stores.StoreId }).ToList();
                        foreach (var stores in storeList)
                        {
                            if (stores.StoreId == storeChoice) //Find the store that corresponds to the user choice and set it to be the default store
                            {
                                storeChoiceIsValid = true;
                                LoggedInCustomer.DefaultStore = storeChoice;
                                Console.WriteLine("\tDefault store selected!");
                            }
                        }
                        if (storeChoiceIsValid == true) //this only happens if the default was changed, set the change to the DB 
                        {
                            foreach (var Customer in dbContext.Customers)
                            {
                                if (Customer.CustomerId == LoggedInCustomer.CustomerId)
                                {
                                    Customer.DefaultStore = LoggedInCustomer.DefaultStore;

                                }
                            }
                        }
                    } while (storeChoiceIsValid == false);
                }//End of if where user selects new default 
                else if (menuChoice == 2)
                {
                    Console.WriteLine($"\tYour default store is currently {LoggedInCustomer.DefaultStore}");
                }
            } while (tester == null || menuChoice != 2);
        }

        /// <summary>
        /// Allows user to place orderes from their default store
        /// </summary>
        /// <param name="LoggedInCustomer"></param>
        /// <param name="dbContext"></param>
        public void PlaceOrders(Customers LoggedInCustomer, SGDB2Context dbContext)
        {
            string tester1;
            string tester2;
            string tester3;

            int test;

            int mainMenuChoice;
            int orderMenuChoice;
            int addItemToCartChoice;

            var Cart = new List<Products>(); //For storing objects ordered by the customer
            var orderQuantities = new List<int>(); //For storing the number of objects ordered by customers

            //User is automatically set to shop at their default store 
            Console.WriteLine($"\t\t\t\tWelcome to the shop!");
            OrdersAscii();
            do
            {
                Console.WriteLine($"\tYou are currently shopping at Store #{LoggedInCustomer.DefaultStore}\n");
                Console.WriteLine("\tIf you would like to select a different store, press 2 to exit!");
                Console.WriteLine("\t1)Place an order\t2)Exit\n");
                tester1 = Console.ReadLine();
                if (tester1.Length == 0)
                {
                    tester1 = null;
                }
                if (!int.TryParse(tester1, out mainMenuChoice))
                {
                    tester1 = null;
                    Console.WriteLine("\tInvalid entry, please reenter!");
                }
                else
                {
                    int.TryParse(tester1, out test);
                    mainMenuChoice = test;
                }
                if (mainMenuChoice == 1)
                {
                    int wantsToOrderAnotherItem;
                    do
                    {
                        Console.WriteLine("\tWould you like to\n\t1)Add an item to your cart\n\t2)Check your cart\n\t3)Checkout\n\t4)Exit");
                        tester2 = Console.ReadLine();
                        if (tester2.Length == 0) //Input validation
                        {
                            tester2 = null;
                        }
                        if (!int.TryParse(tester2, out orderMenuChoice))
                        {
                            tester2 = null;
                            Console.WriteLine("\tInvalid entry, please reenter!");
                        }
                        else
                        {
                            int.TryParse(tester2, out test);
                            orderMenuChoice = test;
                        }
                        if (orderMenuChoice == 1) //Place item in cart
                        {
                            int productWasFound = -1;
                            int productCanbeOrdered = -1;
                            int orderQuantityValid = -1;
                            int numOrdered;
                            //Products orderedProduct = new Products();
                            do
                            {
                                Products orderedProduct = new Products();
                                //Selects the default store's inventory number from the inventory table along with associated Inventory SKU numbers
                                var inventorySelect = (from Inventory in dbContext.Inventory
                                                       where Inventory.StoreInventory == LoggedInCustomer.DefaultStore
                                                       select Inventory).ToList();
                                //Now we get all the information about all our products (That arent included in a bundle)
                                var productInfo = (from products in dbContext.Products
                                                   where products.IsInBundle == false
                                                   select products);
                                if (inventorySelect.Count == 0) //make sure a store inventory was located (meaning the input corresponds to a valid store)
                                {
                                    Console.WriteLine("\tIt seems your default store has been closed! Return to the store menu to select a new one!");
                                }
                                else
                                {
                                    Console.WriteLine($"\t\t\tRetrieving inventory information on store #{LoggedInCustomer.DefaultStore}...\n");
                                    foreach (var info in inventorySelect)
                                    {
                                        foreach (var product in productInfo)
                                        {
                                            if (info.ItemInInventory == product.Skunum && info.ProductCurrentQuantity > 0) //make sure item is in the selected inventory and in stock
                                            {
                                                productWasFound = 1;
                                                Console.WriteLine($"Product name: {product.ProductName})\nDescription: {product.ProductDescrip}\n" +
                                                         $"Product Price: ${product.UnitPrice}\nAmount in Stock: {info.ProductCurrentQuantity}\nProduct SKU: #{product.Skunum}\n");
                                            }
                                        }
                                    }
                                    if (productWasFound != 1) //if the store was valid but you leave the foreach loops without finding any products in the inventory 
                                    {
                                        Console.WriteLine("\tSorry! Looks like this store has nothing in stock! They've been picked clean!");
                                    }
                                }//End of the if-else for determining and printing out a stores inventory
                                do //Verify the product a customer wants to order is available to be ordered
                                {
                                    Console.WriteLine("\tPlease enter the SKUNum of the item you would like to add to your cart...");
                                    tester3 = Console.ReadLine();
                                    if (tester3.Length == 0) //input validation
                                    {
                                        tester3 = null;
                                    }
                                    if (!int.TryParse(tester3, out addItemToCartChoice))
                                    {
                                        tester3 = null;
                                        Console.WriteLine("\tInvalid entry, please reenter!");
                                    }
                                    else
                                    {
                                        int.TryParse(tester3, out test);
                                        addItemToCartChoice = test;
                                    }
                                    //Parse through the list of available products in the store's inventory to determine if the entered SKUNum is there
                                    foreach (var info in inventorySelect)
                                    {
                                        foreach (var product in productInfo)
                                        {
                                            if (info.ItemInInventory == product.Skunum && info.StoreInventory == LoggedInCustomer.DefaultStore && addItemToCartChoice == product.Skunum && info.ProductCurrentQuantity > 0) //make sure item is in the selected inventory and in stock so it can be selected
                                            {
                                                //If the entered SkuNum is in the inventory and available, enter the info on the product object
                                                productCanbeOrdered = 1;
                                                orderedProduct.ProductName = product.ProductName;
                                                orderedProduct.Skunum = addItemToCartChoice;
                                                orderedProduct.UnitPrice = product.UnitPrice;
                                                orderedProduct.ProductDiscount = product.ProductDiscount;
                                                orderedProduct.IsBundle = product.IsBundle;
                                                orderedProduct.IsInBundle = product.IsInBundle;
                                                orderedProduct.BundleId = product.BundleId;
                                                Cart.Add(orderedProduct);
                                                Console.WriteLine($"\tItem #{orderedProduct.Skunum} added to the cart");
                                            }
                                        }
                                    }//Foreach loop to check if the selected product can be ordered
                                    if (productCanbeOrdered != 1)
                                    {
                                        Console.WriteLine("\tThe product associated with that SKUNum either doesn't exist or is not available.");
                                    }
                                } while (productCanbeOrdered != 1 || tester3 == null);//While loop to make sure the selected product is available and can be ordered
                                do//Check to make sure the quantity ordered by the customer is logical and available 
                                {
                                    Console.WriteLine("\tHow many of that item would you like to order?");
                                    tester3 = Console.ReadLine();
                                    if (tester3.Length == 0) //input validation
                                    {
                                        tester3 = null;
                                    }
                                    if (!int.TryParse(tester3, out numOrdered))
                                    {
                                        tester3 = null;
                                        Console.WriteLine("\tInvalid entry, please reenter!");
                                    }
                                    else
                                    {
                                        int.TryParse(tester3, out test);
                                        numOrdered = test;
                                    }
                                    if (numOrdered < 0)
                                    {
                                        Console.WriteLine("\tEntry can't be negative!");
                                    }
                                    foreach (var info in inventorySelect)
                                    {
                                        foreach (var product in productInfo)
                                        {
                                            if (info.ItemInInventory == orderedProduct.Skunum && info.StoreInventory == LoggedInCustomer.DefaultStore && info.ProductCurrentQuantity >= numOrdered) //make sure item is in the selected inventory and has enough stock
                                            {
                                                //If the amount entered is a valid amount 
                                                orderQuantityValid = 1;
                                            }
                                            else if (info.ItemInInventory == orderedProduct.Skunum && info.StoreInventory == LoggedInCustomer.DefaultStore && info.ProductCurrentQuantity < numOrdered)
                                            {
                                                continue;
                                            }
                                        }
                                    }//Foreach loop to check if the quantity of the selected product is valid

                                } while (tester3 == null || orderQuantityValid != 1);//Do-While to make sure the quantity ordered is valid 

                                orderQuantities.Add(numOrdered);
                                Console.WriteLine($"\tOrdered {numOrdered} of {orderedProduct.Skunum}");
                                //Cart.Add(orderedProduct);
                                Console.WriteLine("\tWould you like to...\n\t1)Add another item to your cart\n\t2)Exit");
                                tester3 = Console.ReadLine();
                                if (tester3.Length == 0) //input validation
                                {
                                    tester3 = null;
                                }
                                if (!int.TryParse(tester3, out wantsToOrderAnotherItem))
                                {
                                    tester3 = null;
                                    Console.WriteLine("\tInvalid entry, please reenter!");
                                }
                                else
                                {
                                    int.TryParse(tester3, out test);
                                    wantsToOrderAnotherItem = test;
                                }
                                if (wantsToOrderAnotherItem < 0)
                                {
                                    Console.WriteLine("\tEntry can't be negative!");
                                }
                            } while (tester3 == null || wantsToOrderAnotherItem != 2);//Do-While loop where users add items to cart (shop)
                        }//End of ORDER MENU 1 to put item in the cart
                        else if (orderMenuChoice == 2)//Check your cart
                        {
                            int quantityCount = orderQuantities.Count();
                            int cartCount = Cart.Count();
                            if (Cart.Count == 0)
                            {
                                Console.WriteLine("\tSorry, looks like your cart is empty.");
                            }
                            else
                            {
                                for (int i = 0; i < cartCount; i++)
                                {
                                    Console.WriteLine($"\tItem name: {Cart[i].ProductName}\n\tOrdered Quantity: {orderQuantities[i]}\n\tUnit Price: ${Cart[i].UnitPrice}\n\tSKU #{Cart[i].Skunum}");

                                }
                            }
                        }//End of ORDER MENU 2 to check the users cart
                        else if (orderMenuChoice == 3)//Checkout
                        {
                            StoreMethods method = new StoreMethods();
                            int cartCount = Cart.Count();
                            decimal orderTotal = 0;
                            if (Cart.Count == 0)
                            {
                                Console.WriteLine("\tYour cart is empty, so I guess your order is free?");
                            }
                            else //Loop to get our order total
                            {
                                for (int i = 0; i < cartCount; i++)
                                {
                                    orderTotal += method.GetItemTotal(orderQuantities[i], Cart[i], dbContext); //Get the total price of each item in the cart, the end result is the orderTotal
                                    SetNewProductQuantity(orderQuantities[i], Cart[i], LoggedInCustomer, dbContext);
                                    Console.WriteLine($"\tDEBUG: {orderQuantities[i]} of '{Cart[i].ProductName}' ordered at ${Cart[i].UnitPrice} with a {Cart[i].ProductDiscount}% discount...");


                                }//End of calcualte order total loop
                                orderTotal = Math.Round(orderTotal, 2); //2 decimal points
                                Console.WriteLine($"\t Your order total is ${orderTotal}");

                                //Want to keep PK as unique primary key, use Order ID to group purchases together 
                                int newOrderId = 1;
                                int orderIdFound = 0;
                                var orderList = (from Orders in dbContext.Orders
                                                 select Orders.OrderId);
                                if (dbContext.Orders.ToList().Count != 0)
                                {
                                    do
                                    {
                                        if (orderList.Contains(newOrderId))
                                        {
                                            newOrderId++;
                                        }
                                        else
                                        {
                                            orderIdFound = 1;
                                        }
                                    } while (orderIdFound != 1);


                                }

                                //Create a new order object for each item in the cart linked by orderID
                                for (int i = 0; i < cartCount; i++)
                                {
                                    Orders newOrder = new Orders();
                                    newOrder.OrderDate = DateTime.Now;
                                    newOrder.OrderedProduct = Cart[i].Skunum;
                                    newOrder.OrderedProductAmount = orderQuantities[i];
                                    newOrder.OrderTotal = orderTotal;
                                    newOrder.StoreOrderedFrom = LoggedInCustomer.DefaultStore;
                                    newOrder.WhoOrdered = LoggedInCustomer.CustomerId;
                                    newOrder.OrderId = newOrderId;
                                    dbContext.Orders.Add(newOrder);
                                    dbContext.SaveChanges();
                                }
                                //Once the orders have been placed, empty the cart
                                Cart.Clear();
                                orderQuantities.Clear();
                                PurchaseAscii();
                            }//else statement for checking out and placing orders 
                        }//End of ORDER MENU 3 to checkout 
                    } while (orderMenuChoice != 4 || tester2 == null); //End of ORDER MENU Do-while
                }//End of MAIN MENU 1 if statment to place an order
            } while (mainMenuChoice != 2 || tester1 == null);
        }//End of MakeOrders function


        /// <summary>
        /// Adjusts product quantity based on amount ordered
        /// </summary>
        /// <param name="numberOrdered"></param>
        /// <param name="orderedProduct"></param>
        /// <param name="CurrentlyLoggedIn"></param>
        /// <param name="dbContext"></param>
        public void SetNewProductQuantity(int numberOrdered, Products orderedProduct, Customers CurrentlyLoggedIn, SGDB2Context dbContext)
        {
            var allItemsInventory = (from Products in dbContext.Products
                                     select Products).ToList();
            var storeInventory = (from Inventory in dbContext.Inventory
                                  where Inventory.StoreInventory == CurrentlyLoggedIn.DefaultStore
                                  select Inventory).ToList(); //Store ONLY the inventoryId of the store
            foreach (var Inventory in storeInventory)
            {
                if (Inventory.ItemInInventory == orderedProduct.Skunum && Inventory.StoreInventory == CurrentlyLoggedIn.DefaultStore)
                {
                    Inventory.ProductCurrentQuantity -= numberOrdered; //New quantity set for ordered product
                    Console.WriteLine($"\tDEBUG: {orderedProduct.ProductName} quantity decreased by {numberOrdered} to {Inventory.ProductCurrentQuantity}\n");

                }
                else
                {
                    continue;
                }
            }
            if (orderedProduct.IsBundle == true) //if the ordered product is a bundle 
            {
                foreach (var inventory in dbContext.Inventory)
                {
                    foreach (var items in allItemsInventory)
                    {
                        if (items.BundleId == orderedProduct.BundleId && inventory.ItemInInventory == items.Skunum && items.IsInBundle == true) //if the item is InBundle, is part of the orderedProduct's bundle, and available at the same store
                        {
                            inventory.ProductCurrentQuantity -= numberOrdered; //Decrement items that are a part of the bundle as well
                            Console.WriteLine($"\tDEBUG: Bundle-Included item '{items.ProductName}' in Bundle #{items.BundleId} quantity reduced by {numberOrdered} to {inventory.ProductCurrentQuantity}\n");

                        }
                        else
                        {
                            continue;
                        }
                    }
                }
            }
            dbContext.SaveChanges();

        }

        /// <summary>
        /// Returns the calcualted total for an item accounting for discount
        /// </summary>
        /// <param name="numberOrdered"></param>
        /// <param name="orderedItem"></param>
        /// <param name="dbContext"></param>
        /// <returns>The total price of an item</returns>
        public  decimal GetItemTotal(int numberOrdered, Products orderedItem, SGDB2Context dbContext)
        {
            decimal itemTotal = numberOrdered * (orderedItem.UnitPrice * (1 - orderedItem.ProductDiscount)); //Account for discount 
            return Math.Round(itemTotal, 2); //2 decimal points
        }

        /// <summary>
        /// Takes the item totals and calculates the order price
        /// </summary>
        /// <param name="itemTotals"></param>
        /// <returns>Decimal9</returns>
        public  double GetOrderTotal(double itemTotals)
        {
            return Math.Round(itemTotals, 2);
        }

        /// <summary>
        /// Prints out the store's tagline 
        /// </summary>
        public void StartMenu()
        {
            Console.WriteLine("\t\t\tWelcome to Slaughtoria Games!\n\t\t\tOnly true 5head gamers shop here!");
        }
    }
}
