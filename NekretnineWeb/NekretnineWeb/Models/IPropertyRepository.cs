using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NekretnineWeb.Models
{
    public interface IPropertyRepository
    {
        IEnumerable<Property> Properties { get; }

        Property GetPropertyById(int propertyId);

        void CreateProperty(Property property);

        void DeleteProperty(Property property);

        void  UpdateProperty(Property property);
    }
}
