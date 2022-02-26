using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Areas.AdminPanel.Data;
using WebApplication3.DataAccsessLayer;
using WebApplication3.Models.Home;

namespace WebApplication3.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    [Authorize]
    public class ExpertController : Controller
    {
        private readonly AppDbContext _appDbContext;

        public ExpertController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<IActionResult> Index()
        {
            var expert = await _appDbContext.ExpertPersons.ToListAsync();
           
            return View(expert);
        }
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
                
            var expert= await _appDbContext.ExpertPersons.FindAsync(id);
            if(expert == null)
            {
                return BadRequest();
            }
            return View(expert);
        }
        
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ExpertPerson expert)
        {
            if (!ModelState.IsValid)
                return View();
            var expertPerson = _appDbContext.ExpertPersons.
                FirstOrDefault(x => x.Name.Trim().ToLower() == expert.Name.Trim().ToLower());
            if(expertPerson != null)
            {
                ModelState.AddModelError("Name", "Bu adda expert Var");
                return View();
            }

            if (!expert.Photo.isImage())
            {
                ModelState.AddModelError("Photo", $"{expert.Photo.FileName}-sekil deyil");
            }
            if (expert.Photo.AllowedSize(12))
            {
                ModelState.AddModelError("Photo", $"{expert.Photo.FileName}-sekil 2 mgbda boyuk ola bilmez");
                return View();
            }
            var fileName = await expert.Photo.GenerateFile(Constants.ImageFolderPath);

            var newExpertPerson = new ExpertPerson
            {
                ImgName = fileName,
                Name = expert.Name,
                Position=expert.Position
            };

            await _appDbContext.ExpertPersons.AddAsync(newExpertPerson);
            await _appDbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            var expert = await _appDbContext.ExpertPersons.FindAsync(id);
            if (expert == null)
            {
                return NotFound();
            }

            return View(expert);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteImg(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            var expert = await _appDbContext.ExpertPersons.FindAsync(id);
            if (expert == null)
                return NotFound();

            var path = Path.Combine(Constants.ImageFolderPath, expert.ImgName);
            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
            }
            _appDbContext.ExpertPersons.Remove(expert);
            await _appDbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
        public async Task<ActionResult> Update(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var expert = await _appDbContext.ExpertPersons.FindAsync(id);
            if (expert == null)
            {
                return BadRequest();
            }
            return View(expert);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Update(int? id, ExpertPerson expertPerson)
        {
            if (id == null)
                return NotFound();


            if (id != expertPerson.Id)
                return BadRequest();
            var expert = await _appDbContext.ExpertPersons.FindAsync(id);
            if (expert == null)
            {
                return BadRequest();
            }
            var exsitExpert = _appDbContext.ExpertPersons.
            FirstOrDefault(x => x.Name.Trim().ToLower() == expert.Name.Trim().ToLower());
            if (exsitExpert == null)
            {
                ModelState.AddModelError("Name", "Bu adda expert Var");
                return View();
            }

            if (!ModelState.IsValid)
                return View(expert);

            if (!expertPerson.Photo.isImage())
            {
                ModelState.AddModelError("Photos", $"{expertPerson.Photo.FileName}-sekil deyil");
                return View();
            }
            if (expertPerson.Photo.AllowedSize(1))
            {
                ModelState.AddModelError("Photos", $"{expertPerson.Photo.FileName}-2 mb boyuk ola bilmez");
                return View();
            }
            var path = Path.Combine(Constants.ImageFolderPath, expert.ImgName);
            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
            }
            var fileName = await expertPerson.Photo.GenerateFile(Constants.ImageFolderPath);
            expertPerson.ImgName = fileName;
            exsitExpert.Name = expertPerson.Name ;
            exsitExpert.Position = expertPerson.Position ;
            await _appDbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
