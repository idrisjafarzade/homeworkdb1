using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.DataAccsessLayer;
using WebApplication3.Models.Home;

namespace WebApplication3.Areas.AdminPanel.Controllers
{
        [Area("AdminPanel")]
    public class ProductController : Controller
    {
        private readonly AppDbContext _appDbContext;

        public ProductController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IActionResult Index(int page=1)
        {

            ViewBag.TotalPage = Math.Ceiling((decimal)_appDbContext.products.Count() / 4);
            ViewBag.CurrentPage = page;

            var product = _appDbContext.products.Include(x => x.Category).Skip((page-1)*4).Take(4).ToList();
           
            return View(product);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            var product = await _appDbContext.products.Include(x => x.Category).FirstOrDefaultAsync(x => x.Id == id);
            if (product == null)
            {
                return BadRequest();
            }
            return View(product);
        }
        public IActionResult create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> create(Product product)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var exsitPrduct = await _appDbContext.products.AnyAsync(x => x.Name.ToLower().Trim() == product.Name.ToLower().Trim());
            if (exsitPrduct)
            {
                ModelState.AddModelError("Name", "bu adda mehsul var");
                return View();
            }
            await _appDbContext.AddAsync(product);
            await _appDbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            var product = await _appDbContext.products.FirstOrDefaultAsync(x => x.Id == id);
            if (product == null)
            {
                return BadRequest();
            }
            _appDbContext.products.Remove(product);
            _appDbContext.SaveChanges();
             

            return RedirectToAction(nameof(Index));
        }

    }
}
