namespace OLADriver
{
    class Ride
    {
        public int RideId { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public int Fare { get; set; }
        public override string ToString()
        {
            return $"Ride Id: {RideId}, From: {From}, To: {To}, Fare: {Fare}";
        }
    }
    class OLADriver
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string VehicleNo { get; set; }
        public List<Ride> Rides { get; set; } = new List<Ride>();
        public int TotalFare()
        {
            int total = 0;
            foreach (var item in Rides)
            {
                total += item.Fare;
            }
            return total;
        }
        public void AddDrive(Ride ride)
        {
            Rides.Add(ride);
        }
        public override string ToString()
        {
            return $"ID - {Id}, Name - {Name}, Vehical Number - {VehicleNo} \n{GetAllRides()}";
        }
        public string GetAllRides()
        {
            string result = string.Empty;
            foreach (var item in Rides)
            {
                result += item + "\n";
            }
            return result;
        }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            List<OLADriver> drivers = new List<OLADriver>();
            OLADriver d1 = new OLADriver()
            {
                Id = 1,
                Name = "A1",
                VehicleNo = "PB65G7899",
            };
            d1.AddDrive(new Ride() { RideId = 11, From = "Delhi", To = "Chandigarh", Fare = 7000 });
            d1.AddDrive(new Ride() { RideId = 12, From = "Delhi", To = "Noida", Fare = 3500 });
            d1.AddDrive(new Ride() { RideId = 13, From = "Chandigarh", To = "Ambala", Fare = 4500 });
            OLADriver d2 = new OLADriver()
            {
                Id = 2,
                Name = "A2",
                VehicleNo = "PB65T3456"
            };
            d2.AddDrive(new Ride() { RideId = 11, From = "Ambala", To = "Chandigarh", Fare = 5000 });
            d2.AddDrive(new Ride() { RideId = 12, From = "chandigarh", To = "Noida", Fare = 8000 });
            d2.AddDrive(new Ride() { RideId = 13, From = "Jalandar", To = "Ambala", Fare = 7000 });

            OLADriver d3 = new OLADriver()
            {
                Id = 3,
                Name = "A3",
                VehicleNo = "PB65S4586"
            };
            d3.AddDrive(new Ride() { RideId = 11, From = "Ambala", To = "Chandigarh", Fare = 5000 });
            d3.AddDrive(new Ride() { RideId = 12, From = "chandigarh", To = "Noida", Fare = 8000 });
            d3.AddDrive(new Ride() { RideId = 13, From = "Jalandar", To = "Ambala", Fare = 7000 });
            OLADriver d4 = new OLADriver()
            {
                Id = 4,
                Name = "A4",
                VehicleNo = "PB13T3456"
            };
            d4.AddDrive(new Ride() { RideId = 11, From = "Delhi", To = "Chandigarh", Fare = 7000 });
            d4.AddDrive(new Ride() { RideId = 12, From = "Delhi", To = "Noida", Fare = 3500 });
            d4.AddDrive(new Ride() { RideId = 13, From = "Chandigarh", To = "Ambala", Fare = 4500 });
            drivers.Add(d1);
            drivers.Add(d2);
            drivers.Add(d3);
            drivers.Add(d4);
            foreach (var d in drivers)
            {
                Console.WriteLine(d);
            }
            Console.WriteLine($"Total Fare of the Driver 1: {drivers[1].TotalFare()}");
        }
    }
}
