namespace Day20_01_SortComparer
{
    class Flight : IComparable<Flight>
    {
        public string FlightNumber { get; set; }
        public decimal Price { get; set; }
        public TimeSpan Duration { get; set; }
        public DateTime DepartureTime { get; set; }

        public int CompareTo(Flight? other)
        {
            return this.Price.CompareTo(other!.Price);
        }
        public override string ToString()
        {
            return $"{FlightNumber} {Price} {Duration} {DepartureTime}";
        }
    }
    class DurationComparer : IComparer<Flight>
    {
        public int Compare(Flight? x, Flight? y)
        {
            return x!.Duration.CompareTo(y!.Duration);
        }
    }
    class DepartureComparer : IComparer<Flight>
    {
        public int Compare(Flight? x, Flight? y)
        {
            return x!.DepartureTime.CompareTo(y!.DepartureTime);
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Flight> flights = new List<Flight>()
            {
                new Flight()
                {
                    FlightNumber = "1",
                    Price = 4500,
                    Duration = TimeSpan.FromHours(4),
                    DepartureTime = DateTime.UtcNow.AddHours(3)
                },
                new Flight()
                {
                    FlightNumber = "2",
                    Price = 15700,
                    Duration = TimeSpan.FromHours(7),
                    DepartureTime = DateTime.UtcNow.AddHours(1)
                },
                new Flight()
                {
                    FlightNumber = "3",
                    Price = 70000,
                    Duration = TimeSpan.FromHours(5),
                    DepartureTime = DateTime.UtcNow.AddHours(7)
                }
            };
            flights.Sort();
            Console.WriteLine("Economy View");
            foreach (var item in flights)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
            flights.Sort(new DurationComparer());
            Console.WriteLine("Business Runner View");
            foreach (var item in flights)
            {
                Console.WriteLine(item); 
            }
            Console.WriteLine();
            flights.Sort(new DepartureComparer());
            Console.WriteLine("Early Bird View");
            foreach (var item in flights)
            {
                Console.WriteLine(item);
            }
        }
    }
}
