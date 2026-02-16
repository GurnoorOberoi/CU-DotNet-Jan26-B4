using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day31_01_LINQ
{
    class Product { public int Id; public string Name; public string Category; public double Price; }
    class Sale { public int ProductId; public int Qty; }
    internal class ProductInventoryandSalesQuery
    {
        static void Main(string[] args)
        {
            var products = new List<Product>
            {
            new Product{Id=1, Name="Laptop", Category="Electronics", Price=50000},
            new Product{Id=2, Name="Phone", Category="Electronics", Price=20000},
            new Product{Id=3, Name="Table", Category="Furniture", Price=5000}
            };

            var sales = new List<Sale>
            {
            new Sale{ProductId=1, Qty=10},
            new Sale{ProductId=2, Qty=20}
            };
            //Join Products with Sales
            var JoinData = products.Join(sales, o => o.Id, i => i.ProductId, (x, y) => new { x.Name, y.Qty });
            foreach (var item in JoinData)
            {
                Console.WriteLine($"{item.Name} - {item.Qty}");
            }
            //Calculate total revenue per product
            var totalRevenue = products.GroupJoin(sales, p => p.Id, s => s.ProductId, (p, s) => new { ProductName = p.Name, Revenue = s.Sum(x => x.Qty * p.Price) });
            Console.WriteLine("\nTotal revenue per product: ");
            foreach (var item in totalRevenue)
            {
                Console.WriteLine($"{item.ProductName} - {item.Revenue}");
            }
            //Get best-selling product
            var bestSellingProduct = totalRevenue.OrderByDescending(x => x.Revenue).First();
            Console.WriteLine($"\nBest-Selling product: {bestSellingProduct.ProductName}");
            //List products with zero sales
            var zeroSales = products.GroupJoin(sales, p => p.Id, s => s.ProductId, (p, s) => new { ProductName = p.Name, TotalQty = s.Sum(x => x.Qty) }).Where(x => x.TotalQty == 0);
            Console.WriteLine("\nProducts with Zero Sales:");
            foreach (var item in zeroSales)
            {
                Console.WriteLine(item.ProductName);
            }
        }
    }
}
