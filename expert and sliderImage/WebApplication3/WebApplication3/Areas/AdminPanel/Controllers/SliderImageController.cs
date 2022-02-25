using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Areas.AdminPanel.Data;
using WebApplication3.DataAccsessLayer;
using WebApplication3.Models.Home;

namespace WebApplication3.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class SliderImageController : Controller
    {
        private readonly AppDbContext _dbContext;

        public SliderImageController(AppDbContext dbContext)
        {
            _dbContext = dbContext;  
        }
        public IActionResult Index()
        {
            var sliderImage = _dbContext.SliderImgIcons.ToList();
            return View(sliderImage);
        }
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sliderImage = await _dbContext.SliderImgIcons.FindAsync(id);
            if (sliderImage == null)
            {
                return BadRequest();
            }
            return View(sliderImage);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create (SliderImgIcons sliderImg)
        {
            if (!ModelState.IsValid)
                return View();

            int maxCount = 10;
            int DataBaseCount = _dbContext.SliderImgIcons.Count();
            int downloadImgCount = sliderImg.Photos.Count();
            int Count = 0;
            Count= maxCount-DataBaseCount;

            if (maxCount<DataBaseCount + downloadImgCount)
            {
                ModelState.AddModelError("Photos", $" databasede {Count} bos yer var");
                return View();
            }

            foreach (var photo in sliderImg.Photos)
            {
                if (!photo.isImage())
                {
                    ModelState.AddModelError("Photos", $"{photo.FileName}-sekil deyil");
                    return View();
                }
                if (photo.AllowedSize(1))
                {
                    ModelState.AddModelError("Photos", $"{photo.FileName}-2 mb boyuk ola bilmez");
                    return View();
                }
                var fileName = await photo.GenerateFile(Constants.ImageFolderPath);

                var sliderImage = new SliderImgIcons { ImgName=fileName };
                await _dbContext.SliderImgIcons.AddAsync(sliderImage);
                await _dbContext.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }
        public async Task<ActionResult> Update(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sliderImage = await _dbContext.SliderImgIcons.FindAsync(id);
            if (sliderImage == null)
            {
                return BadRequest();
            }
            return View(sliderImage);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Update(int? id, SliderImgIcons sliderImage)
        {
            if (id == null)
                return NotFound();

            if (id != sliderImage.Id)
                return BadRequest();
            var image= await _dbContext.SliderImgIcons.FindAsync(id);
            if (image == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
                return View(image);

            if (!sliderImage.Photo.isImage())
            {
                ModelState.AddModelError("Photos", $"{sliderImage.Photo.FileName}-sekil deyil");
                return View();
            }
            if (sliderImage.Photo.AllowedSize(1))
            {
                ModelState.AddModelError("Photos", $"{sliderImage.Photo.FileName}-2 mb boyuk ola bilmez");
                return View();
            }
            var path=Path.Combine(Constants.ImageFolderPath, image.ImgName);
            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
            }
             var fileName=await sliderImage.Photo.GenerateFile(Constants.ImageFolderPath);
            image.ImgName=fileName;
            await _dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            var Slider = await _dbContext.SliderImgIcons.FindAsync(id);   
            if (Slider == null)
            {
                return NotFound();
            }

            return View(Slider);
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
            var SliderImg = await _dbContext.SliderImgIcons.FindAsync(id);
            if (SliderImg == null)
                return NotFound();

            var path = Path.Combine(Constants.ImageFolderPath, SliderImg.ImgName);
            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
            }
             _dbContext.SliderImgIcons.Remove(SliderImg);
            await _dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
