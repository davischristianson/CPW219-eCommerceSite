﻿using Microsoft.AspNetCore.Mvc;
using CPW219_eCommerceSite.Models;
using CPW219_eCommerceSite.Data;
using Microsoft.EntityFrameworkCore;

namespace CPW219_eCommerceSite.Controllers
{
    public class PaintController : Controller
    {
        private readonly PaintProductContext _context;

        public PaintController(PaintProductContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            List<Paint> paints = await _context.Paints.ToListAsync();

            return View(paints);
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Paint paintToCreate)
        {
            if(ModelState.IsValid)
            {
                _context.Paints.Add(paintToCreate); // Prepares insert
                // For async code info in the tutorial
                // https://learn.microsoft.com/en-us/aspnet/core/data/ef-mvc/intro?view=aspnetcore-7.0#asynchronous-code
                await _context.SaveChangesAsync(); // Executes pending insert

                ViewData["Message"] = $"{paintToCreate.Title} was added successfully!";
                return View();
            }

            return View(paintToCreate);
        }

        public async Task<IActionResult> Edit(int id)
        {
            Paint paintToEdit = await _context.Paints.FindAsync(id);

            if(paintToEdit == null)
            {
                return NotFound();
            }

            return View(paintToEdit);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Paint paintModel)
        {
            if (ModelState.IsValid)
            {
                _context.Paints.Update(paintModel);
                await _context.SaveChangesAsync();

                TempData["Message"] = $"{paintModel.Title} was updated successfully!";
                return RedirectToAction("Index");
            }

            return View(paintModel);
        }

        public async Task<IActionResult> Delete(int id)
        {
            Paint? paintToDelete = await _context.Paints.FindAsync(id);

            if (paintToDelete == null)
            {
                return NotFound();
            }

            return View(paintToDelete);
        }

        // Action makes the method act like the Delete function despite having a different name
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            Paint paintToDelete = await _context.Paints.FindAsync(id);

            if(paintToDelete != null)
            {
                _context.Paints.Remove(paintToDelete);
                await _context.SaveChangesAsync();
                TempData["Message"] = paintToDelete.Title + " was deleted successfully!";
                return RedirectToAction("Index");
            }

            TempData["Message"] = "This paint product was already deleted!";
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Details(int id)
        {
            Paint? paintDetails = await _context.Paints.FindAsync(id);

            if(paintDetails == null)
            {
                return NotFound();
            }

            return View(paintDetails);
        }
    }
}
