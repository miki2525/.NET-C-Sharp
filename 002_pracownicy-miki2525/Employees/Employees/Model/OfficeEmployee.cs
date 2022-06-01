
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace Employees.Model
{
    public class OfficeEmployee : Employee
    {

        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [IgnoreDataMember]
        public Guid OfficeId => Guid.NewGuid();

        [Range(75, 150, ErrorMessage = "The Intellect must be 75 - 150")]
        public int Intellect { get; set; }

        [IgnoreDataMember]
        public override int EmployeeValue { get { return this.Experience * this.Intellect; } }
    }
}
