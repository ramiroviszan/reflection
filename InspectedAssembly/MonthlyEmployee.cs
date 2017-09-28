using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InspectedAssembly
{
    public class MonthlyEmployee : Employee
    {
        public double MonthlySalary { get; set; }
        public MonthlyEmployee() { }
        public MonthlyEmployee(string aName, String aCI, double aSalary)
        : base(aName, aCI)
        {
            MonthlySalary = aSalary;
        }
        public override string ToString()
        {
            return string.Format("{0} {1}", "Monthly employee", base.ToString());
        }
        public override double CalculateSalary()
        {
            return MonthlySalary;
        }
    }
}
