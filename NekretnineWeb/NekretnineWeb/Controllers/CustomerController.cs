using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NekretnineWeb.Data;
using NekretnineWeb.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NekretnineWeb.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CustomerController : Controller
    {

        private readonly ApplicationDbContext _context;

        public CustomerController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            var customer = new CustomerListViewModel
            {
                Customers = _context.ApplicationUser
            };
            return View(customer);
        }
    }
}
