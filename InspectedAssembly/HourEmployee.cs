using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InspectedAssembly
{
    public class HourEmployee : Employee
    {
        public double HourValue { get; set; }
        public int HoursWorked { get; set; }
        public HourEmployee() { }
        public HourEmployee(string aName, String aCI, double anHourValue, int someHoursWorked)
        : base(aName, aCI)
        {
            HourValue = anHourValue;
            HoursWorked = someHoursWorked;
        }
        public override string ToString()
        {
            return string.Format("{0} {1}", "Hour Employee", base.ToString());
        }
        public override double CalculateSalary()
        {
            return HoursWorked * HourValue;
        }
    }
}
