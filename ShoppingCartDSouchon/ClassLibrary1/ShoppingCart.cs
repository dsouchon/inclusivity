using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace ShoppingCartLib
{
    public class ShoppingCart
    {

        public EventList<Product> products { get; set; }
        public decimal TotalTax { get; set; }
        public decimal TotalPriceExcludingTax { get; set; }
        public decimal TotalPriceIncludingTax { get; set; }

        public decimal TaxRate{ get; set; }

        public void AddProduct(Product product)
        {

            products.Add(product);
        }

        public void list_CountChanged(object sender, EventList<Product>.ListEventArgs e)
        {
            CalculateTotalPrice();
        }

        private void CalculateTotalPrice()
        {
            decimal sum = 0.00M;
            foreach (var product in products)
            {
                sum += product.Price;

            }

            this.TotalPriceExcludingTax = decimal.Round(sum, 2);
            this.TotalTax = decimal.Round(TotalPriceExcludingTax * (TaxRate / 100.00M),2);
            this.TotalPriceIncludingTax = decimal.Round(TotalPriceExcludingTax + TotalTax, 2);

        }

        public void AddProduct(Product product, int Count)
        {
            int x = 0;
            while (x < Count)
            {
                products.Add(product);
                x++;
            }

        }


        public ShoppingCart(decimal taxRate = 12.5M)
        {
            products = new EventList<Product>();
            TotalTax = 0.00M;
            TotalPriceIncludingTax = 0.00M;
            TotalPriceExcludingTax = 0.00M;
            TaxRate = taxRate;
        }




    }
}
