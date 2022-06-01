
using Employees.type;
using Employees.utils;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace Employees.Model
{
    public class Trader : Employee
    {

        [EmployeeEffectivenessValidator]
        public Effectiveness Effectiveness { get; set; }

        [DefaultValue(15)]
        public double Provision { get; set; }

        [IgnoreDataMember]
        public override int EmployeeValue { get { return this.Experience * (int)Effectiveness; } }
  
        
    }
}
