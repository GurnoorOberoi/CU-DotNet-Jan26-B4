namespace Day25_02_CSVFile
{
    class Player
    {
        public string Name { get; set; }
        public int RunsScored { get; set; }
        public int BallsFaced { get; set; }
        public bool IsOut { get; set; }
        public double StrikeRate { get; set; }
        public double Average { get; set; }
        public void Calculate()
        {
            if (BallsFaced == 0)
                StrikeRate = 0;
            else
                StrikeRate = (double)RunsScored / BallsFaced * 100;

            if (!IsOut)
                Average = RunsScored;
            else
                Average = RunsScored;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            string file = @"..\..\..\players.csv";
            using(FileStream fs = new FileStream(file, FileMode.Create))
            using (StreamWriter sw = new StreamWriter(fs))
            {
                string[] data =
                {
                    "Steve Smith,84,90,True",
                    "Virat Kohli,29,35,False",
                    "Joe Root,110,120,True",
                    "Bad Player,50,0,True"
                };
                foreach (string line in data)
                {
                    sw.WriteLine(line);
                }
            }
            List<Player> p = new List<Player>();
            try
            {
                using StreamReader sr = new StreamReader(file);
                string line;
                while((line = sr.ReadLine()) != null)
                {
                    try
                    {
                        string[] part = line.Split(',');
                        Player pl = new Player();
                        pl.Name = part[0].Trim();
                        pl.RunsScored = int.Parse(part[1].Trim());
                        pl.BallsFaced = int.Parse(part[2].Trim());
                        pl.IsOut = bool.Parse(part[3].Trim());

                        if (pl.BallsFaced < 10)
                            continue;
                        pl.Calculate();
                        p.Add(pl);
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Invalid Data" + line);
                    }
                }
                sr.Close();
                Console.WriteLine($"\n{"Name",-13}{ "Runs",-9}{"SR",-9}{ "Avg",-10}");
                Console.WriteLine("-----------------------------------");
                foreach(var item in p.OrderByDescending(p => p.BallsFaced))
                {
                    Console.WriteLine($"{item.Name,-12} {item.RunsScored,-7} {item.StrikeRate,-7:F2} {item.Average,-7:F2}");
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("File Not Found");
            }
        }
    }
}
