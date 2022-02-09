using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.DataAccsessLayer;

namespace WebApplication3.Controllers
{
    public class ProductController : Controller
    {
        private readonly AppDbContext _appDbContext;
        private readonly int _productcounts;

        public ProductController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
            _productcounts = _appDbContext.products.Count();
        }

        public  IActionResult Index()
        {
            ViewBag.ProductCount = _productcounts;
            var product = _appDbContext.products.Include(x => x.Category).Take(4).ToList();
            return View( product);
        }
        public IActionResult Load(int skip)
        {
              if (skip > _productcounts)
            {
                return BadRequest();
            }
            var product = _appDbContext.products.Include(x => x.Category).Skip(skip).Take(4).ToList();

            return PartialView("_ProductsPartial", product);
        }
    }
}
