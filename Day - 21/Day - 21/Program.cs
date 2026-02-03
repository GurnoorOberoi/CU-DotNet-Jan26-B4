using System.Diagnostics;
using System.Globalization;

namespace Day___21
{
    class Policy
    {
        public string Holdername { get; set; }
        public decimal Premium { get; set; }
        public int RiskScore { get; set; }
        public DateTime RenewalDate { get; set; }
        public override string ToString()
        {
            return $"Name: {Holdername}, Premium: {Premium:C}, RiskScore: {RiskScore}, Renewal: {RenewalDate:d}";
        }
    }
    class PolicyTracker
    {
        Dictionary<string, Policy> policy = new Dictionary<string, Policy>();
        public void AddPolicy(string policyId, Policy p)
        {
            policy[policyId] = p;
        }
        public void BulkAdjustment()
        {
            foreach (var item in policy.Values)
            {
                if(item.RiskScore > 75)
                {
                    item.Premium += item.Premium * 0.05m;
                }
            }
        }

        public void CleanUp()
        {
            List<string> keysToRemove = new List<string>();
            DateTime cutoffDate = DateTime.Now.AddYears(-3);

            foreach (var entry in policy)
            {
                if (entry.Value.RenewalDate < cutoffDate)
                {
                    keysToRemove.Add(entry.Key);
                }
            }

            foreach (string key in keysToRemove)
            {
                policy.Remove(key);
            }
        }

        public string GetPolicyById(string id)
        {
            if(policy.TryGetValue(id, out Policy p))
            {
                return p.ToString();
            }
            return "Not Found";
        }
        public void DisplayAll()
        {
            foreach (var entry in policy)
            {
                Console.WriteLine($"Policy ID: {entry.Key}, Name: {entry.Value.Holdername}, Premium: {entry.Value.Premium}," +
                    $"Risk Score: {entry.Value.RiskScore}, Renewal Date: {entry.Value.RenewalDate}");
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            PolicyTracker pt = new PolicyTracker();
            pt.AddPolicy("101", new Policy
            {
                Holdername = "P1",
                Premium = 35760,
                RiskScore = 80,
                RenewalDate = DateTime.Now.AddYears(-1)
            });

            pt.AddPolicy("102", new Policy
            {
                Holdername = "P2",
                Premium = 20000,
                RiskScore = 65,
                RenewalDate = DateTime.Now.AddYears(-4)
            });

            pt.AddPolicy("103", new Policy
            {
                Holdername = "P3",
                Premium = 1700,
                RiskScore = 90,
                RenewalDate = DateTime.Now
            });
            Console.WriteLine("\nBefore Updates:");
            pt.DisplayAll();
            pt.BulkAdjustment();
            pt.CleanUp();
            Console.WriteLine("\nAfter Updates:");
            pt.DisplayAll();
            Console.WriteLine();
            Console.WriteLine(pt.GetPolicyById("101"));
            Console.WriteLine(pt.GetPolicyById("999"));

        }
    }
}
