using Employees.type;
using System.ComponentModel.DataAnnotations;

namespace Employees.utils
{
    public class EmployeeEffectivenessValidator : ValidationAttribute
    {
        private int[] _allowedValues = { (int)Effectiveness.NISKA, (int)Effectiveness.ŚREDNIA, (int)Effectiveness.WYSOKA};

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (_allowedValues.Contains((int)value))
            {
                return ValidationResult.Success;
            }
            return new ValidationResult("Effectiveness is not a valid. Only [60, 90, 120]");
        }
    }

}
