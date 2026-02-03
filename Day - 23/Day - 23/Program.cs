namespace Day___23
{
    class InvalidStudentAgeException: Exception
    {
        public InvalidStudentAgeException(string message): base(message) { }
    }
    class InvalidStudentNameException: Exception
    {
        public InvalidStudentNameException(string message): base(message) { }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Enter the number 1: ");
                int x = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter the number 2: ");
                int y = int.Parse(Console.ReadLine());
                Console.WriteLine("Result: " + (x/y));
            }
            catch(DivideByZeroException)
            {
                Console.WriteLine("Error: cannot divide by Zero");
            }
            finally
            {
                Console.WriteLine("Operation Completed\n");
            }
            try
            {
                Console.WriteLine("Enter the Integer: ");
                int num = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Entered Number: "+ num);
            }
            catch (FormatException)
            {
                Console.WriteLine("Error: Invalid Number");
            }
            finally
            {
                Console.WriteLine("Operation Completed\n");
            }
            try
            {
                int[] arr = { 1, 2, 3, 4, 5 };
                Console.WriteLine("Enter array Index: ");
                int index = int.Parse(Console.ReadLine());
                Console.WriteLine("value: " + arr[index]);
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Error: Invalid array index");
            }
            finally
            {
                Console.WriteLine("Operation Completed\n");
            }
            try
            {
                GetStudentDetails();
            }
            catch(Exception ex)
            {
                Console.WriteLine("Exception Occured");
                Console.WriteLine("Message: ", ex.Message);
                if(ex.InnerException != null)
                {
                    Console.WriteLine("Inner Exception: " + ex.InnerException.Message);
                }
                Console.WriteLine("StackTrace:\n" + ex.StackTrace);
            }
            Console.WriteLine("\nProgram Ended");
        }
        static void GetStudentDetails()
        {
            try
            {
                Console.WriteLine("Enter the Student Name: ");
                string name = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(name))
                {
                    throw new InvalidStudentNameException("Student name cannot be empty");

                }
                int age;
                while (true)
                {
                    try
                    {
                        Console.WriteLine("Enter the student age: ");
                        age = Convert.ToInt32(Console.ReadLine());
                        if (age < 18 || age > 60)
                        {
                            throw new InvalidStudentAgeException("Student Age must be between 18 and 60");
                        }
                        break;
                    }
                    catch (InvalidStudentAgeException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                Console.WriteLine("Student Details\n");
                Console.WriteLine($"Name: {name} Age: {age}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error occured in Student data", ex);
            }
        }
        
    }
}
