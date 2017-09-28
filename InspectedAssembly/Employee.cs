using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InspectedAssembly
{
    public abstract class Employee
    {
        public string Name { get; set; }
        public string CI { get; set; }
        public Employee()
        {
            Name = "Unnamed";
            CI = "This guy's no documents";
        }
        public Employee(String aName, string aCI)
        {
            Name = aName;
            CI = aCI;
        }
        public override string ToString()
        {
            return string.Format("{0} - {1}", CI, Name);
        }
        public abstract double CalculateSalary();
    }
}
