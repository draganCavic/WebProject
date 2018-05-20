using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NekretnineWeb.Models
{
    public class Property
    {
        public int PropertyId { get; set; }
        public int CategoryId { get; set; }
        public int CityId { get; set; }

        [Required(ErrorMessage = "Odaberite naziv grada")]
        [Display(Name = "Grad")]
        public City City { get; set; }

        [Required(ErrorMessage = "Odaberite kategoriju")]
        [Display(Name = "Kategorija")]
        public virtual Category Category { get; set; }

        [Display(Name = "Kratak opis")]
        [StringLength(30)]
        public string ShortDescription { get; set; }

        [Display(Name = "Opis")]
        [StringLength(200)]
        public string LongDescription { get; set; }

        [Required(ErrorMessage = "Unesite cenu")]
        //[MinValue(0)]
        [DataType(DataType.Currency)]
        [Display(Name = "Cena")]
        [DisplayFormat(DataFormatString = "{0:n0}")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Unesite adresu")]
        [StringLength(100)]
        [Display(Name = "Adresa")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Unesite površinu")]
        //[MinValue(0)]
        [Display(Name = "Površina")]
        public decimal Area { get; set; }

        [Display(Name = "Broj telefona")]
        public bool PhoneNumber { get; set; }

        [Display(Name = "E-mail")]
        public bool Email { get; set; }

        [Url]
        [Display(Name = "Url fotografije")]
        public string ImageUrl { get; set; }

        //[MinValue(0)]
        [Display(Name = "Broj soba")]
        public int Rooms { get; set; }

        //[MinValue(0)]
        [Display(Name = "Broj kupatila")]
        public int Baths { get; set; }

        [Display(Name = "Datum")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Date { get; set; }

        public int CustomerId { get; set; }
        public virtual ApplicationUser Customer { get; set; }

        public string Tel { get; set; }

        public string Mail { get; set; }
    }
    //public class MinValueAttribute : ValidationAttribute
    //{
    //    private readonly int _minvalue;

    //    public MinValueAttribute(int minvalue)
    //    {
    //        _minvalue = minvalue;
    //        //return new ValidationResult("Unesite pozitivnu vrednost.");
    //    }

    //    protected override ValidationResult IsValid(object value)
    //    {
    //        //return (int)value <= _minvalue;
    //        if ((int)value <= _minvalue)
    //        {
    //            return new ValidationResult("Unesite pozitivnu vrednost.");
    //        }

    //        return ValidationResult.Success;
    //    }
    //}
}
