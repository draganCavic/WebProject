using NekretnineWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NekretnineWeb.ViewModels
{
    public class PropertiesListViewModel
    {
        public IEnumerable<Property> Properties { get; set; }
        public string CurrentCategory { get; set; }
        public string CurrentCity { get; set; }
        public int min { get; set; }
        public int max { get; set; }
    }
}
