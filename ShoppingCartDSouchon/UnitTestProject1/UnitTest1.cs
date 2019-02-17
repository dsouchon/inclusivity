using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        //Global Variables
        private static ShoppingCart shoppingCart;
        /// <summary>
        /// SetUp
        /// </summary>
        /// <param name="testContext"></param>
        // Use ClassInitialize to run code before running the first test in the class
        [ClassInitialize()]
        public static void MyClassInitialize(TestContext testContext) {
            shoppingCart = new ShoppingCart();
            shoppingCart.products = new EventList<Product>();
            shoppingCart.products.CountChanged += new EventHandler<EventList<Product>.ListEventArgs> (shoppingCart.list_CountChanged);
           
        }
            
        // Use TestInitialize to run code before running each test 
        [TestInitialize()]
        public void MyTestInitialize() { }



        /// <summary>
        /// TearDown
        /// </summary>
        // Use ClassCleanup to run code after all tests in a class have run
        [ClassCleanup()]
        public static void MyClassCleanup() { }

        // Use TestCleanup to run code after each test has run
        [TestCleanup()]
        public void MyTestCleanup() { }

              
        //Step 1 Test
        [TestMethod, Description("Given:• An empty shopping cart • And a product, Dove Soap with a unit price of 39.99 When: • The user adds 5 Dove Soaps to the shopping cart Then: • The shopping cart should contain 5 Dove Soaps each with a unit price of 39.99 • And the shopping cart’s total price should equal 199.95")]

        public void Add5DoveSoaps()
        {
            int x = 0;
            Product product = new Product { Description = "Dove Soap", Price = 39.99M };

            while (x < 5)
            {
                shoppingCart.products.Add(product);
                x++;
            }
            
            Assert.AreEqual(shoppingCart.TotalPriceExcludingTax, 199.95M);
        }



    }
}
