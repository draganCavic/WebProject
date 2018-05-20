using NekretnineWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NekretnineWeb.ViewModels
{
    public class CustomerListViewModel
    {
        public IEnumerable<ApplicationUser> Customers { get; set; }
    }
}
