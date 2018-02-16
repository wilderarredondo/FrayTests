using System;
using System.Collections.Generic;
using Fray_c.Models;

namespace Fray_c
{
    class Program
    {
        public static List<Customer> CustomerList()
        {
            List<Customer> customerList = new List<Customer>();
            Customer customerTemp1 = new Customer();
            Customer customerTemp2 = new Customer();
            Customer customerTemp3 = new Customer();
            Customer customerTemp4 = new Customer();

            customerTemp1.CustomerId = 10;
            customerTemp1.Name = "Rosa Carguaricra";
            customerTemp1.Age = 48;
            customerTemp1.BirthDate = DateTime.Parse("1970-01-01");

            customerTemp2.CustomerId = 11;
            customerTemp2.Name = "Sandra Quinones";
            customerTemp2.Age = 58;
            customerTemp2.BirthDate = DateTime.Parse("1960-02-01");

            customerTemp3.CustomerId = 12;
            customerTemp3.Name = "Raul Pasquel";
            customerTemp3.Age = 38;
            customerTemp3.BirthDate = DateTime.Parse("1980-02-01");

            customerTemp4.CustomerId = 13;
            customerTemp4.Name = "Juan Roca";
            customerTemp4.Age = 68;
            customerTemp4.BirthDate = DateTime.Parse("1950-05-01");

            customerList.Add(customerTemp1);
            customerList.Add(customerTemp2);
            customerList.Add(customerTemp3);
            customerList.Add(customerTemp4);

            return customerList;
        }

        public static ProductList ProductList()
        {
            ProductList productList = new ProductList();
            Product productTemp1 = new Product();
            Product productTemp2 = new Product();
            Product productTemp3 = new Product();
            Product productTemp4 = new Product();
            Product productTemp5 = new Product();
            productList.MinStock = 20;

            productTemp1.ProductId = 1;
            productTemp1.Name = "Zanahoria";
            productTemp1.Price = 10;
            productTemp1.Stock = 15;

            productTemp2.ProductId = 3;
            productTemp2.Name = "Manzana";
            productTemp2.Price = 12;
            productTemp2.Stock = 10;

            productTemp3.ProductId = 5;
            productTemp3.Name = "Col";
            productTemp3.Price = 16;
            productTemp3.Stock = 25;

            productTemp4.ProductId = 7;
            productTemp4.Name = "Zapallo";
            productTemp4.Price = 5;
            productTemp4.Stock = 20;

            productList.ProductsList.Add(productTemp1);
            productList.ProductsList.Add(productTemp2);
            productList.ProductsList.Add(productTemp3);
            productList.ProductsList.Add(productTemp4);

            return productList;
        }

        public static List<Invoice> InvoiceList()
        {
            List<Invoice> invoiceList = new List<Invoice>();
            Invoice invoiceTemp1 = new Invoice();
            Invoice invoiceTemp2 = new Invoice();
            Invoice invoiceTemp3 = new Invoice();
            Invoice invoiceTemp4 = new Invoice();
            Invoice invoiceTemp5 = new Invoice();

            invoiceTemp1.InvoiceId = 1;
            invoiceTemp1.ProductId = 3;
            invoiceTemp1.ProductQuantity = 2;
            invoiceTemp1.ProductPrice = 12;
            invoiceTemp1.CustomerId = 10;
            invoiceTemp1.SellerId = 1;
            invoiceTemp1.RecordDate = DateTime.Now;

            invoiceTemp2.InvoiceId = 2;
            invoiceTemp2.ProductId = 1;
            invoiceTemp1.ProductQuantity = 3;
            invoiceTemp1.ProductPrice = 10;
            invoiceTemp2.CustomerId = 11;
            invoiceTemp2.SellerId = 1;
            invoiceTemp2.RecordDate = DateTime.Now;

            invoiceTemp3.InvoiceId = 3;
            invoiceTemp3.ProductId = 5;
            invoiceTemp1.ProductQuantity = 3;
            invoiceTemp1.ProductPrice = 16;
            invoiceTemp3.CustomerId = 12;
            invoiceTemp3.SellerId = 1;
            invoiceTemp3.RecordDate = DateTime.Now;

            invoiceTemp4.InvoiceId = 4;
            invoiceTemp4.ProductId = 7;
            invoiceTemp1.ProductQuantity = 3;
            invoiceTemp1.ProductPrice = 5;
            invoiceTemp4.CustomerId = 13;
            invoiceTemp4.SellerId = 1;
            invoiceTemp4.RecordDate = DateTime.Now;

            invoiceTemp5.InvoiceId = 5;
            invoiceTemp5.ProductId = 3;
            invoiceTemp1.ProductQuantity = 7;
            invoiceTemp1.ProductPrice = 12;
            invoiceTemp5.CustomerId = 11;
            invoiceTemp5.SellerId = 1;
            invoiceTemp5.RecordDate = DateTime.Now;

            invoiceList.Add(invoiceTemp1);
            invoiceList.Add(invoiceTemp2);
            invoiceList.Add(invoiceTemp3);
            invoiceList.Add(invoiceTemp4);
            invoiceList.Add(invoiceTemp5);

            return invoiceList;
        }
        static void Main(string[] args)
        {
            List<Customer> customerList = new List<Customer>();
            ProductList productList = new ProductList();
            List<Product> productMinStockList = new List<Product>();
            List<Invoice> invoiceList = new List<Invoice>();
            
            List<Customer> customer55List = new List<Customer>();
            List<Customer> customerBirthDayList = new List<Customer>();

            customerList = CustomerList();
            productList = ProductList();
            invoiceList = InvoiceList();

            Seller sellerTemp = new Seller();
            sellerTemp.SellerId = 1;
            sellerTemp.Name = "Carlos Bodger";

            float SalesTotal = 0;
            foreach(var invoice in invoiceList)
            {
                Customer customer55 = new Customer();
                Customer customerBirthDay = new Customer();
                int customerId = invoice.CustomerId;

                SalesTotal+= invoice.ProductPrice*invoice.ProductQuantity;

                customer55 = customerList.Find(x => x.CustomerId == customerId && x.Age > 55);
                customerBirthDay = customerList.Find(x => x.CustomerId == customerId && x.BirthDate.Month == DateTime.Now.Month);
                
                if(customer55 != null && !customer55List.Contains(customer55))
                    customer55List.Add(customer55);
                
                if(customerBirthDay != null && !customerBirthDayList.Contains(customerBirthDay))
                    customerBirthDayList.Add(customerBirthDay);
            }

            for(int i=0; i< productList.ProductsList.Count; i++)
            {
                if(productList.ProductsList[i].Stock <= productList.MinStock)
                {
                    Product productMinStock = new Product();
                    productMinStock = productList.ProductsList[i];
                    productMinStockList.Add(productMinStock);
                }
            }


            Console.WriteLine("Total Ventas: " + SalesTotal);
            Console.WriteLine("");

            Console.WriteLine("Clientes mayores a 55 anios: ");
            foreach(var customer in customer55List)
            {
                Console.WriteLine($"Nombres: {customer.Name}, Anios: {customer.Age}");
            }
            
            Console.WriteLine("");

            Console.WriteLine("Clientes que cumplan anios este mes: ");
            foreach(var customer in customerBirthDayList)
            {
                Console.WriteLine($"Nombres: {customer.Name}, Anios: {customer.Age}");
            }
            
            Console.WriteLine("");
            
            Console.WriteLine("Productos con stock que estan en el minimo o por debajo: ");
            foreach(var product in productMinStockList)
            {
                Console.WriteLine($"Nombres: {product.Name}, Anios: {product.Stock}");
            }
            
            Console.WriteLine("");

            /*Console.WriteLine("Ingresar valor! - ");
            string a = Console.ReadLine();
            DateTime year = DateTime.Parse(a);

            Console.WriteLine("Valor ingresado" + year + " - " + a);*/
        }
    }
}
