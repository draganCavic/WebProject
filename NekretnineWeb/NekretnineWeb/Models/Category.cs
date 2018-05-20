using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NekretnineWeb.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        [Display(Name = "Kategorija")]
        public string CategoryName { get; set; }
        [Display(Name = "Opis")]
        public string Description { get; set; }
        public List<Property> Properties { get; set; }
    }
}
