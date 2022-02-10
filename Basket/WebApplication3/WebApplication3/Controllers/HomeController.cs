using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.DataAccsessLayer;
using WebApplication3.ViewModels;
using WebApplication3.Models.Home;
using Newtonsoft.Json;

namespace WebApplication3.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _appDbContext;

        public HomeController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public  IActionResult Index()
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
            var category = _appDbContext.categories.ToList();
            var product=_appDbContext.products.Include(x => x.Category).ToList();

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
                SliderImgIcons=sliderImgIcon,
                Products=  product,
                Categories=  category
            });
        }
        public async Task< IActionResult> Basket()
        {
            var basket = Request.Cookies["Basket"];
            if (string.IsNullOrEmpty(basket))
            {
                return Content("empty");
            }
            var basketViewModels= JsonConvert.DeserializeObject<List<BasketVM>>(basket);
            var newBasket=new List<BasketVM>();
            double totalAmout=0;
            foreach (var basketViewModel in basketViewModels)
            {
                var product = await _appDbContext.products.FindAsync(basketViewModel.Id);
                if(product == null)
                continue;
                newBasket.Add(new BasketVM
                {
                    Id = product.Id,
                    Name = product.Name,
                    Price = product.Price,
                    Image = product.Image,
                    Count = basketViewModel.Count,
                    TotalPrice= basketViewModel.Count* product.Price

                });
                totalAmout+=basketViewModel.Count*product.Price;
                ViewBag.TotalAmount = totalAmout;
            }
         
            var baskets = JsonConvert.SerializeObject(newBasket);
            Response.Cookies.Append("basket", baskets);
            


            return View(newBasket);
        }

        public IActionResult Delete(int? id)
        {
            var basket = Request.Cookies["Basket"];
            if (string.IsNullOrEmpty(basket))
            {
                return Content("Empty");
            }
            var basketViewModels = JsonConvert.DeserializeObject<List<BasketVM>>(basket);
            var isExist = basketViewModels.FirstOrDefault(x => x.Id == id);
            if (isExist != null)
            {
                basketViewModels.Remove(isExist);
            }
            var baskets = JsonConvert.SerializeObject(basketViewModels);
            Response.Cookies.Append("Basket", baskets);
            return RedirectToAction(nameof(basket));

        }

        public IActionResult AddCount(int? Id)
        {
            var basket = Request.Cookies["Basket"];
            if (string.IsNullOrEmpty(basket))
            {
                return Content("empty");
            }
            var basketViewModels = JsonConvert.DeserializeObject<List<BasketVM>>(basket);
            var isExist = basketViewModels.FirstOrDefault(x => x.Id == Id).Count++;

            var baskets = JsonConvert.SerializeObject(basketViewModels);
            Response.Cookies.Append("Basket", baskets);

            return RedirectToAction(nameof(basket));
        }
        public IActionResult DeleteCount(int? Id)
        {
            var basket = Request.Cookies["Basket"];
            if (string.IsNullOrEmpty(basket))
            {
                return Content("Emptyy");
            }
            var basketViewModels = JsonConvert.DeserializeObject<List<BasketVM>>(basket);
            var isExist = basketViewModels.FirstOrDefault(x => x.Id == Id);
            if (isExist.Count == 1)
            {
                basketViewModels.Remove(isExist);
            }
             isExist.Count--;

           
            
            var baskets = JsonConvert.SerializeObject(basketViewModels);
            Response.Cookies.Append("Basket", baskets);

            return RedirectToAction(nameof(basket));
        }

        public async Task<IActionResult> AddToBasket(int? Id)
        {
            if (Id == null)
                return BadRequest();

            var Product =await _appDbContext.products.FindAsync(Id);
            if (Product == null)
                return NotFound();

            List<BasketVM> BasketViewModels;
            var exisbasket = Request.Cookies["basket"];
            if (string.IsNullOrEmpty(exisbasket))
            {
                 BasketViewModels = new List<BasketVM>();
            }
            else
            {
                BasketViewModels = JsonConvert.DeserializeObject<List<BasketVM>>(exisbasket);
            }
            var exsitBasketVM= BasketViewModels.FirstOrDefault(x=>x.Id == Id);
            if (exsitBasketVM == null)
            {
                exsitBasketVM = new BasketVM
                {

                    Id = Product.Id,
                };
                BasketViewModels.Add(exsitBasketVM);
            }
            else
            {
                exsitBasketVM.Count++;
            }

            var basket=JsonConvert.SerializeObject(BasketViewModels);
            Response.Cookies.Append("basket", basket);

            return RedirectToAction(nameof(Index));
        }
    }
}
