using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Infinite.MVC.Day1.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }

        public List<Product> GetProducts()
        {
            return new List<Product>
            {
                new Product{Id=1, ProductName="Wall Clock", Price=899.89, Quantity=120},
                new Product{Id=2, ProductName="Table Fan", Price=2599.5, Quantity=20},
                new Product{Id=3, ProductName="Toys", Price=250, Quantity=100},
                new Product{Id=4, ProductName="Speaker", Price=12599, Quantity=80},
            };
        }
    }
}