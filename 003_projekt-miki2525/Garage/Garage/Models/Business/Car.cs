using System.ComponentModel.DataAnnotations;

namespace Garage.Models
{
    public class Car
    {
        public int Id { get; set; }
        [Display(Name = "Marka")]
        [MaxLength(50)]
        [Required]
        public string Brand { get; set; }
        [Display(Name = "Model")]
        [MaxLength(50)]
        [Required]
        public string Name { get; set; }
        [Display(Name = "Cena")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Cena musi zawierać tylko cyfry")]
        [Required]
        public int Price { get; set; }
        [Display(Name = "Rok")]
        [Range(1900, 2022, ErrorMessage = "Rok musi zawierać się w przedziale 1900-2022")]
        [Required]
        public int Year { get; set; }
        [Required]
        [Display(Name = "Kolor")]
        public string Color { get; set; }
        [Display(Name = "Właściciel")]
        public Owner Owner { get; set; }
        [Required]
        [Display(Name = "Właściciel")]
        public int OwnerId { get; set; }
    }
}
