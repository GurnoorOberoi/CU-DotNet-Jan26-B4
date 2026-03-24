using LayeredRepo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.Marshalling;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace LayeredRepo.Repositories
{
    internal class JsonStudentRepository: IStudentRepository
    {
        private readonly string filePath = @"..\..\..\students.json";

        private List<Student> ReadFromFile()
        {
            if (!File.Exists(filePath))
                return new List<Student>();

            var json = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<List<Student>>(json) ?? new List<Student>();
        }

        private void WriteToFile(List<Student> students)
        {
            var json = JsonSerializer.Serialize(students, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filePath, json);
        }

        public void AddStudent(Student student)
        {
            var students = ReadFromFile();
            students.Add(student);
            WriteToFile(students);
        }

        public List<Student> GetAllStudents()
        {
            return ReadFromFile();
        }

        public Student GetStudentById(int id)
        {
            return ReadFromFile().FirstOrDefault(s => s.Id == id);
        }

        public void UpdateStudent(Student student)
        {
            var students = ReadFromFile();
            var existing = students.FirstOrDefault(s => s.Id == student.Id);

            if (existing != null)
            {
                existing.Name = student.Name;
                existing.Grade = student.Grade;
                WriteToFile(students);
            }
        }

        public void DeleteStudent(int id)
        {
            var students = ReadFromFile();
            var student = students.FirstOrDefault(s => s.Id == id);

            if (student != null)
            {
                students.Remove(student);
                WriteToFile(students);
            }
        }
    }
}
