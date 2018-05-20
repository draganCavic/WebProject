using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NekretnineWeb.Models;
using NekretnineWeb.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NekretnineWeb.Controllers.Api
{
    [Produces("application/json")]
    [Route("api/Property")]
    public class PropertyController : Controller
    {
        private readonly IPropertyRepository _propertyRepository;
        private readonly UserManager<ApplicationUser> _userManager;
        public PropertyController(IPropertyRepository propertyRepository, UserManager<ApplicationUser> userManager)
        {
            _propertyRepository = propertyRepository;
            _userManager = userManager;
        }
        // GET: api/Property
        [HttpGet]
        public IEnumerable<Property> GetProperties()
        {
            return _propertyRepository.Properties;
        }
        //// POST: api/Property/5
        [HttpPost]
        public IActionResult Edit(PropertyViewModel model)
        {
            if (!ModelState.IsValid)
            {
                Property property = _propertyRepository.Properties.SingleOrDefault(p => p.CustomerId == model.property.PropertyId);
                property.LongDescription = model.property.LongDescription;
                property.ImageUrl = model.property.ImageUrl;
                property.PhoneNumber = model.property.PhoneNumber;
                property.Price = model.property.Price;
                property.Rooms = model.property.Rooms;
                property.Email = model.property.Email;
                property.Date = DateTime.Now;
                property.Baths = model.property.Baths;
                property.Area = model.property.Area;
                _propertyRepository.UpdateProperty(property);
                return RedirectToAction("Index", "Home");
            }
            else
                return NotFound();

        }
        // GET: api/Property/5
        [HttpGet("{id}")]
        public IActionResult Edit([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var propertyViewModel = new PropertyViewModel
            {
                property = _propertyRepository.Properties.SingleOrDefault(p => p.PropertyId == id),
            };

            propertyViewModel.category = propertyViewModel.property.CategoryId;
            propertyViewModel.city = propertyViewModel.property.CityId;

            if (propertyViewModel.property == null)
            {
                return NotFound();
            }
            //return View("../Property/EditProperty", propertyViewModel);
            return View("../Property/EditProperty", propertyViewModel);
        }
        public IActionResult Editt(int id)
        {
            var propertyViewModel = new PropertyViewModel
            {
                property = (Property)_propertyRepository.Properties.Where(p => p.PropertyId == id)
            };
            ViewData["CategoryId"] = propertyViewModel.property.CategoryId;
            ViewData["CityId"] = propertyViewModel.property.CityId;
            //    ViewData["CityId"] = new SelectList(_context.Cities, "CityId", "CityId", @property.CityId);
            //if (propertyViewModel == null)
            //{
            //    return NotFound();
            //}
            //return View("../Property/EditProperty", propertyViewModel);
            return View("../Home/Index");
        }
        [Authorize]
        // DELETE: api/Property/5
        [HttpDelete("{id}")]
        public IActionResult DeleteProperty(int id)
        {
            var customerInDb = _propertyRepository.Properties.SingleOrDefault(c => c.PropertyId == id);

            if (customerInDb == null)
                return NotFound();

            _propertyRepository.DeleteProperty(customerInDb);

            return Ok();
        }
    }
}
