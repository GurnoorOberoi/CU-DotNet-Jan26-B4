namespace Day24_02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<double, string> leaderboard = new SortedDictionary<double, string>();
            leaderboard.Add(55.42, "SwiftRacer");
            leaderboard.Add(52.10, "SpeedDemon");
            leaderboard.Add(58.91, "SteadyEddie");
            leaderboard.Add(51.05, "TurboTom");
            Console.WriteLine("Records of the Players");
            foreach (var item in leaderboard)
            {
                Console.WriteLine($"Player's Name: {item.Value}, Times: {item.Key}");
            }
            Console.WriteLine();
            Console.WriteLine( "First Entry: "+ leaderboard.First());
            leaderboard.Remove(58.91);
            Console.WriteLine();
            leaderboard.Add(54.00, "SteadyEddie");
            Console.WriteLine("\nUpdated Record");
            foreach (var item in leaderboard)
            {
                Console.WriteLine($"Player's Name: {item.Value}, Times: {item.Key}");
            }
        }
    }
}
