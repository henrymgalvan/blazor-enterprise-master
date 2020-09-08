using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BethanysPieShopHRM.Shared
{
    public class Address : IValidatableObject
    {
        public int Id { get; set; }
        [Required]
        public string Street { get; set; }
        [Required]
        public string Zip { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public int CountryId { get; set; }
        public Country Country { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var errors = new List<ValidationResult>();
            if (Latitude != 0 && Longitude == 0)
            {
                errors.Add(new ValidationResult("Longitude is required", new[] { nameof(Longitude)}));
            }
            else if (Latitude == 0 && Longitude != 0)
            {
                errors.Add(new ValidationResult("Latitude is required", new[] { nameof(Latitude) }));
            }

            return errors;
        }
    }
}
