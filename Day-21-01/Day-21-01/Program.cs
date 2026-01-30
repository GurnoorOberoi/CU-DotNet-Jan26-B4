namespace Day_21_01
{
    class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Marks { get; set; }
        public override string ToString()
        {
            return $"ID - {Id} Name - {Name} Marks - {Marks}";
        }
    }
    class StudentManager
    {
        Dictionary<int, Student> StudentsData = new Dictionary<int, Student>();
        public bool AddStudent(Student student)
        {
            int id = student.Id;
            if (!StudentsData.ContainsKey(id))
            {
                StudentsData.Add(id, student);
                return true;
            }
            return false;
        }
        public Student SearchStudent(int id)
        {
            Student students = null;
            bool found = StudentsData.TryGetValue(id, out students);
            return students;
        }
        public bool UpdateStudent(int id, int marks)
        {
            Student foundStudent = SearchStudent(id);
            if (foundStudent != null)
            {
                foundStudent.Marks = marks;
                return true;
            }
            return false;
        }
        public bool DeleteStudent(int id)
        {
            return StudentsData.Remove(id);
        }
        public void DisplayAllStudents()
        {
            foreach (var student in StudentsData)
            {
                Console.WriteLine(student);
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            StudentManager manager = new StudentManager();
            int choice = 0;
            while (choice != 6)
            {
                Console.WriteLine("------STUDENT MANAGEMENT SYSTEM-------- ");
                Console.WriteLine("1. Add Student");
                Console.WriteLine("2. Search Student");
                Console.WriteLine("3. Update Student");
                Console.WriteLine("4. Delete Student");
                Console.WriteLine("5. Display Student");
                Console.WriteLine("6. Exit");
                Console.WriteLine("Enter the Student: ");
                choice = Convert.ToInt32(Console.ReadLine());
                if (choice == 1)
                {
                    Console.WriteLine("Enter the ID : ");
                    int id = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter the Name : ");
                    string name = Console.ReadLine();
                    Console.WriteLine("Enter the Marks : ");
                    int marks = Convert.ToInt32(Console.ReadLine());
                    bool added = manager.AddStudent(
                        new Student()
                        {
                            Id = id,
                            Name = name,
                            Marks = marks
                        });
                    Console.WriteLine(added ? "Added Successfully" : "Student Already Exist");
                }
                else if (choice == 2)
                {
                    Console.WriteLine("Enter the ID to Search : ");
                    int id = Convert.ToInt32(Console.ReadLine());
                    Student student = manager.SearchStudent(id);
                    if (student != null)
                    {
                        Console.WriteLine(student.ToString());
                    }
                    Console.WriteLine("ID Doesnot Exist");
                }
                else if (choice == 3)
                {
                    Console.WriteLine("Enter the ID : ");
                    int id = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter the Marks : ");
                    int marks = Convert.ToInt32(Console.ReadLine());
                    bool updated = manager.UpdateStudent(id, marks);
                    Console.WriteLine(updated ? "Data Updated" : "Student Not Found");
                }
                else if (choice == 4)
                {
                    Console.WriteLine("Enter the ID : ");
                    int id = Convert.ToInt32(Console.ReadLine());
                    bool deleted = manager.DeleteStudent(id);
                    Console.WriteLine(deleted ? "Data Deleted" : "Student Not Found");
                }
                else if (choice == 5)
                {
                    manager.DisplayAllStudents();
                }
                else if (choice == 6)
                {
                    Console.WriteLine("Exit the Program");
                }
                else
                {
                    Console.WriteLine("Invalid Choice");
                }
                Console.WriteLine();
            }
        }
    }
}
