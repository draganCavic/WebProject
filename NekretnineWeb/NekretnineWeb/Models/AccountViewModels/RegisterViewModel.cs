using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NekretnineWeb.Models.AccountViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Morate uneti e-mail")]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Morate uneti lozinku")]
        [StringLength(100, ErrorMessage = "{0} mora imati najmanje {2} a najviše {1} karaktera.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Lozinka")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Potvrda lozinke")]
        [Compare("Password", ErrorMessage = "Potvrda lozinke mora biti ista kao lozinka.")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Morate uneti broj mobilnog telefona")]
        [Display(Name = "Mobilni telefon")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Nije validan broj telefona")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Morate uneti Vaše ime")]
        [Display(Name = "Ime")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Morate uneti Vaše prezime")]
        [Display(Name = "Prezime")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Morate izabrati pol")]
        public Gender Gender { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Datum rođenja")]
        [Min18Years]
        public DateTime BDate { get; set; }
    }
    public class Min18Years : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (RegisterViewModel)validationContext.ObjectInstance;


            if (customer.BDate == null)
                return new ValidationResult("Unesite datum rođenja.");

            var age = DateTime.Today.Year - customer.BDate.Year;

            return (age >= 18)
                ? ValidationResult.Success
                : new ValidationResult("Morate imati najmanje 18 godina.");
        }
    }
}
