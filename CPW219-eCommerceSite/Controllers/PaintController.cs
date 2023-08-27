using Microsoft.AspNetCore.Mvc;
using CPW219_eCommerceSite.Models;
using CPW219_eCommerceSite.Data;

namespace CPW219_eCommerceSite.Controllers
{
    public class PaintController : Controller
    {
        private readonly PaintProductContext _context;

        public PaintController(PaintProductContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Paint p)
        {
            if(ModelState.IsValid)
            {
                _context.Paints.Add(p); // Prepares insert
                _context.SaveChanges(); // Executes pending insert

                ViewData["Message"] = $"{p.Title} was added successfully!";
                return View();
            }

            return View(p);
        }
    }
}
