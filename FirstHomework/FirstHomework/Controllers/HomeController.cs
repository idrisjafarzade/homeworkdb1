using FirstHomework.DataAccessLayer;
using FirstHomework.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace FirstHomework.Controllers
{
    public class HomeController : Controller
    {

        private readonly AppDbContext _dbContext;

        public HomeController(AppDbContext dbContext)
        {
            _dbContext=dbContext;
        }

        public IActionResult Index()
        {
            var products=_dbContext.Products.Include(x=>x.Categorie).Include(x=>x.Type).ToList();
            return View(new HomeViewModels
            {
                Products = products
            }) ;

        }
        public IActionResult Categorie()
        {
            var categories=_dbContext.Categories.ToList();
            return View(new HomeViewModels
            {
                Categories = categories
            });
        }
        public IActionResult Type()
        {
            var types=_dbContext.Types.ToList();
            return View(new HomeViewModels
            {
                Types = types
            });
        }
    }
}
