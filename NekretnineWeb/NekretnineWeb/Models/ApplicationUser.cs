using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace NekretnineWeb.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public bool Block { get; set; }
        [Required(ErrorMessage = "Morate uneti Vaše ime")]
        [Display(Name = "Ime")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Morate uneti Vaše prezime")]
        [Display(Name = "Prezime")]
        public string LastName { get; set; }

        [Display(Name = "Datum rođenja")]
        [Min18Years]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime BDate { get; set; }

        public List<Property> Properties { get; set; }

        [Required(ErrorMessage = "Morate izabrati pol")]
        [Display(Name = "Pol")]
        public Gender Gender { get; set; }
    }
    public enum Gender
    {
        Male = 1,
        Female = 2
    }
    public class Min18Years : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (ApplicationUser)validationContext.ObjectInstance;

            if (customer.BDate == null)
                return new ValidationResult("Birthdate is required.");

            var age = DateTime.Today.Year - customer.BDate.Year;

            return (age >= 18)
                ? ValidationResult.Success
                : new ValidationResult("Customer should be at least 18 years old to go on a membership.");
        }
    }
}
