using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Areas.AdminPanel.ViewModels;
using WebApplication3.DataAccsessLayer;
using WebApplication3.Models.Home;

namespace WebApplication3.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    //[Authorize]
    public class UserController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<User> _signInManager;
        private readonly AppDbContext _dbContext;
        public UserController(RoleManager<IdentityRole> roleManager,UserManager<User> userManager, SignInManager<User> signInManager, AppDbContext dbContext)
        {
            _dbContext = dbContext;
            _signInManager=signInManager;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<IActionResult> Index()
        {
            var users = await _userManager.Users.ToListAsync();
            List<UserVM> userVMs = new List<UserVM>();
            foreach(var user in users)
            {
                UserVM userVM = new UserVM
                {
                    Id = user.Id,
                    UserName = user.UserName,
                    Email = user.Email,
                    Role = (await _userManager.GetRolesAsync(user)).FirstOrDefault(),
                    IsActive = user.IsActive,

                };
                userVMs.Add(userVM);
            }
            return View(userVMs);
        }

        public async Task<IActionResult> Status(string Id)
        {
            if(Id== null)
             return BadRequest();

            var existUser=await _userManager.Users.FirstOrDefaultAsync(x => x.Id == Id);
            if (existUser == null) 
            return View(existUser);

            if (existUser.IsActive)
            {
                existUser.IsActive = false;
            }
            else
            {
                existUser.IsActive = true;
            }

              await _userManager.UpdateAsync(existUser);
             await _signInManager.RefreshSignInAsync(existUser);
             return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> ChangeRole(string Id)
        {
            if (Id == null)
                return BadRequest();
            var user=await _userManager.FindByIdAsync(Id);
            if (user == null)
                return NotFound();

            RoleUserVM roleUserVM = new RoleUserVM
            {
                Roles = await _roleManager.Roles.ToListAsync(),
                UserName=user.UserName
            };


            return View(roleUserVM);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangeRole(string Id, string role)
        {
            if (Id == null)
                return BadRequest();
            var user = await _userManager.FindByIdAsync(Id);
            if (user == null)
                return NotFound();

            var oldRole = (await _userManager.GetRolesAsync(user)).FirstOrDefault();

            if (oldRole== null)
            {
               return View();
                
            }

            await _userManager.RemoveFromRoleAsync(user, oldRole);

            if (role == null)
            {
                return View();
            }
            await _userManager.AddToRoleAsync(user, role);
            await _userManager.UpdateAsync(user);


             return RedirectToAction(nameof(Index));
         }
    }
}
