﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NekretnineWeb.Data;
using NekretnineWeb.Models;

namespace NekretnineWeb.Controllers
{
    public class PropertiesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PropertiesController(ApplicationDbContext context)
        {
            _context = context;
        }

        //// GET: Properties
        //public async Task<IActionResult> Index()
        //{
        //    var applicationDbContext = _context.Properties.Include(@ => @.Category).Include(@ => @.City);
        //    return View(await applicationDbContext.ToListAsync());
        //}

        //// GET: Properties/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var @property = await _context.Properties
        //        .Include(@ => @.Category)
        //        .Include(@ => @.City)
        //        .SingleOrDefaultAsync(m => m.PropertyId == id);
        //    if (@property == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(@property);
        //}

        //// GET: Properties/Create
        //public IActionResult Create()
        //{
        //    ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryId");
        //    ViewData["CityId"] = new SelectList(_context.Cities, "CityId", "CityId");
        //    return View();
        //}

        //// POST: Properties/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("PropertyId,CategoryId,CityId,ShortDescription,LongDescription,Price,Address,Area,PhoneNumber,Email,ImageUrl,Rooms,Baths,Date,CustomerId,Tel,Mail")] Property @property)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(@property);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryId", @property.CategoryId);
        //    ViewData["CityId"] = new SelectList(_context.Cities, "CityId", "CityId", @property.CityId);
        //    return View(@property);
        //}

        //// GET: Properties/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var @property = await _context.Properties.SingleOrDefaultAsync(m => m.PropertyId == id);
        //    if (@property == null)
        //    {
        //        return NotFound();
        //    }
        //    ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryId", @property.CategoryId);
        //    ViewData["CityId"] = new SelectList(_context.Cities, "CityId", "CityId", @property.CityId);
        //    return View(@property);
        //}

        //// POST: Properties/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("PropertyId,CategoryId,CityId,ShortDescription,LongDescription,Price,Address,Area,PhoneNumber,Email,ImageUrl,Rooms,Baths,Date,CustomerId,Tel,Mail")] Property @property)
        //{
        //    if (id != @property.PropertyId)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(@property);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!PropertyExists(@property.PropertyId))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryId", @property.CategoryId);
        //    ViewData["CityId"] = new SelectList(_context.Cities, "CityId", "CityId", @property.CityId);
        //    return View(@property);
        //}

        //// GET: Properties/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var @property = await _context.Properties
        //        .Include(@ => @.Category)
        //        .Include(@ => @.City)
        //        .SingleOrDefaultAsync(m => m.PropertyId == id);
        //    if (@property == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(@property);
        //}

        //// POST: Properties/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var @property = await _context.Properties.SingleOrDefaultAsync(m => m.PropertyId == id);
        //    _context.Properties.Remove(@property);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool PropertyExists(int id)
        //{
        //    return _context.Properties.Any(e => e.PropertyId == id);
        //}
    }
}
