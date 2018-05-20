using NekretnineWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NekretnineWeb.ViewModels
{
    public class DetailsViewModel
    {
        public Property Property { get; set; }
        public City City { get; set; }
        public Category Category { get; set; }
        public ApplicationUser User { get; set; }
    }
}
