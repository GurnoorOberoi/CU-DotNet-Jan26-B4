using System.Threading.Channels;

namespace Week5Assessment
{
    interface ILoggable
    {
        void SaveLog(string message);
    }

    class InsecurePackagingException : Exception
    {
        public InsecurePackagingException():base ("Fragile flag is set without a Reinforced status") { }
    }
    class RestrictedDestinationException: Exception
    {
        public string Denied { get; set; }
        public RestrictedDestinationException(string location): base("shipment destination is on the restricted list")
        {
            Denied = location;
        }
    }
    abstract class Shipment
    {
        public string TrackingId { get; set; }
        public double Weight { get; set; }
        public string Destination { get; set; }
        public bool IsFragile { get; set; }
        public bool IsReinforced { get; set; }

        List<string> restricted = new List<string> { "North Pole", "Unknown Island" };
        public void ValidCheck()
        {
            if (Weight <= 0)
                throw new ArgumentOutOfRangeException("Invalid Weight, weight is less than or equal to 0");
            if (IsFragile && !IsReinforced)
                throw new InsecurePackagingException();
            if (restricted.Contains(Destination))
                throw new RestrictedDestinationException(Destination);
        }
        public abstract void ProcessShipment();
    }
    class ExpressShipment: Shipment
    {
        public override void ProcessShipment()
        {
            ValidCheck();
            Console.WriteLine($"Shippment of {TrackingId} is processing quickly");
        }
    }
    class HeavyFreight: Shipment
    {
        public bool HasHeavyWeight { get; set; }
        public override void ProcessShipment()
        {
            ValidCheck();
            if (Weight > 1000 && !HasHeavyWeight)
                throw new Exception("Shipments over 1,000kg require a special Heavy Lift permit");
            Console.WriteLine($"\n{TrackingId} has correct weight");
        }
    }
    class LogManager: ILoggable
    {
        string file = @"..\..\..\shipment_audit.log";
        public void SaveLog(string message)
        {
            using (StreamWriter sw = new StreamWriter(file, true))
            {
                sw.WriteLine($"{message}");
            }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            LogManager lm = new LogManager();
            List<Shipment> sh = new List<Shipment>
            {
                new ExpressShipment(){ TrackingId ="101", Weight = 500, Destination = "Delhi", IsFragile = false, IsReinforced = false},
                new ExpressShipment(){ TrackingId = "102", Weight = -12, Destination = "New York", IsFragile = false, IsReinforced = false},
                new HeavyFreight(){ TrackingId = "103", Weight = 1500, Destination = "London" , IsFragile = true ,IsReinforced = false, HasHeavyWeight = true },
                new HeavyFreight(){ TrackingId = "104", Weight = 800, Destination = "North Pole" , IsFragile = false ,IsReinforced = false, HasHeavyWeight = false },
                new HeavyFreight(){ TrackingId = "105", Weight = 200, Destination = "Europe" , IsFragile = false ,IsReinforced = false, HasHeavyWeight = true }
            };
            foreach (var item in sh)
            {
                try
                {
                    item.ProcessShipment();
                    lm.SaveLog($"SUCCESS for ID: {item.TrackingId}");
                }
                catch (RestrictedDestinationException ex)
                {
                    lm.SaveLog($"\nSECURITY ALERT for ID: {item.TrackingId} " + ex.Message);
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    lm.SaveLog($"\nDATA ENTRY ERROR for ID: {item.TrackingId} " + ex.Message);
                }
                catch (Exception ex)
                {
                    lm.SaveLog("\nException: " + ex.Message);
                }
                finally
                {
                    Console.WriteLine($"\nProcessing attempt finished for ID: {item.TrackingId}");
                }
            }
        }
    }
}
