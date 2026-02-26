namespace Day29_01_KitchenApplAbstraction
{
    interface ISmart
    {
        void ConnectToWifi();
    }
    interface ITimer
    {
        void SetTimer(int minutes);
    }
    abstract class KitchenAppliance
    {
        public int PowerConsumption { get; set; }
        public string ModelName { get; set; }
        public decimal Price { get; set; }
        public abstract void cook();

        public virtual void PreHeat(int temperature)
        {
            Console.WriteLine($"{ModelName} requires No Preheat");
        }
    }
    class Microwave : KitchenAppliance, ITimer
    {
        public override void cook()
        {
            Console.WriteLine("Microwave is heating food.");
        }
        public void SetTimer(int minutes)
        {
            Console.WriteLine($"Microwave is set for timer {minutes} minutes");
        }
    }
    class Kettle : KitchenAppliance
    {
        public override void cook()
        {
            Console.WriteLine("Kettle is boiling water");
        }
    }
    class Oven : KitchenAppliance, ITimer, ISmart
    {
        public override void PreHeat(int temperature)
        {
            Console.WriteLine($"PreHeating oven at {temperature}");
        }
        public override void cook()
        {
            PreHeat(270);
            Console.WriteLine("Oven is baking cake");
        }
        public void ConnectToWifi()
        {
            Console.WriteLine("Oven is connected to wifi");
        }
        public void SetTimer(int minutes)
        {
            Console.WriteLine($"Oven is set for timer {minutes} minutes");
        }

    }
    class AirFryer : KitchenAppliance, ITimer
    {
        public override void PreHeat(int temperature)
        {
            Console.WriteLine($"PreHeating AirFryer at {temperature}");
        }
        public override void cook()
        {
            PreHeat(180);
            Console.WriteLine("AirFryer is cooking french fries");
        }
        public void SetTimer(int minutes)
        {
            Console.WriteLine($"AirFryer is set for timer {minutes} minutes");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            List<KitchenAppliance> ka = new List<KitchenAppliance>()
            {
                new Microwave(){ModelName = "MicroX", PowerConsumption = 1200, Price = 25000},
                new Kettle(){ModelName = "Bajaj" , PowerConsumption = 200, Price = 3500},
                new Oven(){ModelName = "Prestige", PowerConsumption = 2700, Price = 50000},
                new AirFryer(){ModelName = "Agaro", PowerConsumption = 1700, Price = 4500}
            };
            foreach (var item in ka)
            {
                Console.WriteLine($"\nDevices: {item.ModelName}");
                item.cook();
                if (item is ITimer t)
                    t.SetTimer(30);
                if (item is ISmart s)
                    s.ConnectToWifi();
            }
        }
    }
}
