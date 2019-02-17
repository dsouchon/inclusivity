using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace UnitTestProject1
{
    internal class ShoppingCart
    {

        public EventList<Product> products { get; set; }
        public decimal TotalTax { get; set; }
        public decimal TotalPriceExcludingTax { get; set; }
        public decimal TotalPriceIncludingTax { get; set; }

        public void AddProduct(Product product)
        {

            products.Add(product);
        }

        public void list_CountChanged(object sender, EventList<Product>.ListEventArgs e)
        {
            CalculateTotals();
        }

        private void CalculateTotals()
        {
            decimal sum = 0.00M;
            foreach (var product in products)
            {
                sum += product.Price;

            }

            this.TotalPriceExcludingTax = decimal.Round(sum, 2);
        }

        public ShoppingCart()
        {
            products = new EventList<Product>();
            TotalTax = 0.00M;
            TotalPriceIncludingTax = 0.00M;

        }

        


    }
}
