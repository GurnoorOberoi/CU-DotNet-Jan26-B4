using System.Text;

namespace CollegeMgmt
{
    internal class Program
    {
        class CollageManagement
        {
            Dictionary<string, Dictionary<string, int>> studentRecords =
                new Dictionary<string, Dictionary<string, int>>();
            Dictionary<string, LinkedList<KeyValuePair<string, int>>> subjectsStudentsOrder =
                new Dictionary<string, LinkedList<KeyValuePair<string, int>>>();
            public int AddStudent(string studentId, string subject, int marks)
            {
                if (!studentRecords.ContainsKey(studentId))
                    studentRecords[studentId] = new Dictionary<string, int>();
                if (studentRecords[studentId].ContainsKey(subject))
                {
                    if (marks > studentRecords[studentId][subject])
                    {
                        studentRecords[studentId][subject] = marks;
                        UpdateSubjectRecord(studentId, subject, marks);
                    }
                }
                else
                {
                    studentRecords[studentId][subject] = marks;
                    AddToSubjectRecord(studentId, subject, marks);
                }

                return 1;
            }

            private void AddToSubjectRecord(string studentId, string subject, int marks)
            {
                if (!subjectsStudentsOrder.ContainsKey(subject))
                    subjectsStudentsOrder[subject] =
                        new LinkedList<KeyValuePair<string, int>>();

                subjectsStudentsOrder[subject]
                    .AddLast(new KeyValuePair<string, int>(studentId, marks));
            }

            private void UpdateSubjectRecord(string studentId, string subject, int marks)
            {
                var list = subjectsStudentsOrder[subject];

                var node = list.First;
                while (node != null)
                {
                    if (node.Value.Key == studentId)
                    {
                        node.Value = new KeyValuePair<string, int>(studentId, marks);
                        break;
                    }
                    node = node.Next;
                }
            }
            public int RemoveStudent(string studentId)
            {
                if (!studentRecords.ContainsKey(studentId))
                    return 0;
                foreach (var subject in studentRecords[studentId].Keys)
                {
                    var list = subjectsStudentsOrder[subject];
                    var node = list.First;

                    while (node != null)
                    {
                        if (node.Value.Key == studentId)
                        {
                            list.Remove(node);
                            break;
                        }
                        node = node.Next;
                    }
                }

                studentRecords.Remove(studentId);
                return 1;
            }
            public string TopStudent(string subject)
            {
                if (!subjectsStudentsOrder.ContainsKey(subject))
                    return "";

                var list = subjectsStudentsOrder[subject];

                if (list.Count == 0)
                    return "";

                int maxMarks = list.Max(x => x.Value);

                StringBuilder result = new StringBuilder();

                foreach (var entry in list)
                {
                    if (entry.Value == maxMarks)
                    {
                        result.AppendLine(entry.Key + " " + entry.Value);
                    }
                }

                return result.ToString().Trim();
            }
            public string Result()
            {
                StringBuilder sb = new StringBuilder();

                foreach (var student in studentRecords)
                {
                    double avg = student.Value.Values.Average();
                    sb.AppendLine(student.Key + " " + avg.ToString("F2"));
                }

                return sb.ToString().Trim();
            }
        }
        static void Main(string[] args)
        {
            CollageManagement cm = new CollageManagement();

            cm.AddStudent("S1", "Math", 80);
            cm.AddStudent("S2", "Math", 90);
            cm.AddStudent("S3", "Math", 90);
            cm.AddStudent("S1", "Phy", 90);
            Console.WriteLine("Topper Students: ");
            Console.WriteLine(cm.TopStudent("Math"));
            Console.WriteLine("\nStudent's Average Marks: ");
            Console.WriteLine(cm.Result());

            cm.RemoveStudent("S1");
        }
    }
}



