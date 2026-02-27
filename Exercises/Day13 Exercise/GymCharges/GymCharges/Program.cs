namespace GymCharges
{
    internal class Program
    {
        static void Main(string[] args)
        {
            decimal amount = calculateGymMembership(Tread: false, Weightlifting: false, Zumba: false);

            if (amount > 0)
            {
                Console.WriteLine($"Total Monthly Gym Fee (including GST): ₹{amount:F2}");
            }
        }
        static decimal calculateGymMembership(bool Tread, bool Weightlifting, bool Zumba)
        {
            decimal fixedPrices = 1000;
            decimal total = fixedPrices;
            if (!Tread && !Weightlifting && !Zumba)
            {
                total += 200;
                //Console.WriteLine("At least one service must be selected");
                //return 0;
            }
            if (Tread)
            {
                total += 300;
            }
            if (Weightlifting)
            {
                total += 500;
            }
            if (Zumba)
            {
                total += 250;
            }
            decimal gst = total * 0.05m;
            total += gst;
            return total;
        }
    }
}