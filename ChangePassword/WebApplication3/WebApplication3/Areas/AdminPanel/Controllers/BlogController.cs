using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.DataAccsessLayer;
using WebApplication3.Models.Home;

namespace WebApplication3.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    [Authorize]
    public class BlogController : Controller
    {
        private readonly AppDbContext _appDbContext;
        public BlogController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IActionResult Index()
        {
            var blogItems = _appDbContext.BlogContents.ToList();

            return View(blogItems);
        }
        public async Task<IActionResult> Details(int? id)
        {
            if(id== null)
            {
                return BadRequest();
            }
            var blogItem = await _appDbContext.BlogContents.FindAsync(id);
            if(blogItem == null)
            {
                return NotFound();
            }
            return View(blogItem);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BlogContent blogContent)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var exsitBlog= await _appDbContext.BlogContents.AnyAsync(x=>x.Name.ToLower().Trim()==blogContent.Name.ToLower().Trim());
            if(exsitBlog)
            {
                ModelState.AddModelError("Name", "bu adda blog var");
            }
            _appDbContext.BlogContents.Add(blogContent);
            _appDbContext.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            var blogItem = await _appDbContext.BlogContents.FindAsync(id);
            if (blogItem == null)
            {
                return NotFound();
            }
            _appDbContext.BlogContents.Remove(blogItem);
            _appDbContext.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
