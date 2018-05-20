using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NekretnineWeb.Models.ManageViewModels
{
    public class ChangePasswordViewModel
    {
        [Required(ErrorMessage = "Unesite trenutnu lozinku")]
        [DataType(DataType.Password)]
        [Display(Name = "Trenutna lozinka")]
        public string OldPassword { get; set; }

        [Required(ErrorMessage = "Unesite novu lozinku")]
        [StringLength(100, ErrorMessage = "{0} mora imati najmanje {2} a najviše {1} karaktera.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Nova lozinka")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Potvrda nove lozinke")]
        [Compare("NewPassword", ErrorMessage = "Potvrda nove lozinke mora biti ista kao nova lozinka.")]
        public string ConfirmPassword { get; set; }

        public string StatusMessage { get; set; }
    }
}
