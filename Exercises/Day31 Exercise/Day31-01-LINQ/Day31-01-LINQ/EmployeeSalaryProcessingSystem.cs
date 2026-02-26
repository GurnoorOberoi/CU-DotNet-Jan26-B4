using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day31_01_LINQ
{
    class Employee
    {
        public int Id;
        public string Name;
        public string Dept;
        public double Salary;
        public DateTime JoinDate;
    }
    internal class EmployeeSalaryProcessingSystem
    {
        static void Main(string[] args)
        {
            var employees = new List<Employee>
            {
            new Employee{Id=1, Name="Ravi", Dept="IT", Salary=80000, JoinDate=new DateTime(2019,1,10)},
            new Employee{Id=2, Name="Anita", Dept="HR", Salary=60000, JoinDate=new DateTime(2021,3,5)},
            new Employee{Id=3, Name="Suresh", Dept="IT", Salary=120000, JoinDate=new DateTime(2018,7,15)},
            new Employee{Id=4, Name="Meena", Dept="Finance", Salary=90000, JoinDate=new DateTime(2022,9,1)}
            };
            //Get highest and lowest salary in each department
            var minMaxSalary = employees.GroupBy(e => e.Dept).Select(g => new { Department = g.Key, Highest = g.Max(e => e.Salary), Lowest = g.Min(e => e.Salary) });
            foreach (var item in minMaxSalary)
            {
                Console.WriteLine(item.Department + " " + item.Highest);
                Console.WriteLine(item.Department + " " + item.Lowest);
            }
            //Count employees per department
            var NoOfEmployee = employees.GroupBy(e => e.Dept).Select(g => new { Deparment = g.Key, Count = g.Count() });
            foreach (var item in NoOfEmployee)
            {
                Console.WriteLine($"\n{item.Deparment} has {item.Count} employees");
            }
            //Filter employees joined after 2020
            var joinedAfter2020 = employees.Where(e => e.JoinDate.Year > 2020);
            foreach (var item in joinedAfter2020)
            {
                Console.WriteLine($"\n{item.Name} has joined on {item.JoinDate.Year} ");
            }
            //Project anonymous objects with Name and AnnualSalary
            var anonymousObject = employees.Select(e => new { e.Name, AnnualSalary = e.Salary * 12 });
            foreach (var item in anonymousObject)
            {
                Console.WriteLine($"{item.Name} - {item.AnnualSalary}");
            }
        }
    }
}
