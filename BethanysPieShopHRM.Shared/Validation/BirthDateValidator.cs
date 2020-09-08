using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BethanysPieShopHRM.Shared
{
    public class BirthDateValidator : ValidationAttribute
    {
        public int MinimumAge { get; set; }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (DateTime.TryParse(value.ToString(), out DateTime birthDate))
            {
                if (birthDate < DateTime.Now.AddYears(MinimumAge * -1))
                {
                    return null;
                }
                else
                {
                    return new ValidationResult("Employee must be at least 18", new[] { validationContext.MemberName });
                }
            }

            return new ValidationResult("Invalid bith date", new[] { validationContext.MemberName });
        }
    }
}
