using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day31_01_LINQ
{
    class CartItem { public string Name; public string Category; public double Price; public int Qty; }
    internal class E_CommerceCartProcessing
    {
        static void Main(string[] args)
        {
            var cart = new List<CartItem>
            {
                new CartItem{Name="TV", Category="Electronics", Price=30000, Qty=1},
                new CartItem{Name="Sofa", Category="Furniture", Price=15000, Qty=1}
            };
            //Calculate total cart value
            var totalCartValue = cart.Sum(c => c.Price * c.Qty);
            Console.WriteLine("Total Cart value: " + totalCartValue);
            //Group by Category and total category cost
            var totalCategoryCost = cart.GroupBy(c => c.Category).Select(g => new { Category = g.Key, Total = g.Sum(c => c.Price * c.Qty) });
            Console.WriteLine("\nGroup by Category and total category cost");
            foreach (var item in totalCategoryCost)
            {
                Console.WriteLine($"{item.Category}: {item.Total}");
            }
            //Apply 10% discount for Electronics category
            var discountForElectronics = cart.Select(c => new { c.Name, c.Category, FinalPrice = c.Category == "Electronics" ? c.Price * 0.9 * c.Qty : c.Price * c.Qty });
            Console.WriteLine("\nDiscount for Electronics category: ");
            foreach (var item in discountForElectronics)
            {
                Console.WriteLine($"{item.Name}: {item.Category} - {item.FinalPrice}");
            }
            //Return cart summary DTO objects
            var summary = cart.Select(c => new { c.Name, c.Category, Total = c.Price * c.Qty });
            Console.WriteLine("\nCart Summary: ");
            foreach (var item in summary)
            {
                Console.WriteLine($"{item.Name}: {item.Category} - {item.Total}");
            }
        }
    }
}
