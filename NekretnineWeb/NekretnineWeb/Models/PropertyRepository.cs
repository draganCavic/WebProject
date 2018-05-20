using Microsoft.EntityFrameworkCore;
using NekretnineWeb.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NekretnineWeb.Models
{
    public class PropertyRepository : IPropertyRepository
    {
        private readonly ApplicationDbContext _appDbContext;

        public PropertyRepository(ApplicationDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Property> Properties
        {
            get
            {
                return _appDbContext.Properties.Include(c => c.Category)
                                               .Include(c => c.City)
                                               .Include(c => c.Customer);
            }
        }

        public Property GetPropertyById(int propertyId)
        {
            return _appDbContext.Properties.FirstOrDefault(p => p.PropertyId == propertyId);
        }

        public void CreateProperty(Property property)
        {
            property.Date = DateTime.Now;

            _appDbContext.Properties.Add(property);

            _appDbContext.SaveChanges();
        }
        public void DeleteProperty(Property property)
        {
            _appDbContext.Properties.Remove(property);

            _appDbContext.SaveChanges();
        }
        public void UpdateProperty(Property property)
        {
            _appDbContext.Properties.Update(property);

            _appDbContext.SaveChanges();
        }
    }
}
