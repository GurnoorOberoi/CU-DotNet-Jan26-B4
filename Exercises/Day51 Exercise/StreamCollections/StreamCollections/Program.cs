using System.ComponentModel.Design;

namespace StreamCollections
{
    class CreatorStats
    {
        public string CreatorName { get; set; }
        public double[] WeeklyLikes { get; set; }
    }
    internal class Program
    {
        public static List<CreatorStats> EngagementBoard = new List<CreatorStats>();
        public void RegisterCreator(CreatorStats record)
        {
            EngagementBoard.Add(record);
        }
        public Dictionary<string, int> GetTopPostCounts(List<CreatorStats> records, double likeThreshold)
        {
            Dictionary<string, int> result = new Dictionary<string, int>();
            foreach (var item in records)
            {
                int count = item.WeeklyLikes.Count(l=>l>=likeThreshold);
                if (count > 0)
                {
                    result.Add(item.CreatorName, count);
                }
            }
            return result;
        }
        public double CalculateAverageLikes()
        {
            if(EngagementBoard.Count==0)
                return 0;
            return EngagementBoard.SelectMany(x => x.WeeklyLikes).Average();
        }
        static void Main(string[] args)
        {
            Program p = new Program();
            while (true)
            {
                Console.WriteLine("\n1.Register Creater");
                Console.WriteLine("2.Show Top Post ");
                Console.WriteLine("3.Calculate Average likes");
                Console.WriteLine("4.Exit");
                Console.WriteLine("Enter your choice: ");
                int choice = Convert.ToInt32(Console.ReadLine());
                if(choice == 1)
                {
                    CreatorStats cs = new CreatorStats();
                    Console.WriteLine("Enter Creater's Name: ");
                    cs.CreatorName = Console.ReadLine();
                    Console.WriteLine("Enter weekly like (week 1 to 4)");
                    cs.WeeklyLikes = new double[4];
                    for(int i = 0; i < 4; i++)
                    {
                        cs.WeeklyLikes[i] = Convert.ToDouble(Console.ReadLine());
                    }
                    p.RegisterCreator(cs);
                    Console.WriteLine("Creator registered successfully");
                }
                else if(choice == 2)
                {
                    Console.WriteLine("Enter the like Threshold: ");
                    double Threshold = Convert.ToDouble(Console.ReadLine());
                    var result = p.GetTopPostCounts(EngagementBoard, Threshold);
                    if(result.Count == 0)
                    {
                        Console.WriteLine("No top-performing posts this week");
                    }
                    else
                    {
                        foreach (var item in result)
                        {
                            Console.WriteLine($"{item.Key} - {item.Value}");
                        }
                    }
                }
                else if(choice == 3)
                {
                    double avg = p.CalculateAverageLikes();
                    Console.WriteLine("Overall average weekly likes: " + avg);
                }
                else if(choice == 4)
                {
                    Console.WriteLine("Logging off — Keep Creating with StreamBuzz!");
                    break;
                }
            }
        }
    }
}
