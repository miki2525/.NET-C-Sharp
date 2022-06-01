using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Employees.Model
{
    public class Workman : Employee
    {

        [Range(1, 100, ErrorMessage = "The PhysicalStrength must be 1 - 100")]
        public int PhysicalStrength { get; set; }

        [IgnoreDataMember]
        public override int EmployeeValue
        {
            get
            {
                if (Age > 0)
                {
                    return (this.Experience * this.PhysicalStrength) / this.Age;
                }
                else
                {
                    throw new ArithmeticException("Age can't be 0 !!!");
                }

            }
        }
    }
}
