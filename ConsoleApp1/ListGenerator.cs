using System;
using System.Collections.Generic;

namespace LINQAssignments
{
    public class Product
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string Category { get; set; }
        public decimal UnitPrice { get; set; }
        public int UnitsInStock { get; set; }

        public override string ToString() =>
            $"ID: {ProductID} | Name: {ProductName} | Category: {Category} | Price: {UnitPrice:C} | Stock: {UnitsInStock}";
    }

    public class Order
    {
        public int OrderID { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal Total { get; set; }

        public override string ToString() => $"Order {OrderID}: {OrderDate:yyyy-MM-dd}, Total: {Total:C}";
    }

    public class Customer
    {
        public string CustomerID { get; set; }
        public string CompanyName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public Order[] Orders { get; set; }

        public override string ToString() => $"{CustomerID} - {CompanyName}, {City}, {Country}";
    }

    public static class ListGenerator
    {
        public static List<Product> ProductList = new()
        {
            new Product { ProductID = 1, ProductName = "Chai", Category = "Beverages", UnitPrice = 18.00m, UnitsInStock = 39 },
            new Product { ProductID = 2, ProductName = "Chang", Category = "Beverages", UnitPrice = 19.00m, UnitsInStock = 17 },
            new Product { ProductID = 3, ProductName = "Aniseed Syrup", Category = "Condiments", UnitPrice = 10.00m, UnitsInStock = 13 },
            new Product { ProductID = 4, ProductName = "Chef Anton's Cajun Seasoning", Category = "Condiments", UnitPrice = 22.00m, UnitsInStock = 53 },
            new Product { ProductID = 5, ProductName = "Chef Anton's Gumbo Mix", Category = "Condiments", UnitPrice = 21.35m, UnitsInStock = 0 },
            new Product { ProductID = 6, ProductName = "Grandma's Boysenberry Spread", Category = "Condiments", UnitPrice = 25.00m, UnitsInStock = 120 },
            new Product { ProductID = 7, ProductName = "Uncle Bob's Organic Dried Pears", Category = "Produce", UnitPrice = 30.00m, UnitsInStock = 15 },
            new Product { ProductID = 8, ProductName = "Northwoods Cranberry Sauce", Category = "Condiments", UnitPrice = 40.00m, UnitsInStock = 6 },
            new Product { ProductID = 9, ProductName = "Mishi Kobe Niku", Category = "Meat/Poultry", UnitPrice = 97.00m, UnitsInStock = 29 },
            new Product { ProductID = 10, ProductName = "Ikura", Category = "Seafood", UnitPrice = 31.00m, UnitsInStock = 31 },
            new Product { ProductID = 11, ProductName = "Queso Cabrales", Category = "Dairy Products", UnitPrice = 21.00m, UnitsInStock = 22 },
            new Product { ProductID = 12, ProductName = "Queso Manchego La Pastora", Category = "Dairy Products", UnitPrice = 38.00m, UnitsInStock = 86 },
            new Product { ProductID = 13, ProductName = "Konbu", Category = "Seafood", UnitPrice = 6.00m, UnitsInStock = 24 },
            new Product { ProductID = 14, ProductName = "Tofu", Category = "Produce", UnitPrice = 23.25m, UnitsInStock = 35 },
            new Product { ProductID = 15, ProductName = "Genen Shouyu", Category = "Condiments", UnitPrice = 15.50m, UnitsInStock = 39 },
            new Product { ProductID = 16, ProductName = "Pavlova", Category = "Confections", UnitPrice = 17.45m, UnitsInStock = 29 },
            new Product { ProductID = 17, ProductName = "Alice Mutton", Category = "Meat/Poultry", UnitPrice = 39.00m, UnitsInStock = 0 },
            new Product { ProductID = 18, ProductName = "Carnarvon Tigers", Category = "Seafood", UnitPrice = 62.50m, UnitsInStock = 42 },
            new Product { ProductID = 19, ProductName = "Teatime Chocolate Biscuits", Category = "Confections", UnitPrice = 9.20m, UnitsInStock = 25 },
            new Product { ProductID = 20, ProductName = "Sir Rodney's Marmalade", Category = "Confections", UnitPrice = 81.00m, UnitsInStock = 40 }
        };

        public static List<Customer> CustomerList = new()
        {
            new Customer
            {
                CustomerID = "ALFKI",
                CompanyName = "Alfreds Futterkiste",
                City = "Berlin",
                Country = "Germany",
                Orders = new Order[]
                {
                    new Order { OrderID = 10643, OrderDate = new DateTime(1997, 8, 25), Total = 814.50m },
                    new Order { OrderID = 10692, OrderDate = new DateTime(1997, 10, 3), Total = 878.00m }
                }
            },
            new Customer
            {
                CustomerID = "ANATR",
                CompanyName = "Ana Trujillo Emparedados",
                City = "México D.F.",
                Country = "Mexico",
                Orders = new Order[]
                {
                    new Order { OrderID = 10308, OrderDate = new DateTime(1996, 9, 18), Total = 88.80m },
                    new Order { OrderID = 10625, OrderDate = new DateTime(1997, 8, 8), Total = 479.75m }
                }
            },
            new Customer
            {
                CustomerID = "ANTON",
                CompanyName = "Antonio Moreno Taquería",
                City = "México D.F.",
                Country = "Mexico",
                Orders = new Order[]
                {
                    new Order { OrderID = 10365, OrderDate = new DateTime(1996, 11, 27), Total = 403.20m },
                    new Order { OrderID = 10507, OrderDate = new DateTime(1997, 4, 15), Total = 749.06m }
                }
            },
            new Customer
            {
                CustomerID = "AROUT",
                CompanyName = "Around the Horn",
                City = "London",
                Country = "UK",
                Orders = new Order[]
                {
                    new Order { OrderID = 10355, OrderDate = new DateTime(1996, 11, 15), Total = 480.00m },
                    new Order { OrderID = 10383, OrderDate = new DateTime(1996, 12, 16), Total = 899.00m },
                    new Order { OrderID = 10741, OrderDate = new DateTime(1997, 11, 14), Total = 297.00m }
                }
            }
        };
    }
}
