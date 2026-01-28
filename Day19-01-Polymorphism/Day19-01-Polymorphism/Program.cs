namespace Day19_01_Polymorphism
{
    abstract class Vehical
    {
        public string ModelName { get; set; }
        public Vehical(string name)
        {
            ModelName = name;
        }
        public abstract void Move();
        public virtual string GetFuelStatus()
        {
            return "Fuel level is stable";
        }
    }
    class ElectricCar : Vehical
    {
        public ElectricCar(string name) : base(name)
        {
        }
        public override void Move()
        {
            Console.WriteLine($"{ModelName} is gliding silently on battery power");
        }
        public override string GetFuelStatus()
        {
            return $"{ModelName} battery is at 80%";
        }
    }
    class HeavyTruck : Vehical
    {
        public HeavyTruck(string name) : base(name)
        {
        }
        public override void Move()
        {
            Console.WriteLine($"{ModelName} is hauling cargo with high-torque diesel power");
        }
    }
    class CargoPlane : Vehical
    {
        public CargoPlane(string name) : base(name)
        {
        }
        public override void Move()
        {
            Console.WriteLine($"{ModelName} is ascending to 30,000 feet");
        }
        public override string GetFuelStatus()
        {
            return base.GetFuelStatus() + "Checking jet fuel reserves...";
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Vehical[] feet = new Vehical[3]
            {
                new ElectricCar("Tesla"),
                new HeavyTruck("Volvo"),
                new CargoPlane("AirBus")
            };
            foreach (var item in feet)
            {
                item.Move();
                Console.WriteLine(item.GetFuelStatus());
                Console.WriteLine();
            }
        }
    }
}
