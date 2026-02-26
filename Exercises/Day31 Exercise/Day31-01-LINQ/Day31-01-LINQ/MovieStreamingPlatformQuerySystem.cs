using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day31_01_LINQ
{
    class Movie { public string Title; public string Genre; public double Rating; public int Year; }
    internal class MovieStreamingPlatformQuerySystem
    {
        static void Main(string[] args)
        {
            var movies = new List<Movie>
            {
                new Movie{Title="Inception", Genre="SciFi", Rating=9, Year=2010},
                new Movie{Title="Avatar", Genre="SciFi", Rating=8.5, Year=2009},
                new Movie{Title="Titanic", Genre="Drama", Rating=8, Year=1997}
            };
            //Filter movies with rating > 8
            var filterMovies = movies.Where(m => m.Rating > 8);
            Console.WriteLine("Movies with rating>8: ");
            foreach (var item in filterMovies)
            {
                Console.WriteLine(item.Title);
            }
            //Group movies by Genre and get average rating
            var GenreMovies = movies.GroupBy(m => m.Genre).Select(y => new { Genre = y.Key, Avg = y.Average(m => m.Rating) });
            Console.WriteLine("\nGroup movies by Genre and get average rating");
            foreach (var item in GenreMovies)
            {
                Console.WriteLine($"{item.Genre}: {item.Avg:F2}");
            }
            //Find latest movie per Genre
            var latestMovie = movies.GroupBy(m => m.Genre).Select(g => g.OrderByDescending(m => m.Year).FirstOrDefault());
            Console.WriteLine("\nLatest Movie per Genre");
            foreach (var item in latestMovie)
            {
                Console.WriteLine($"{item.Genre}: {item.Title} - {item.Year}");
            }
            //Get top 5 highest-rated movies
            var highestRatedMovie = movies.OrderByDescending(m => m.Rating).Take(5);
            Console.WriteLine("\nTop 5 highest-rated movies: ");
            foreach (var item in highestRatedMovie)
            {
                Console.WriteLine($"{item.Title} - {item.Rating}");
            }
        }
    }
}
