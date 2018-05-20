using NekretnineWeb.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NekretnineWeb.Models
{
    public class CityRepository : ICityRepository
    {
        private readonly ApplicationDbContext _appDbContext;

        public CityRepository(ApplicationDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<City> Cities => _appDbContext.Cities;
    }
}
