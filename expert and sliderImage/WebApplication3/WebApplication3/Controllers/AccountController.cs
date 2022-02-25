using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApplication3.Models.Home;
using WebApplication3.ViewModels;

namespace WebApplication3.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        public AccountController(UserManager<User> userManager,SignInManager<User>signInManager)
        {
            _signInManager = signInManager;
            _userManager=userManager;
        }
        public IActionResult Registr()
        {
            return View();
        }
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Registr(RegistrVM registrVM)
        //{
        //    if (!ModelState.IsValid)
        //        return View();

        //    var exsitUser=_userManager.FindByNameAsync(registrVM.UserName);
        //    if

        //}
    }
}
