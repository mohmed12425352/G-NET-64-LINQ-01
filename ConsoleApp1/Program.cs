using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQAssignments
{
    class Program
    {
        static void Main(string[] args)
        {
            var products = ListGenerator.ProductList;
            var customers = ListGenerator.CustomerList;

            #region Question 01: All products from "Seafood" category
            Console.WriteLine("=== Question 01: Seafood Products ===");
            var q01 = products.Where(p => p.Category == "Seafood");
            foreach (var p in q01)
                Console.WriteLine($"{p.ProductName} - {p.UnitPrice:C}");
            #endregion

            #region Question 02: List of product names
            Console.WriteLine("\n=== Question 02: Product Names Only ===");
            var q02 = products.Select(p => p.ProductName);
            foreach (var name in q02)
                Console.WriteLine(name);
            #endregion

            #region Question 03: Sort products by UnitPrice (ascending)
            Console.WriteLine("\n=== Question 03: Sorted by Price (Ascending) ===");
            var q03 = products.OrderBy(p => p.UnitPrice);
            foreach (var p in q03)
                Console.WriteLine($"{p.ProductName} - {p.UnitPrice:C}");
            #endregion

            #region Question 04: Products with UnitPrice between 10 and 30
            Console.WriteLine("\n=== Question 04: Products Price Between 10 and 30 ===");
            var q04 = products.Where(p => p.UnitPrice >= 10 && p.UnitPrice <= 30);
            foreach (var p in q04)
                Console.WriteLine($"{p.ProductName} - {p.UnitPrice:C}");
            #endregion

            #region Question 05: In-stock Condiments products
            Console.WriteLine("\n=== Question 05: In Stock Condiments ===");
            var q05 = products.Where(p => p.UnitsInStock > 0 && p.Category == "Condiments");
            foreach (var p in q05)
                Console.WriteLine($"{p.ProductName} (Stock: {p.UnitsInStock}) - {p.UnitPrice:C}");
            #endregion

            #region Question 06: Anonymous type (Name, Price, StockStatus)
            Console.WriteLine("\n=== Question 06: Anonymous Type with StockStatus ===");
            var q06 = products.Select(p => new
            {
                Name = p.ProductName,
                Price = p.UnitPrice,
                StockStatus = p.UnitsInStock > 0 ? "Available" : "Out of Stock"
            });
            foreach (var item in q06)
                Console.WriteLine($"{item.Name} | {item.Price:C} | {item.StockStatus}");
            #endregion

            #region Question 07 & 11: Position (1-based) alongside ProductName
            Console.WriteLine("\n=== Question 07 & 11: 1-Based Position Number alongside ProductName ===");
            var q07 = products.Select((p, index) => $"{index + 1}. {p.ProductName}");
            foreach (var item in q07)
                Console.WriteLine(item);
            #endregion

            #region Question 08: Sort by Category ASC, then UnitPrice DESC
            Console.WriteLine("\n=== Question 08: Sort by Category ASC, then UnitPrice DESC ===");
            var q08 = products.OrderBy(p => p.Category).ThenByDescending(p => p.UnitPrice);
            foreach (var p in q08)
                Console.WriteLine($"[{p.Category}] {p.ProductName} - {p.UnitPrice:C}");
            #endregion

            #region Question 09: Beverages sorted by UnitsInStock DESC
            Console.WriteLine("\n=== Question 09: Beverages Sorted by Stock DESC ===");
            var q09 = products.Where(p => p.Category == "Beverages").OrderByDescending(p => p.UnitsInStock);
            foreach (var p in q09)
                Console.WriteLine($"{p.ProductName} - Stock: {p.UnitsInStock}");
            #endregion

            #region Question 10: Query Syntax compound from (Orders in 1997 or later)
            Console.WriteLine("\n=== Question 10: Orders placed in 1997 or later (Query Syntax) ===");
            var q10 = from c in customers
                      from o in c.Orders
                      where o.OrderDate.Year >= 1997
                      select new { c.CustomerID, o.OrderID, o.OrderDate, o.Total };

            foreach (var item in q10)
                Console.WriteLine($"Customer: {item.CustomerID} | Order ID: {item.OrderID} | Date: {item.OrderDate:yyyy-MM-dd} | Total: {item.Total:C}");
            #endregion

            #region Question 12: Sort by word length then case-insensitive
            Console.WriteLine("\n=== Question 12: Sort by Word Length then Case-Insensitive ===");
            string[] arr = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };
            var q12 = arr.OrderBy(w => w.Length).ThenBy(w => w, StringComparer.OrdinalIgnoreCase);
            foreach (var word in q12)
                Console.WriteLine(word);
            #endregion

            #region Question 13: Digits with second letter 'i', reversed
            Console.WriteLine("\n=== Question 13: Digits with 2nd letter 'i', reversed ===");
            string[] digits = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
            var q13 = digits.Where(d => d.Length > 1 && d[1] == 'i').Reverse();
            foreach (var digit in q13)
                Console.WriteLine(digit);
            #endregion

            Console.WriteLine("\nLINQ Assignment 01 completed successfully!");
        }
    }
}
