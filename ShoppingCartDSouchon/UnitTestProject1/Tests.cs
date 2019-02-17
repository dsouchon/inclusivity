using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using ShoppingCartLib;

namespace UnitTestProject1
{
    [TestClass]
    public class Tests
    {
        //Global Variables
        private static ShoppingCart shoppingCart;
        /// <summary>
        /// SetUp
        /// </summary>
        /// <param name="testContext"></param>
        // Use ClassInitialize to run code before running the first test in the class
        [ClassInitialize()]
        public static void InitializeWholeClass(TestContext testContext)
        {
          
        }

        // Use TestInitialize to run code before running each test 
        [TestInitialize()]
        public void InitializeEachTest() {

            shoppingCart = new ShoppingCart(12.5M);
            shoppingCart.Products = new EventList<Product>();
            shoppingCart.Products.CountChanged += new EventHandler<EventList<Product>.ListEventArgs>(shoppingCart.Productlist_CountChanged);

        }
        
        /// <summary>
        /// TearDown
        /// </summary>
        // Use ClassCleanup to run code after all tests in a class have run
        [ClassCleanup()]
        public static void CleanupWholeTestContext() { }

        // Use TestCleanup to run code after each test has run
        [TestCleanup()]
        public void MyTestCleanup() { }


        //Step 1 Test: Add products to the shopping cart.
        [TestMethod, Description("Given:• An empty shopping cart • And a product, Dove Soap with a unit price of 39.99 When: • The user adds 5 Dove Soaps to the shopping cart Then: • The shopping cart should contain 5 Dove Soaps each with a unit price of 39.99 • And the shopping cart’s total price should equal 199.95")]

        public void Add5DoveSoaps()
        {
            int x = 0;
            Product product = new Product { Description = "Dove Soap", Price = 39.99M };

            while (x < 5)
            {
                shoppingCart.Products.Add(product);
                x++;
            }

            Assert.AreEqual( 199.95M, shoppingCart.TotalPriceExcludingTax);
        }

       //Step 2 Test : Add additional products of the same type to the shopping cart.
       [TestMethod, Description("Given:• An empty shopping cart • And a product, Dove Soap with a unit price of 39.99 When: • The user adds 5 Dove Soaps to the shopping cart • And then adds another 3 Dove Soaps to the shopping cart Then: • The shopping cart should contain 8 Dove Soaps each with a unit price of 39.99 • And the shopping cart’s total price should equal 319.92")]

        public void Add5DoveSoapsThen3DoveSoaps()
        {
         
            Product product = new Product { Description = "Dove Soap", Price = 39.99M };

            shoppingCart.AddProduct(product, 5);
            shoppingCart.AddProduct(product, 3);
            Assert.AreEqual( 319.92M, shoppingCart.TotalPriceExcludingTax);
        }

        //Step 3: Calculate the tax rate of the shopping cart with multiple items
        [TestMethod, Description("Given: • An empty shopping cart • And a product, Dove Soap with a unit price of 39.99 • And another product, Axe Deo with a unit price of 99.99 • And a tax rate of 12.5% When: • The user adds 2 Dove Soaps to the shopping cart • And then adds 2 Axe Deo’s to the shopping cart Then: • The shopping cart should contain 2 Dove Soaps each with a unit price of 39.99 • And the shopping cart should contain 2 Axe Deo’s each with a unit price of 99.99 • And the total tax amount should equal 35.00 • And the shopping cart’s total price should equal 314.96")]
        public void Add2DoveSoapsThen2AxeDeosDoTax()
        {
          
            Product productDoveSoap = new Product { Description = "Dove Soap", Price = 39.99M };
            Product productAxeDeo = new Product { Description = "Axe Deo", Price = 99.99M };

            shoppingCart.AddProduct(productDoveSoap, 2);

            shoppingCart.AddProduct(productAxeDeo, 2);

            Assert.AreEqual( 35.00M, shoppingCart.TotalTax);
            Assert.AreEqual( 314.96M, shoppingCart.TotalPriceIncludingTax);
        }

    }
}
