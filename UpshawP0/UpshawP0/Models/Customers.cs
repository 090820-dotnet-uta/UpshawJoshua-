using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Xml.Schema;

namespace UpshawP0.Models
{
    public partial class Customers : CustomersInterface
    {
        public Customers()
        {
            Orders = new HashSet<Orders>();
        }

        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Pword { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Street { get; set; }
        public decimal Zip { get; set; }
        public string AptNum { get; set; }
        public int DefaultStore { get; set; }

        public virtual ICollection<Orders> Orders { get; set; }

        public Customers(string firstname, string lastname, string username, string password)
        {
            CustomerId = 1;
            City = "a";
            State = "a";
            Street = "a";
            Zip = 12345;
            FirstName = firstname;
            LastName = lastname;
            UserName = username;
            Pword = password;
        }

        /// <summary>
        /// Used to verify someone's username and pass is existing
        /// </summary>
        /// <param name="dbContext"></param>
        /// <returns>Returns a customer object</returns>
        public static Customers Login(SGDB2Context dbContext)
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
        public static Customers SignUpNewCustomer(Customers newCust, SGDB2Context dbContext)
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
    }
}
