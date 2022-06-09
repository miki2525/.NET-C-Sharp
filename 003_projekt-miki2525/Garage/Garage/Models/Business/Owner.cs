using Garage.Models.utils;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Garage.Models
{
    public class Owner
    {
        public int Id { get; set; }
        [Display(Name = "Imię")]
        [Required]
        public string FisrtName { get; set; }
        [Required]
        [Display(Name = "Nazwisko")]
        public string LastName { get; set; }
        [Required]
        [Display(Name = "Telefon")]
        [Phone]
        public string Phone { get; set; }
        [Required]
        [Display(Name = "Adres E-mail")]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [Display(Name = "Płeć")]
        [GenderValidator]
        public Gender Gender { get; set; }
        [Display(Name = "Samochody")]
        public List<Car> Cars { get; set; }
    }

    public enum Gender
    {
        Mężczyzna,
        Kobieta,
        Inne
    }
    static class GenderMethods
    {
        public static IEnumerable<Gender> GetValues()
        { 
            return (IEnumerable<Gender>)Enum.GetValues(typeof(Gender));
        }
    }
}
