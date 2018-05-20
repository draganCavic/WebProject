using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NekretnineWeb.Models
{
    public interface ICityRepository
    {
        IEnumerable<City> Cities { get; }
    }
}
