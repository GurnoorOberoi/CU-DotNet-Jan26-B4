using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day31_01_LINQ
{
    class User { public int Id; public string Name; public string Country; }
    class Post { public int UserId; public int Likes; }
    internal class SocialMediaUserAnalytics
    {
        static void Main(string[] args)
        {
            var users = new List<User>
            {
                new User{Id=1, Name="A", Country="India"},
                new User{Id=2, Name="B", Country="USA"}
            };

            var posts = new List<Post>
            {
                new Post{UserId=1, Likes=100},
                new Post{UserId=1, Likes=50}
            };
            //Get top users by total likes
            var topUsers = users.GroupJoin(posts, u => u.Id, p => p.UserId, (u, p) => new { u.Name, TotalLikes = p.Sum(x => x.Likes) }).OrderByDescending(x => x.TotalLikes);
            Console.WriteLine("Top Users by Total Likes: ");
            foreach (var item in topUsers)
            {
                Console.WriteLine($"{item.Name}: {item.TotalLikes} likes");
            }
            //Group users by country
            var groupByCountey = users.GroupBy(u => u.Country);
            Console.WriteLine("\nGroup users by country:");
            foreach (var item in groupByCountey)
            {
                Console.Write(item.Key);
                foreach (var co in item)
                {
                    Console.WriteLine($" " + co.Name);
                }
            }
            //List inactive users (no posts)
            var inactiveUsers = users.GroupJoin(posts, u => u.Id, p => p.UserId, (u, p) => new { u.Name, Count = p.Count() }).Where(x => x.Count == 0);
            Console.WriteLine("\nInactive Users");
            foreach (var item in inactiveUsers)
            {
                Console.WriteLine(item.Name);
            }
            //Calculate average likes per post
            var averageLikes = posts.Average(p => p.Likes);
            Console.WriteLine($"\nAverage Likes per Post: {averageLikes}");
        }
    }
}
