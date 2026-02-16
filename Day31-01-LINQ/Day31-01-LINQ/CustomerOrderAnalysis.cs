using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day31_01_LINQ
{
    class Customer { public int Id; public string Name; public string City; }
    class Order { public int OrderId; public int CustomerId; public double Amount; }
    internal class CustomerOrderAnalysis
    {
        static void Main(string[] args)
        {
            var customers = new List<Customer>
            {
                new Customer{Id=1, Name="Ajay", City="Delhi"},
                new Customer{Id=2, Name="Sunita", City="Mumbai"}
            };

            var orders = new List<Order>
            {
                new Order{OrderId=1, CustomerId=1, Amount=20000},
                new Order{OrderId=2, CustomerId=1, Amount=40000}
            };
            //Get total order amount per customer
            var totalOrderAmount = customers.GroupJoin(orders, c => c.Id, o => o.CustomerId, (c, o) => new { Customer = c.Name, Total = o.Sum(o => o.Amount) });
            Console.WriteLine("Total Order Amount per Customer");
            foreach (var item in totalOrderAmount)
            {
                Console.WriteLine($"{item.Customer}: {item.Total}");
            }
            //List customers with no orders
            var noOrders = customers.Where(c => !orders.Any(o => o.CustomerId == c.Id));
            Console.WriteLine("\nCustomers with no Orders:");
            foreach(var item in noOrders)
            {
                Console.WriteLine(item.Name);
            }
            //Get customers who spent above ₹50,000
            var spentAbove50000 = customers.GroupJoin(orders, c => c.Id, o => o.CustomerId, (c, o) => new { Customer = c.Name, Total = o.Sum(o => o.Amount) }).Where(x => x.Total > 50000);
            Console.WriteLine("\nCustomers who spent above 50000");
            foreach (var item in spentAbove50000)
            {
                Console.WriteLine($"{item.Customer}: {item.Total}");
            }
            //Sort customers by total spending
            var sortCustomer = customers.GroupJoin(orders, c => c.Id, o => o.CustomerId, (c, o) => new { Customer = c.Name, Total = o.Sum(o => o.Amount) }).OrderByDescending(x => x.Total);
            Console.WriteLine("\nSort customers by total spending");
            foreach (var item in sortCustomer)
            {
                Console.WriteLine($"{item.Customer}: {item.Total}");
            }
        }
    }
}
