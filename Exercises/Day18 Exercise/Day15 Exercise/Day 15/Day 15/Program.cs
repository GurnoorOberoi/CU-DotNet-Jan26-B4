namespace Day_15
{
    class Height
    {
        public int Feet { get; set; }
        public double Inches { get; set; }
        //Default Constructor
        public Height()
        {
            Feet = 0;
            Inches = 0.0;
        }
        //Parameterized Constructor
        public Height(int feet, double inches)
        {
            Feet = feet;
            Inches = inches;
        }
        // To convert into feet if inch is > 12
        public Height(double inches)
        {
            if (inches > 12)
            {
                Feet += (int)(inches / 12);
                Inches = (inches % 12); 
            }
        }

        public Height AddHeight(Height h2)
        {
            int totalFeet = this.Feet + h2.Feet;
            double totalInches = this.Inches + h2.Inches;
            if (totalInches >= 12)
            {
                totalFeet += (int)(totalInches / 12);
                totalInches = (totalInches % 12);
            }
            return new Height(totalFeet, totalInches);
        }
        public override string ToString()
        {
            return $"Height - {Feet} feet {Inches:F1} inches";
        }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello, World!");
            Height person1 = new Height(5,6.5);
            Height person2 = new Height(5,7.5);
            Height total = person1.AddHeight(person2);
            Height person3 = new Height(170);
            Console.WriteLine(person1);
            Console.WriteLine(person2);
            Console.WriteLine(total);
            Console.WriteLine(person3);
        }
    }
}
