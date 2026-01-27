namespace Day_18__02_Inheritance
{
    class Employee
    {
        public Employee()
        {
            EmployeeId = 0;
            EmployeeName = string.Empty;
            BasicSalary = decimal.Zero;
            ExperienceInYears = 0;
        }
        public Employee(int id, string name, decimal salary, int years)
        {
            EmployeeId = id;
            EmployeeName = name;
            BasicSalary = salary;
            ExperienceInYears = years;
        }
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public decimal BasicSalary { get; set; }
        public int ExperienceInYears { get; set; }

        public decimal CalculateAnnualSalary()
        {
            return BasicSalary * 12;
        }
        public void DisplayEmployeeDetails()
        {
            Console.WriteLine($"ID = {EmployeeId}");
            Console.WriteLine($"Name = {EmployeeName}");
            Console.WriteLine($"Annual Salary = {CalculateAnnualSalary()}");
        }
    }
    class PermanentEmployee: Employee
    {
        public PermanentEmployee(int id, string name, decimal salary, int years): base(id, name, salary, years)
        {
        }
        public new decimal CalculateAnnualSalary()
        {
            decimal HRA = BasicSalary * 0.2m;
            decimal specialAllowance = BasicSalary * 0.1m;
            decimal bonus = ExperienceInYears >= 5 ? 50000 : 0;
            return (BasicSalary*12) + (HRA*12) + (specialAllowance*12)+ bonus; 
        }
    }
    class ContractEmployee : Employee
    {
        public ContractEmployee(int id, string name, decimal salary, int years , int duration): base (id, name, salary, years)
        {
            ContractDurationInMonths = duration;
        }
        public int ContractDurationInMonths  { get; set; }
        public new decimal CalculateAnnualSalary()
        {
            decimal bonus = ContractDurationInMonths >= 12 ? 30000 : 0;
            return (BasicSalary * 12)+bonus;
        }

    }
    class InternEmployee : Employee
    {
        public InternEmployee(int id, string name, decimal salary, int years):base (id, name, salary, years)
        {
        }
        public new decimal CalculateAnnualSalary()
        {
            return BasicSalary * 12;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Employee e1 = new Employee(1, "E1", 3000, 5);
            PermanentEmployee e2 = new PermanentEmployee(2, "E2", 3000, 5);
            ContractEmployee e3 = new ContractEmployee(3, "E3", 4550.85m, 9, 8);
            InternEmployee e4 = new InternEmployee(4, "E4", 9500, 3);
            Employee e5 = new PermanentEmployee(5, "E5", 8500, 2);
            Console.WriteLine("Employee Compensation Management System");
            Console.WriteLine("\nEmployee Base Method");
            Console.WriteLine(e1.CalculateAnnualSalary().ToString("N2"));
            Console.WriteLine("\nPermanent Derived Method");
            Console.WriteLine(e2.CalculateAnnualSalary().ToString("N2"));
            Console.WriteLine("\nCOntract Derived Method");
            Console.WriteLine(e3.CalculateAnnualSalary().ToString("N2"));
            Console.WriteLine("\nInter Derived Method");
            Console.WriteLine(e4.CalculateAnnualSalary().ToString("N2"));
            Console.WriteLine("\nBase class references");
            Console.WriteLine(e5.CalculateAnnualSalary().ToString("N2"));
            Console.WriteLine();
            e1.DisplayEmployeeDetails();
        }
    }
}
