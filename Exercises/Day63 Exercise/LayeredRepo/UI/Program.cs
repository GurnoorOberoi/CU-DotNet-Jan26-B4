using LayeredRepo.Repositories;
using LayeredRepo.Services;
using LayeredRepo.Models;

namespace LayeredRepo.UI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Select the option");
            Console.WriteLine("1. In-Memory");
            Console.WriteLine("2. Json File");
            int choice = int.Parse(Console.ReadLine());
            IStudentRepository repo;
            if (choice == 1)
            {
                repo = new ListStudentRepository();
            }
            else
            {
                repo = new JsonStudentRepository();
            }
            StudentService service = new StudentService(repo);
            while (true)
            {
                Console.WriteLine("Select the Option");
                Console.WriteLine("1. Add Student");
                Console.WriteLine("2. View Student");
                Console.WriteLine("3. Update Student");
                Console.WriteLine("4. Delete Student");
                Console.WriteLine("5. Exist");
                int option = int.Parse(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        Console.WriteLine("Enter the Id: ");
                        int id = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter the Name: ");
                        string name = Console.ReadLine();
                        Console.WriteLine("Enter the Grade: ");
                        double grade = int.Parse(Console.ReadLine());
                        service.AddStudent(new Student { Id = id, Name = name, Grade = grade });
                        Console.WriteLine();
                        break;
                    case 2:
                        var students = service.GetAllStudents();
                        foreach(var item in students)
                        {
                            Console.WriteLine($"{item.Id} {item.Name} {item.Grade} ");
                        }
                        Console.WriteLine();
                        break;
                    case 3:
                        Console.WriteLine("Enter new Id: ");
                        int newId = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter new Name: ");
                        string newName = Console.ReadLine();
                        Console.WriteLine("Enter new Grade: ");
                        double newGrade = int.Parse(Console.ReadLine());
                        service.UpdateStudent(new Student {Id = newId, Name = newName, Grade = newGrade });
                        Console.WriteLine();
                        break;
                    case 4:
                        Console.WriteLine("Enter the Id to be Removed: ");
                        int removeId = int.Parse(Console.ReadLine());
                        service.DeleteStudent(removeId);
                        Console.WriteLine();
                        break;
                    case 5:
                        return;
                }
            }
        }
    }
}
