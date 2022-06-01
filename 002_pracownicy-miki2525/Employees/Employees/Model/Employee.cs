
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;



namespace Employees.Model
{
    [Table("allEmployees")]
    public abstract class Employee
    {


        [IgnoreDataMember]
        public int Id { get; set; }
        [DefaultValue("John")]
        public string FirstName { get; set; }
        [DefaultValue("Last")]
        public string LastName { get; set; }
        [Range(1, 125, ErrorMessage = "Age must not be 0")]
        [DefaultValue(25)]
        public int Age { get; set; }
        [DefaultValue(10)]
        public int Experience { get; set; }
        [DefaultValue("Street")]
        public string StreetName { get; set; }
        [DefaultValue(5)]
        public int BuildNumber { get; set; }
        [DefaultValue(5)]
        public int ApartmentNumber { get; set; }
        [DefaultValue("City")]
        public string City { get; set; }

        [IgnoreDataMember]
        public abstract int EmployeeValue { get; }


    }
}