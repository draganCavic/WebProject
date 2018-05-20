using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NekretnineWeb.Models
{
    public class City
    {
        public int CityId { get; set; }

        [Display(Name = "Grad")]
        public string CityName { get; set; }
        [Display(Name = "Opis")]
        public string Description { get; set; }
        [Display(Name = "Populacija")]
        public int Population { get; set; }
        [Display(Name = "Površina")]
        public double Area { get; set; }
        public string ImageUrl1 { get; set; }
        public string ImageUrl2 { get; set; }
        public string ImageUrl3 { get; set; }
        [Display(Name = "Država")]
        public string Country { get; set; }
        public List<Property> Properties { get; set; }
    }
}
