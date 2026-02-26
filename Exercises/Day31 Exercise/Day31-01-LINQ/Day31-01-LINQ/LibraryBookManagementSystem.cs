using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day31_01_LINQ
{
    class Book { public string Title; public string Author; public string Genre; public int Year; public double Price; }
    internal class LibraryBookManagementSystem
    {
        static void Main(string[] args)
        {
            var books = new List<Book>
            {
                new Book{Title="C# Basics", Author="John", Genre="Tech", Year=2018, Price=500},
                new Book{Title="Java Advanced", Author="Mike", Genre="Tech", Year=2016, Price=700},
                new Book{Title="History India", Author="Raj", Genre="History", Year=2019, Price=400}
            };
            //Find books published after 2015
            var publishedAfter2015 = books.Where(b => b.Year > 2015);
            Console.WriteLine("Books Published after 2015: ");
            foreach (var item in publishedAfter2015)
            {
                Console.WriteLine(item.Title);
            }
            //Group by Genre and count books
            var GenreBook = books.GroupBy(b => b.Genre).Select(g => new { Genre = g.Key, Count = g.Count() });
            Console.WriteLine("\nGroup by Genre and count books: ");
            foreach (var item in GenreBook)
            {
                Console.WriteLine($"{item.Genre}: {item.Count}");
            }
            //Get most expensive book per Genre
            var expensiveBook = books.GroupBy(b => b.Genre).Select(g => g.OrderByDescending(b => b.Price).FirstOrDefault());
            Console.WriteLine("\nMost Expensive Book Per Genre:");
            foreach (var item in expensiveBook)
            {
                Console.WriteLine($"{item.Genre}:{item.Title} - {item.Price}");
            }
            //Return distinct authors list
            var distinctList = books.Select(b => b.Author).Distinct();
            Console.WriteLine("\nDistinct Authors List:");
            foreach (var item in distinctList)
            {
                Console.WriteLine(item);
            }
        }
    }
}
