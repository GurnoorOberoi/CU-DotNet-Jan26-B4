namespace StudentsDictionary
{
    class Student
    {
        public int Studid { get; set; }
        public string SName { get; set; }
        public Student(int id, string name)
        {
            Studid = id;
            SName = name;
        }
        public override bool Equals(object? obj)
        {
            if (obj is Student s)
            {
                return this.Studid == s.Studid && this.SName == s.SName;
            }
            return false;
        }
        public override int GetHashCode()
        {
            //return Studid.GetHashCode();
            return HashCode.Combine(Studid, SName);
        }
    }
    class StudentManagement
    {
        static Dictionary<Student, int> dic = new Dictionary<Student, int>();
        public static void AddorUpdateMarks(Student s, int marks)
        {
            if (dic.ContainsKey(s))
            {
                if (marks > dic[s])
                {
                    dic[s] = marks;
                }

            }
            else
            {
                dic.Add(s, marks);
                Console.WriteLine("Student added: " + s.SName);
            }
        }
        public static void Display()
        {
            Console.WriteLine("\nStudent Records");
            foreach (var item in dic)
            {
                Console.WriteLine($"ID: {item.Key.Studid} Name: {item.Key.SName} Marks: {item.Value}");
            }
        }
    }
    internal class program
    {
        static void Main(string[] args)
        {
            Student S1 = new Student(1, "S1");
            Student S2 = new Student(2, "S2");
            StudentManagement.AddorUpdateMarks(S1, 75);
            StudentManagement.AddorUpdateMarks(S2, 80);
            StudentManagement.AddorUpdateMarks(new Student(1, "S1"), 90);
            StudentManagement.Display();
        }
    }
}
