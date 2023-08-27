using Microsoft.AspNetCore.Mvc;
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
        public async Task<IActionResult> Create(Paint p)
        {
            if(ModelState.IsValid)
            {
                _context.Paints.Add(p); // Prepares insert
                // For async code info in the tutorial
                // https://learn.microsoft.com/en-us/aspnet/core/data/ef-mvc/intro?view=aspnetcore-7.0#asynchronous-code
                await _context.SaveChangesAsync(); // Executes pending insert

                ViewData["Message"] = $"{p.Title} was added successfully!";
                return View();
            }

            return View(p);
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

                return RedirectToAction("Index");
            }

            return View(paintModel);
        }
    }
}
