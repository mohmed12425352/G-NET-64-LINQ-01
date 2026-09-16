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

            #region Question 01: Top 3 most expensive products
            Console.WriteLine("=== Question 01: Top 3 Most Expensive Products ===");
            var q01 = products.OrderByDescending(p => p.UnitPrice).Take(3);
            foreach (var p in q01) Console.WriteLine($"{p.ProductName} - {p.UnitPrice:C}");
            #endregion

            #region Question 02: Page 2 of products (Page Size = 5)
            Console.WriteLine("\n=== Question 02: Page 2 (Page Size 5) ===");
            var q02 = products.Skip(5).Take(5);
            foreach (var p in q02) Console.WriteLine(p);
            #endregion

            #region Question 03: TakeWhile UnitPrice < $25
            Console.WriteLine("\n=== Question 03: TakeWhile Price < $25 (Sorted) ===");
            var sortedByPrice = products.OrderBy(p => p.UnitPrice);
            var q03 = sortedByPrice.TakeWhile(p => p.UnitPrice < 25.00m);
            foreach (var p in q03) Console.WriteLine($"{p.ProductName} - {p.UnitPrice:C}");
            #endregion

            #region Question 04: Check if ALL Seafood products are in stock
            Console.WriteLine("\n=== Question 04: Are ALL Seafood Products in stock? ===");
            bool allSeafoodInStock = products.Where(p => p.Category == "Seafood").All(p => p.UnitsInStock > 0);
            Console.WriteLine($"All Seafood in stock: {allSeafoodInStock}");
            #endregion

            #region Question 05: Check if ID list contains 9
            Console.WriteLine("\n=== Question 05: Does ID list contain 9? ===");
            int[] ids = { 3, 9, 13, 18 };
            bool contains9 = ids.Contains(9);
            Console.WriteLine($"Contains 9: {contains9}");
            #endregion

            #region Question 06: Group by Category with product count
            Console.WriteLine("\n=== Question 06: Group by Category with Count ===");
            var q06 = products.GroupBy(p => p.Category);
            foreach (var group in q06)
                Console.WriteLine($"Category: {group.Key} -> Count: {group.Count()}");
            #endregion

            #region Question 07: Group by Category projecting product names
            Console.WriteLine("\n=== Question 07: Group by Category (Product Names) ===");
            var q07 = products.GroupBy(p => p.Category, p => p.ProductName);
            foreach (var group in q07)
            {
                Console.WriteLine($"Category: {group.Key}");
                foreach (var name in group) Console.WriteLine($"  - {name}");
            }
            #endregion

            #region Question 08: Categories with MORE THAN 3 products
            Console.WriteLine("\n=== Question 08: Categories with > 3 Products ===");
            var q08 = products.GroupBy(p => p.Category).Where(g => g.Count() > 3);
            foreach (var group in q08)
                Console.WriteLine($"Category: {group.Key} (Count: {group.Count()})");
            #endregion

            #region Question 09: Query Syntax group customers by Country with TotalOrderValue
            Console.WriteLine("\n=== Question 09: Group Customers by Country (Query Syntax) ===");
            var q09 = from c in customers
                      group c by c.Country into g
                      select new
                      {
                          Country = g.Key,
                          Count = g.Count(),
                          TotalOrderValue = g.SelectMany(c => c.Orders).Sum(o => o.Total)
                      };

            foreach (var item in q09)
                Console.WriteLine($"Country: {item.Country} | Customers: {item.Count} | Total Order Value: {item.TotalOrderValue:C}");
            #endregion

            #region Question 10: Total units in stock across all products
            Console.WriteLine("\n=== Question 10: Total Units in Stock ===");
            int totalStock = products.Sum(p => p.UnitsInStock);
            Console.WriteLine($"Total Units in Stock: {totalStock}");
            #endregion

            #region Question 11: Cheapest and Most Expensive product prices
            Console.WriteLine("\n=== Question 11: Min and Max Prices ===");
            decimal minPrice = products.Min(p => p.UnitPrice);
            decimal maxPrice = products.Max(p => p.UnitPrice);
            Console.WriteLine($"Cheapest Price: {minPrice:C} | Most Expensive Price: {maxPrice:C}");
            #endregion

            #region Question 12: Distinct list of categories
            Console.WriteLine("\n=== Question 12: Distinct Categories ===");
            var distinctCategories = products.Select(p => p.Category).Distinct();
            foreach (var cat in distinctCategories) Console.WriteLine(cat);
            #endregion

            #region Question 13: Product IDs in setA but NOT in setB
            Console.WriteLine("\n=== Question 13: Except (setA - setB) ===");
            int[] setA = { 1, 3, 5, 7, 9, 11, 13 };
            int[] setB = { 3, 6, 9, 12, 15, 13 };
            var exceptSet = setA.Except(setB);
            Console.WriteLine(string.Join(", ", exceptSet));
            #endregion

            #region Question 14: Countries in list1 but NOT in list2 (case-insensitive)
            Console.WriteLine("\n=== Question 14: Countries Except (Case-Insensitive) ===");
            string[] list1 = { "Germany", "France", "UK", "Spain" };
            string[] list2 = { "france", "SPAIN", "Italy" };
            var diffCountries = list1.Except(list2, StringComparer.OrdinalIgnoreCase);
            Console.WriteLine(string.Join(", ", diffCountries));
            #endregion

            #region Question 15: Dictionary<int, Product> lookup ID = 18
            Console.WriteLine("\n=== Question 15: ToDictionary and Lookup ID = 18 ===");
            var productDict = products.ToDictionary(p => p.ProductID);
            if (productDict.TryGetValue(18, out var p18))
                Console.WriteLine($"Found Product: {p18}");
            #endregion

            #region Question 16: First product with Price > $50
            Console.WriteLine("\n=== Question 16: First Product Price > $50 ===");
            var firstOver50 = products.First(p => p.UnitPrice > 50);
            Console.WriteLine($"First > $50: {firstOver50.ProductName} ({firstOver50.UnitPrice:C})");
            #endregion

            #region Question 17: FirstOrDefault Price > $500 (safe null)
            Console.WriteLine("\n=== Question 17: FirstOrDefault Price > $500 ===");
            var firstOver500 = products.FirstOrDefault(p => p.UnitPrice > 500);
            Console.WriteLine($"Product > $500: {(firstOver500 == null ? "null (Safe - No Exception)" : firstOver500.ProductName)}");
            #endregion

            #region Question 18: Multiplication table row for 7
            Console.WriteLine("\n=== Question 18: Multiplication Table for 7 ===");
            var table7 = Enumerable.Range(1, 12).Select(i => $"7 x {i} = {7 * i}");
            foreach (var line in table7) Console.WriteLine(line);
            #endregion

            #region Question 19: Even numbers between 1 and 30
            Console.WriteLine("\n=== Question 19: Even Numbers between 1 and 30 ===");
            var evenNumbers = Enumerable.Range(1, 30).Where(n => n % 2 == 0);
            Console.WriteLine(string.Join(", ", evenNumbers));
            #endregion

            #region Question 20: Concat 3 product names with 3 company names
            Console.WriteLine("\n=== Question 20: Concat Product Names and Customer Companies ===");
            var concatSeq = products.Take(3).Select(p => p.ProductName)
                                    .Concat(customers.Take(3).Select(c => c.CompanyName));
            foreach (var item in concatSeq) Console.WriteLine(item);
            #endregion

            #region Question 21: Zip products with customers
            Console.WriteLine("\n=== Question 21: Zip Product with Customer ===");
            var zipped = products.Zip(customers, (p, c) => $"{p.ProductName} sold to {c.CompanyName}");
            foreach (var line in zipped) Console.WriteLine(line);
            #endregion

            Console.WriteLine("\nLINQ Assignment 02 completed successfully!");
        }
    }
}
