using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NekretnineWeb.Data;
using NekretnineWeb.Models;
using NekretnineWeb.ViewModels;

namespace NekretnineWeb.Controllers.Api
{
    [Authorize(Roles = "Admin")]
    [Produces("application/json")]
    [Route("api/Customer")]
    public class CustomerController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CustomerController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Customer
        [HttpGet]
        public IActionResult GetCustomers()
        {
            var users = new CustomerListViewModel
            {
                Customers = _context.ApplicationUser
            };
            return View("Index", users);
        }

        // GET: api/Customer/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomer([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var applicationUser = await _context.ApplicationUser.SingleOrDefaultAsync(m => m.Id == id);

            if (applicationUser == null)
            {
                return NotFound();
            }

            return Ok(applicationUser);
        }

        // PUT: api/Customer/
        [HttpPut("{id}")]
        public IActionResult PutApplicationUser([FromRoute] string id)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}

            //if (id != applicationUser.Id)
            //{
            //    return BadRequest();
            //}

            //_context.Entry(applicationUser).State = EntityState.Modified;
            var user = _context.Users.FirstOrDefault(c => c.Id == id);
            user.Block = true;

            _context.Users.Update(user);
            _context.SaveChanges();

            return Ok();
        }

        //// POST: api/Customer
        //[HttpPost]
        //public async Task<IActionResult> PostApplicationUser([FromBody] ApplicationUser applicationUser)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    _context.ApplicationUser.Add(applicationUser);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetApplicationUser", new { id = applicationUser.Id }, applicationUser);
        //}

        // DELETE: api/Customer/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var applicationUser = await _context.ApplicationUser.SingleOrDefaultAsync(m => m.Id == id);
            if (applicationUser == null)
            {
                return NotFound();
            }

            applicationUser.Block = true;
            await _context.SaveChangesAsync();

            return Ok(applicationUser);
        }

        private bool CustomerExists(string id)
        {
            return _context.ApplicationUser.Any(e => e.Id == id);
        }
    }
}