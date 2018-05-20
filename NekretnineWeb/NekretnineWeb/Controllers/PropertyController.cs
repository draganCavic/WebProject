using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NekretnineWeb.Data;
using NekretnineWeb.Models;
using NekretnineWeb.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NekretnineWeb.Controllers
{
    public class PropertyController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IPropertyRepository _propertyRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly ICityRepository _cityRepository;
        private readonly ApplicationDbContext _applicationDbContext;

        public PropertyController(ApplicationDbContext applicationDbContext, IPropertyRepository propertyRepository, ICategoryRepository categoryRepository, ICityRepository cityRepository, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _propertyRepository = propertyRepository;
            _categoryRepository = categoryRepository;
            _cityRepository = cityRepository;
            _signInManager = signInManager;
            _userManager = userManager;
            _applicationDbContext = applicationDbContext;
        }
        //GET:Property/5
        [HttpGet("{id}")]
        public IActionResult EditProperty([FromRoute] int id)
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
        [Authorize]
        //GET:Property/
        public async Task<IActionResult> MyProperty()
        {
            var user = await _userManager.GetUserAsync(User);
            IEnumerable<Property> properties = _propertyRepository.Properties.Where(p => p.Customer == user)
                   .OrderBy(p => p.PropertyId);
            var myProperty = new PropertiesListViewModel
            {
                Properties = properties
            };
            return View(myProperty);
        }
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AllProperty()
        {
            var user = await _userManager.GetUserAsync(User);
            IEnumerable<Property> properties = _propertyRepository.Properties;
            var allProperty = new PropertiesListViewModel
            {
                Properties = properties
            };
            return View("MyProperty", allProperty);
        }
        public IActionResult DeleteProperty(int id)
        {
            var property = _propertyRepository.Properties.Where(p => p.PropertyId == id);

            if (property != null)
            {
                _propertyRepository.DeleteProperty((Property)property);
            }

            return View("MyProperty");
        }
        public ViewResult List(string category)
        {
            IEnumerable<Property> properties;
            string currentCategory = string.Empty;

            if (string.IsNullOrEmpty(category))
            {
                properties = _propertyRepository.Properties.OrderBy(p => p.PropertyId);
                currentCategory = "All";
            }
            else
            {
                properties = _propertyRepository.Properties.Where(p => p.Category.CategoryName == category)
                   .OrderBy(p => p.PropertyId);
                currentCategory = _categoryRepository.Categories.FirstOrDefault(c => c.CategoryName == category).CategoryName;
            }

            return View(new PropertiesListViewModel
            {
                Properties = properties,
                CurrentCategory = currentCategory,
            });
        }
        [Authorize]
        public async Task<IActionResult> AddProperty(PropertyViewModel model)
        {
            var categ = _categoryRepository.Categories.OrderBy(c => c.CategoryName).Select(x => new { IdCa = x.CategoryId, ValueCa = x.CategoryName });
            var cit = _cityRepository.Cities.OrderBy(c => c.CityName).Select(x => new { IdCi = x.CityId, ValueCi = x.CityName });

            //var model1 = new PropertyViewModel();
            //model1.categories = new SelectList(categ, "IdCa", "ValueCa");
            //model1.cities = new SelectList(cit, "IdCi", "ValueCi");
            var user = await _userManager.GetUserAsync(User);

            //int i = 0;
            //if (i > 0)
            //{
            //    property.Address = model.property.Address;
            //    property.Area = model.property.Area;
            //    property.Baths = model.property.Baths;
            //    property.Category = model.property.Category;
            //    property.City = model.property.City;
            //    property.Date = DateTime.Now;
            //    property.Email = model.property.Email;
            //    property.ImageUrl = model.property.ImageUrl;
            //    property.LongDescription = model.property.LongDescription;
            //    property.PhoneNumber = model.property.PhoneNumber;
            //    property.Price = model.property.Price;
            //    property.Rooms = model.property.Rooms;
            //    property.ShortDescription = model.property.ShortDescription;  model.property != null
            //}
            if (!ModelState.IsValid)
            {
                int a, b;
                a = model.property.CategoryId;
                b = model.property.CityId;

                Property property = new Property
                {
                    Customer = user,
                    Address = model.property.Address,
                    Area = model.property.Area,
                    Baths = model.property.Baths,
                    CategoryId = model.property.CategoryId,
                    Category = _categoryRepository.Categories.ElementAt(a-1),
                    CityId = model.property.CityId,
                    City = _cityRepository.Cities.ElementAt(b-1),
                    Date = DateTime.Now,
                    Email = model.property.Email,
                    ImageUrl = model.property.ImageUrl,
                    LongDescription = model.property.LongDescription,
                    PhoneNumber = model.property.PhoneNumber,
                    Price = model.property.Price,
                    Rooms = model.property.Rooms,
                    Tel = user.PhoneNumber,
                    Mail = user.Email,
                    ShortDescription = model.property.ShortDescription
                };
                //Property prop = new Property();
                //prop.Customer = user;
                //prop.Address = model.property.Address;
                //prop.Area = model.property.Area;
                //prop.Baths = model.property.Baths;

                //prop.Date = DateTime.Now;
                //prop.Email = model.property.Email;
                //prop.ImageUrl = model.property.ImageUrl;
                //prop.LongDescription = model.property.LongDescription;
                //prop.PhoneNumber = model.property.PhoneNumber;
                //prop.Price = model.property.Price;
                //prop.Rooms = model.property.Rooms;
                //prop.ShortDescription = model.property.ShortDescription;
                //prop.CategoryId = model.property.CategoryId;
                //prop.CityId = model.property.CityId;
                //prop.City = _cityRepository.Cities.ElementAt(b-1);
                //prop.Category = _categoryRepository.Categories.ElementAt(a-1);

                _propertyRepository.CreateProperty(property);
                return RedirectToAction("Index", "Home");

            }
            model.categories = new SelectList(categ, "IdCa", "ValueCa");
            model.cities = new SelectList(cit, "IdCi", "ValueCi");
            return View(model);
        }
        public IActionResult EdiProperty(int id)
        {
            var propertyViewModel = new PropertyViewModel
            {
                property = (Property)_propertyRepository.Properties.Where(p => p.PropertyId == id)
            };
            //if (propertyViewModel == null)
            //{
            //    return NotFound();
            //}
            //return View("AddProperty", propertyViewModel);
            return View("../Home/Index");
        }
        public IActionResult Details(int id)
        {
            var property = _propertyRepository.GetPropertyById(id);
            var city = _cityRepository.Cities.FirstOrDefault(c => c.CityId == property.CityId);
            var category = _categoryRepository.Categories.FirstOrDefault(c => c.CategoryId == property.CategoryId);
            //var user = _applicationDbContext.Users.FirstOrDefault(u => u.Id == property.Customer.Id);
            var details = new DetailsViewModel
            {
                Property = property,
                Category = category,
                City = city,
                //User = user
            };
            if (details == null)
                return NotFound();

            return View(details);
        }
    }
}
