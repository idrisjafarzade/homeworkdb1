using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication3.DataAccsessLayer;
using WebApplication3.ViewModels;

namespace WebApplication3.ViewComponents
{
    public class HeaderViewComponent:ViewComponent
    {
            private readonly AppDbContext _dbContext;

            public HeaderViewComponent(AppDbContext dbContext)
            {
                _dbContext = dbContext;
            }

            public async Task<IViewComponentResult> InvokeAsync()
            {
                 var count = 0;
                 var basket = Request.Cookies["basket"];
                 if (!string.IsNullOrEmpty(basket))
                 {
                   var products = JsonConvert.DeserializeObject<List<BasketVM>>(basket);
                     count = products.Count;
                    
                 }
                 ViewBag.BasketCount = count;
                    var totals = JsonConvert.DeserializeObject<List<BasketVM>>(basket);
                    double totalAmount = 0;
                    foreach (var item in totals)
                    {
                        totalAmount += item.Price * item.Count;

                    }
                    ViewBag.BaskettotalAmount = totalAmount;



            var header = await _dbContext.Headers.SingleOrDefaultAsync();

                return View(header);
            }
    }
}
