using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NekretnineWeb.Data;
using NekretnineWeb.Models;
using NekretnineWeb.ViewModels;

namespace NekretnineWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index(string search, string searchC)
        {
            var PropertiesListViewModel = new PropertiesListViewModel();
            int sea = Convert.ToInt32(search);
            int seaC = Convert.ToInt32(searchC);

            if (search != null)
            {
                if (searchC == null)
                    PropertiesListViewModel.Properties = _context.Properties.Where(p => p.CategoryId == sea);
                else
                    PropertiesListViewModel.Properties = _context.Properties.Where(p => p.CategoryId == sea && p.CityId == seaC);
            }
            else
            {
                if (searchC == null)
                    PropertiesListViewModel.Properties = _context.Properties;
                else
                    PropertiesListViewModel.Properties = _context.Properties.Where(p => p.CityId == seaC);
            }
            return View(PropertiesListViewModel);
        }
        //public IActionResult Index(int minimum, int maximum)
        //{
        //    var PropertiesListViewModel = new PropertiesListViewModel
        //    {
        //        Properties = _context.Properties
        //    };
        //    PropertiesListViewModel.min = minimum;

        //    PropertiesListViewModel.max = maximum;

        //    return View(PropertiesListViewModel);
        //}

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
