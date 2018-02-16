using System;
using System.Collections.Generic;

namespace Fray_c.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public int Stock { get; set; }
    }

    public class ProductList
    {
        public ProductList ()
        {
            this.ProductsList = new List<Product>();
        }
        public int MinStock { get; set; }
        public List<Product> ProductsList {get;set;}
    }
}