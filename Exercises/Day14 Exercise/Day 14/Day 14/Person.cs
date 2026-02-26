using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_14
{
    class Employee
    {
        //1.Int id : private data member with explicit methods
        private int id;
        public void SetID(int id)
        {
            this.id = id;
        }
        public int GetID()
        {
            return id;
        }
        //2.string name : auto property
        public string Name { get; set; }
        //3. string department : full property can assign only Accounts, sales, IT
        private string department;

        public string Department
        {
            get { return department; }
            set
            {
                if (value == "Accounts" || value == "Sales" || value == "IT")
                {
                    department = value;
                }
                else
                {
                    Console.WriteLine("Invalid Department");
                }
            }
        }
        //4.int salary : full property range 50000 to 90000
        private int salary;

        public int Salary
        {
            get { return salary; }
            set
            {
                if (value >= 50000 && value <= 90000)
                {
                    salary = value;
                }
                else
                {
                    Console.WriteLine("Invalid Salary. Salary should range between 50000 and 90000");
                }
            }
        }
        //Display Method
        public void Display()
        {
            Console.WriteLine("Employee Details");
            Console.WriteLine("-------------------------");
            Console.WriteLine($"ID : {id}");
            Console.WriteLine($"Name : {Name}");
            Console.WriteLine($"Department : {department}");
            Console.WriteLine($"Salary : {Salary}");
        }
    }
    internal class Person
    {
        static void Main(string[] args)
        {
                Employee emp = new Employee();
                emp.SetID(1);
                emp.Name = "Gurnoor";
                emp.Department = "IT";
                emp.Salary = 70000;
                emp.Display();
        }
    }
}
