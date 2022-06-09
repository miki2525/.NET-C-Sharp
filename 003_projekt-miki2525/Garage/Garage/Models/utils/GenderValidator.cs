using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Garage.Models.utils
{
    public class GenderValidator : ValidationAttribute
    {
        private string[] _allowedValues = {Gender.Mężczyzna.ToString(), Gender.Kobieta.ToString(), Gender.Inne.ToString()};

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (_allowedValues.Contains(value.ToString()))
            {
                return ValidationResult.Success;
            }
            return new ValidationResult("Wrong Gender");
        }
    }
}
