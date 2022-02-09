using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using WebApplication3.DataAccsessLayer;

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
                var header = await _dbContext.Headers.SingleOrDefaultAsync();

                return View(header);
            }
    }
}
