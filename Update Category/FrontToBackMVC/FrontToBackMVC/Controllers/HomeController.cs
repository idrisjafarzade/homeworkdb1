using FrontToBackMVC.DataAccsessLayer;
using FrontToBackMVC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace FrontToBackMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _appDbContext;

        public HomeController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<IActionResult> Index()
        {
            var category = await _appDbContext.Categories.Where(x => x.IsMain == true).ToListAsync();
            return View(new HomeVM 
            {
                Categories = category
            });
        }
    }
}
