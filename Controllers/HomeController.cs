using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ASP_Core_MVS_Webapp.Models;

namespace ASP_Core_MVS_Webapp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ShopContext db;
        public HomeController(ILogger<HomeController> logger,ShopContext context)
        {
            _logger = logger;
            db = context;
        }

        public IActionResult Index()
        {
            return View(db.Categories.ToList());
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task< IActionResult> Create(Category category)
        {
            if(!ModelState.IsValid)
            {
                return View(category);
            }
           await db.Categories.AddAsync(category);
           await  db.SaveChangesAsync();
            return RedirectToAction("index");
        }
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null)
                return NotFound();
            Category category = db.Categories.Find(id);
            if (category == null)
                return NotFound();
            return View(category);
        }
        [HttpPost]
        public async Task <IActionResult> Edit(Category category)
        {
           if(!ModelState.IsValid)
            {
                return View(category);
            }
          
            db.Entry(category).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int?id)
        {
            if (id == null)
                return NotFound();
            Category category = await db.Categories.FindAsync(id);
            if (category == null)
                return NotFound();
            return View(category);
        }
        [HttpPost,ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            if (id == null)
                return NotFound();

            Category category = await db.Categories.FindAsync(id);
            db.Categories.Remove(category);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public async Task<IActionResult> Details(int? id)
        {
            if(id==null)
            {
                return NotFound();
            }
            Category category = await db.Categories.FindAsync(id);
            return View(category);
        }
    }
}
