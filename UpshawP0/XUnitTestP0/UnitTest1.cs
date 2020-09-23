using System;
using Xunit;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Xml.Schema;
using UpshawP0.Models;
using System.IO;
using UpshawP0;

namespace XUnitTestP0
{
    public class UnitTest1
    {
        [Fact]
        //Arrange
        public void LoginProperlyReturnsACustomerType()
        {
            var options = new DbContextOptionsBuilder<SGDB2Context>()
                .UseInMemoryDatabase(databaseName: "SGDB2")
                .Options;

            using (var context = new SGDB2Context(options))
            {

                using (var sw = new StringWriter())
                {

                    using (var sr = new StringReader("abe\nyup"))
                    {
                            context.Add(new Customers
                            {
                                UserName = "abe",
                                Pword = "yup"
                            });

                            context.SaveChanges();

                            //Act
                            Console.SetOut(sw);
                            Console.SetIn(sr);
                            Customers customer = new Customers();
                            StoreMethods storeMethods = new StoreMethods();
                            customer = storeMethods.Login(context);


                            //Assert
                            Assert.IsType<Customers>(customer);
                        
                    }
                }

            }
        }//End Test 1
        [Fact]
        //Arrange
        public void StartMenuHasCorrectOutput()
        {
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);

                // Act statement ...
                StoreMethods storeMethod = new StoreMethods();
                storeMethod.StartMenu();

                // Assert statement ...
                Assert.Equal("\t\t\tWelcome to Slaughtoria Games!\n\t\t\tOnly true 5head gamers shop here!\r\n", sw.ToString());
                sw.Close();
            }
        }//Test 2

        [Fact]
        public void FirstMenuChoiceReturnsAValidInteger()
        {
                using (var sr = new StringReader("2\n"))
                {
                    Console.SetIn(sr);

                    //Act
                    StoreMethods storeMethod = new StoreMethods();

                    //Assert
                    int menuChoice = storeMethod.UserMenuChoice();
                    Assert.InRange(menuChoice, 1, 3);
                }
        }//Test 3

        [Fact]
        public void SecondMenuChoiceReturnsAValidInteger()
        {
                using (var sr = new StringReader("4\n"))
                {
                    Console.SetIn(sr);

                    //Act
                    StoreMethods storeMethod = new StoreMethods();

                    //Assert
                    int menuChoice = storeMethod.SecondMenu();
                    Assert.InRange(menuChoice, 1, 6);
                }
        }//Test 4

        [Fact]
        //Arrange
        public void GetOrderTotalReturnsCorrectOutput()
        {
            //Act
            StoreMethods newMethod = new StoreMethods();
            double dub = 25.75111;
            var result = newMethod.GetOrderTotal(dub);

            //Assert
            Assert.Equal(25.75, result);

        }//test 5

        [Fact]
        //Arrange
        public void GetOrderTotalReturnsDecimal()
        {
            //Act
            StoreMethods newMethod = new StoreMethods();
            double dub = 25.75576;
            var result = newMethod.GetOrderTotal(dub);

            //Assert
            Assert.IsType<double>(result);

        }//test 6

        [Fact]
        //Arrange
        public void GetItemTotalReturnsADecimal()
        {
            //Act
            var options = new DbContextOptionsBuilder<SGDB2Context>()
                .UseInMemoryDatabase(databaseName: "SGDB2")
                .Options;

            using (var context = new SGDB2Context(options))
            {
                Products thing = new Products(50.50m, .50m);
                context.Add(thing);
                StoreMethods storeMethod = new StoreMethods();
                var result = storeMethod.GetItemTotal(4, thing, context);

                //Assert
                Assert.IsType<decimal>(result);
            }
        }//test 7

        [Fact]
        //Arrange
        public void GetItemTotalReturnsCorrectResult()
        {
            //Act
            var options = new DbContextOptionsBuilder<SGDB2Context>()
                .UseInMemoryDatabase(databaseName: "SGDB2")
                .Options;

            using (var context = new SGDB2Context(options))
            {
                Products thing = new Products(50.50m, .50m);
                context.Add(thing);
                StoreMethods storeMethod = new StoreMethods();
                var result = storeMethod.GetItemTotal(4, thing, context);

                //Assert
                Assert.Equal(101.00m, result);
            }
        }//Test 8

        [Fact]
        //Arrange
        public void SearchCustomerReturnsCustomerName()
        {
            var options = new DbContextOptionsBuilder<SGDB2Context>()
               .UseInMemoryDatabase(databaseName: "SGDB2")
               .Options;

            using (var context = new SGDB2Context(options))
            {

                using (var sw = new StringWriter())
                {

                    using (var sr = new StringReader("a"))
                    {
                        
                        Customers custy = new Customers { FirstName = "al", LastName = "ali" };
                        context.Add(custy);
                        context.SaveChanges();

                        //Act
                        Console.SetOut(sw);
                        Console.SetIn(sr);
                        Customers customer = new Customers();
                        StoreMethods storeMethods = new StoreMethods();
                        storeMethods.SearchForUser(context);


                        //Assert
                        Assert.Contains("al\r\n", sw.ToString());

                    }
                }

            }
        }//Test 9

        [Fact]
        //Arrange
        public void StoreSelectionThrowsExceptionOnNull()
        {

            var options = new DbContextOptionsBuilder<SGDB2Context>()
               .UseInMemoryDatabase(databaseName: "SGDB2")
               .Options;

            using (var context = new SGDB2Context(options))
            {

                using (var sw = new StringWriter())
                {

                    using (var sr = new StringReader("0\n"))
                    {
                        Customers custy = new Customers
                        {
                            UserName = "abe",
                            Pword = "yup",
                            DefaultStore = 1
                        };
                        context.Add(custy);
                        context.SaveChanges();

                        //Act
                        bool thrown = false;
                        try
                        {
                            Console.SetOut(sw);
                            Console.SetIn(sr);
                            Customers customer = new Customers();
                            StoreMethods storeMethods = new StoreMethods();
                            storeMethods.SetSelectedStore(customer, context);
                        }
                        catch(NullReferenceException)
                        {
                            thrown = true;
                        }
                        //Assert
                        Assert.True(thrown);
                        sw.Close();

                    }
                }

            }
        }//Test 10
    }
}
