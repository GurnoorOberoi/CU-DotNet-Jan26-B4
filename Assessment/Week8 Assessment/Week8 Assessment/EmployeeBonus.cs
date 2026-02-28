using System.Net.Http.Headers;

namespace Week8_Assessment
{
    public class EmployeeBonus
    {
        public decimal BaseSalary { get; set; }
        public int PerformanceRating { get; set; }
        public int YearsOfExperience { get; set; }
        public decimal DepartmentMultiplier { get; set; }
        public double AttendancePercentage { get; set; }
        public decimal NetAnnualBonus 
        {
            get
            {
                if (BaseSalary < 0) return 0m;
                if (AttendancePercentage < 0 || AttendancePercentage > 100)
                    throw new InvalidOperationException("Attendance Should be between 0 and 100.");

                decimal baseBonusPercentage;
                switch (PerformanceRating)
                {
                    case 5: baseBonusPercentage = 0.25m; break;
                    case 4: baseBonusPercentage = 0.18m; break;
                    case 3: baseBonusPercentage = 0.12m; break;
                    case 2: baseBonusPercentage = 0.05m; break;
                    case 1: baseBonusPercentage = 0.00m; break;
                    default:
                        throw new InvalidOperationException("Invalid Performance Rating");
                }
                decimal totalPercentage = baseBonusPercentage;
                if (YearsOfExperience > 10)
                    totalPercentage += 0.05m;
                else if (YearsOfExperience > 5)
                    totalPercentage += 0.03m;
                decimal bonus = BaseSalary * totalPercentage;
                if (AttendancePercentage < 85)
                    bonus *= 0.80m;
                bonus *= DepartmentMultiplier;
                decimal maxBonus = BaseSalary * 0.40m;
                if(bonus> maxBonus)
                    bonus = maxBonus;
                decimal taxRate;
                if (bonus <= 150000)
                    taxRate = 0.10m;
                else if (bonus <= 300000)
                    taxRate = 0.20m;
                else
                    taxRate = 0.30m;

                //Step 7: Final Output
                decimal netBonus = bonus - (bonus * taxRate);

                return Math.Round(netBonus, 2);
            }

        }

    }
}
