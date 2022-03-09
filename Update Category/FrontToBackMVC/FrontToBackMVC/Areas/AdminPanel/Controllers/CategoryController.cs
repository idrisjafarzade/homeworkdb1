using FrontToBackMVC.DataAccsessLayer;
using FrontToBackMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Areas.AdminPanel.Data;

namespace FrontToBackMVC.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class CategoryController : Controller
    {
        private readonly AppDbContext _appDbContext;

        public CategoryController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<IActionResult> Index()
        {
            var category = await _appDbContext.Categories.Where(x => x.IsDeleted == false).ToListAsync();

            return View(category);
        }
        public async Task<IActionResult> Create()
        {
            var categories = await _appDbContext.Categories.Where(y => y.IsDeleted == false).Where(x => x.IsMain == true).ToListAsync();
            ViewBag.ParentCategories = categories;
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Category category, int parentCategoryId)
        {
            var categories = await _appDbContext.Categories.Where(x => x.IsDeleted == false && x.IsMain).ToListAsync();
            ViewBag.ParentCategories = categories;
            if (!ModelState.IsValid)
                return View();

            if (category.IsMain == true)
            {
                if (category.Photo == null)
                {
                    ModelState.AddModelError("", "Sekil elave edin");
                    return View();
                }
                if (!category.Photo.isImage())
                {
                    ModelState.AddModelError("", "yukledyiniz sekil deyil");
                    return View();
                }
                if (category.Photo.AllowedSize(2))
                {
                    ModelState.AddModelError("", "yukledyiniz sekil 2mgb dan cox ola bilmez");
                    return View();
                }
                var fileName = await category.Photo.GenerateFile(Constants.ImageFolderPath);
                category.Image = fileName;
            }
            else
            {
                if (parentCategoryId == 0)
                {
                    ModelState.AddModelError("", "duzgun kateqoya secin");
                }
                var existParentCategory = await _appDbContext.Categories
                   .Include(x => x.Children.Where(y => y.IsDeleted == false))
                   .FirstOrDefaultAsync(x => x.IsDeleted == false && x.Id == parentCategoryId);
                if (existParentCategory == null)
                {
                    return NotFound();
                }
                var exsitChildCategory = existParentCategory.Children.Any
                    (x => x.Name.ToLower().Trim() == category.Name.ToLower().Trim());
                if (exsitChildCategory)
                {
                    ModelState.AddModelError("", "bu adda kategory var");
                    return View();
                }
                category.Parent = existParentCategory;

            }
            category.IsDeleted = false;
            await _appDbContext.Categories.AddAsync(category);
            await _appDbContext.SaveChangesAsync();


            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Update(int? id)
        {
            var categories = await _appDbContext.Categories.Where(x => x.IsDeleted == false && x.IsMain).ToListAsync();
            ViewBag.ParentCategoriesUpdate = categories;
            if (id == null)
            {
                return BadRequest();
            }
            var exsistCategory = await _appDbContext.Categories.Include(x => x.Parent).Include(x => x.Children.Where(x => x.IsDeleted == false)).FirstOrDefaultAsync(x => x.Id == id);
            if (exsistCategory == null)
            {
                return NotFound();
            }

            return View(exsistCategory);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(Category category, int? Id, int parentCategoryId)
        {
            var categories = await _appDbContext.Categories.Where(x => x.IsDeleted == false && x.IsMain).ToListAsync();
            ViewBag.ParentCategoriesUpdate = categories;

            var exsistCategory = await _appDbContext.Categories.Include(x => x.Parent).
                Include(x => x.Children.Where(x => x.IsDeleted == false)).FirstOrDefaultAsync(x => x.Id == Id);

             if(Id== null)
                return NotFound();


            if (!ModelState.IsValid)
            {
                return View(exsistCategory);
            }


            if (exsistCategory.IsMain == true)
            {
                if (category.Photo != null)
                {
                    if (!category.Photo.isImage())
                    {
                        ModelState.AddModelError("", "yukledyiniz sekil deyil");
                        return View(exsistCategory);
                    }
                    if (category.Photo.AllowedSize(2))
                    {
                        ModelState.AddModelError("", "yukledyiniz sekil 2mgb dan cox ola bilmez");
                        return View(exsistCategory);
                    }
                    var path = Path.Combine(Constants.ImageFolderPath, exsistCategory.Image);
                    if (System.IO.File.Exists(path))
                    {
                        System.IO.File.Delete(path);
                    }
                    var fileName = await category.Photo.GenerateFile(Constants.ImageFolderPath);
                    exsistCategory.Image = fileName;
                }
                
               
                var categoryName = await _appDbContext.Categories.FirstOrDefaultAsync(x => x.Name.ToLower().Trim() == category.Name.ToLower().Trim());
                if (categoryName!=null)
                {
                    ModelState.AddModelError("Name", "bu adda model var");
                    return View(exsistCategory);
                }
            }
            else 
            {
                if (parentCategoryId == 0)
                {
                    ModelState.AddModelError("", "duzgun kateqoya secin");
                }
                var existParentCategory = await _appDbContext.Categories
                   .Include(x => x.Children.Where(y => y.IsDeleted == false))
                   .FirstOrDefaultAsync(x => x.IsDeleted == false && x.Id == parentCategoryId);
                if (existParentCategory == null)
                {
                    return NotFound();
                }
                var exsitChildCategory = existParentCategory.Children.Any
                    (x => x.Name.ToLower().Trim() == category.Name.ToLower().Trim());
                if (exsitChildCategory)
                {
                    ModelState.AddModelError("", "bu adda kategory var");
                    return View(exsistCategory);
                }
                exsistCategory.Parent = existParentCategory;

            }
            exsistCategory.Name=category.Name;
            exsistCategory.IsDeleted = false;
            await _appDbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Detail(int? Id)
        {
            if (Id == null)
            {
                return BadRequest();
            }
            var exsistCategory = await _appDbContext.Categories.
                Include(x => x.Parent).Include(x => x.Children.
                Where(x => x.IsDeleted == false)).FirstOrDefaultAsync(x => x.Id == Id);
            if (exsistCategory == null)
            {
                return NotFound();
            }

            return View(exsistCategory);
        }
    }
}
