using Microsoft.AspNetCore.Mvc;
using System.Linq;
using WebApplication3.DataAccsessLayer;
using WebApplication3.ViewModels;

namespace WebApplication3.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _appDbContext;

        public HomeController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IActionResult Index()
        {
            var aboutImg=_appDbContext.AboutImgs.SingleOrDefault();
            var aboutText=_appDbContext.AboutTexts.SingleOrDefault();
            var expertTitle=_appDbContext.ExpertTitle.SingleOrDefault();
            var expertPerson = _appDbContext.ExpertPersons.ToList();
            var background=_appDbContext.Backgrounds.SingleOrDefault();
            var blogContent = _appDbContext.BlogContents.ToList();
            var blogTitle=_appDbContext.BlogTitles.SingleOrDefault();
            var personAbout = _appDbContext.PersonsAbouts.ToList();
            var sliderImgIcon=_appDbContext.SliderImgIcons.ToList();
            
            return View(new HomeVM
            {
                AboutImg = aboutImg,
                AboutText = aboutText,
                ExpertTitle=expertTitle,
                ExpertPerson=expertPerson,
                Backgrounds=background,
                BlogTitles=blogTitle,
                BlogContents=blogContent,
                PersonsAbouts= personAbout,
                SliderImgIcons=sliderImgIcon

            });
        }
    }
}
