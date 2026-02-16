using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day31_01_LINQ
{
    class Student
    {
        public int Id;
        public string Name;
        public string Class;
        public int Marks;
    }
    internal class StudentPerformanceAnalytics
    {
        static void Main(string[] args)
        {
            var students = new List<Student>
            {
            new Student{Id=1, Name="Amit", Class="10A", Marks=85},
            new Student{Id=2, Name="Neha", Class="10A", Marks=72},
            new Student{Id=3, Name="Rahul", Class="10B", Marks=90},
            new Student{Id=4, Name="Pooja", Class="10B", Marks=60},
            new Student{Id=5, Name="Kiran", Class="10A", Marks=95}
            };
            //Get top 3 students by marks
            var topThree = students.OrderByDescending(o => o.Marks).Take(3);
            Console.WriteLine("Top 3 Students are: ");
            foreach (var item in topThree)
            {
                Console.WriteLine(item.Name + "-" + item.Marks);
            }
            //Group students by Class and calculate average marks
            var groupByClasses = students.GroupBy(g => g.Class).Select(g => new { Class = g.Key, Avg = g.Average(s => s.Marks) });
            Console.WriteLine("\nClass Wise Average Marks");
            foreach (var item in groupByClasses)
            {
                Console.WriteLine(item.Class + "-" + item.Avg);
            }
            //List students who scored below class average
            var studentBelowAvg = students.Where(s => s.Marks < students.Where(x => x.Class == s.Class).Average(x => x.Marks));
            Console.WriteLine("\nStudents Below Average");
            foreach (var item in studentBelowAvg)
            {
                Console.WriteLine(item.Class + " " + item.Name + " - " + item.Marks);
            }
            //Order students by Class then by Marks descending
            var orderd = students.OrderBy(g => g.Class).ThenByDescending(g => g.Marks);
            Console.WriteLine("\nOrder students by Class then by ");
            foreach (var item in orderd)
            {
                Console.WriteLine(item.Name + " " + item.Class + " - " + item.Marks);
            }
        }
    }
}


