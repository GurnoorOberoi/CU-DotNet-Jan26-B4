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
            double time =0;
            foreach (var item in leaderboard)
            {
                Console.WriteLine($"Player's Name: {item.Value}, Times: {item.Key}");
                if(item.Value == "SteadyEddie")
                {
                    time = item.Key;
                }
            }
            leaderboard.Remove(time);
            Console.WriteLine();
            Console.WriteLine( "First Entry: "+ leaderboard.First());
            leaderboard.Add(54.00, "SteadyEddie");
            Console.WriteLine("\nUpdated Record");
            foreach (var item in leaderboard)
            {
                Console.WriteLine($"Player's Name: {item.Value}, Times: {item.Key}");
            }
        }
    }
}
