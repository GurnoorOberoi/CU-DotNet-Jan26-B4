using System.Globalization;
namespace Week4_Assessment
{
    class Patient
    {
        public string Name { get; set; }
        public decimal BaseFee { get; set; }
        public Patient(string name, decimal baseFee)
        {
            Name = name;
            BaseFee = baseFee;
        }

        public virtual decimal CalculateFinalBill()
        {
            return BaseFee;
        }
    }
    class Inpatient: Patient
    {
        public int DaysStayed { get; set; }
        public decimal DailyRate { get; set; }
        public Inpatient(string name, decimal baseFee, int stayed, decimal rate) : base(name, baseFee)
        {
            DaysStayed = stayed;
            DailyRate = rate;
        }
        public override decimal CalculateFinalBill()
        {
            return BaseFee + (DaysStayed * DailyRate);
        }
    }
    class Outpatient : Patient
    {
        public decimal ProcedureFee { get; set; }

        public Outpatient(string name, decimal baseFee, decimal fee) : base(name, baseFee)
        {
            ProcedureFee = fee;
        }
        public override decimal CalculateFinalBill()
        {
            return BaseFee + ProcedureFee;
        }
    }
    class EmergencyPatient: Patient
    {
        public int SeverityLevel { get; set; }

        public EmergencyPatient(string name, decimal baseFee, int level) : base(name, baseFee)
        {
           SeverityLevel = level;
        }
        public override decimal CalculateFinalBill()
        {
            return BaseFee * SeverityLevel;
        }
    }
    class HospitalBilling
    {
        List<Patient> patients = new List<Patient>();
        public void AddPatient(Patient p)
        {
            patients.Add(p);
        }
        public void GenerateDailyReport()
        {
            Console.WriteLine("The St. Memorial Billing Engine");
            Console.WriteLine("-------------------------------");
            Console.WriteLine("Hospital Report");
            Console.WriteLine("-------------------------------");
            foreach (var item in patients)
            {
                Console.WriteLine($"Name = {item.Name}, Bill = {item.CalculateFinalBill():C2}");
            }
            Console.WriteLine();
        }
        public decimal CalculateTotalRevenue()
        {
            decimal total = 0;
            foreach (var item in patients)
            {
                total += item.CalculateFinalBill();
            }
            return total;
        }
        public int GetInpatientCount()
        {
            int count = 0;
            foreach (var item in patients)
            {
                if(item is Inpatient)
                    count++;
            }
            return count;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            HospitalBilling hb = new HospitalBilling();
            CultureInfo.CurrentCulture = new CultureInfo("en-US");
            hb.AddPatient(new Patient("P1", 500));
            hb.AddPatient(new Inpatient("P2", 1000, 3, 500));
            hb.AddPatient(new Outpatient("P3", 500, 200));
            hb.AddPatient(new EmergencyPatient("P4", 500, 2));
            hb.GenerateDailyReport();
            Console.WriteLine($"Total Revenue = {hb.CalculateTotalRevenue():C2}");
            Console.WriteLine($"Total Count  = {hb.GetInpatientCount()}");

        }
    }
}
