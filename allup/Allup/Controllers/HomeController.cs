using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Allup.Models;
using Allup.ViewModels;
using Allup.DAL;
using Microsoft.EntityFrameworkCore;

namespace Allup.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;
        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            
            
            HomeVM homeVM = new HomeVM
            {
                Categories = _context.Categories.Where(c=>c.IsMain==true&&c.IsDeleted==false).Include(p=>p.ProductCategories).ThenInclude(p=>p.Product).ThenInclude(p=>p.ProductImages).ToList(),
                Products=_context.Products.Where(p=>p.IsDeleted==false).Include(p=>p.ProductImages).ToList(),
                ProductCategories = _context.ProductCategories.Include(p => p.Product).ThenInclude(p => p.ProductImages).ToList(),
                
            };
            
            return View(homeVM);
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
    }
}
