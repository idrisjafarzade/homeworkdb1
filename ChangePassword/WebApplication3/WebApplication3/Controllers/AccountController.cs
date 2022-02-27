using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Net;
using System.Net.Mail;
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
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegistrVM registrVM)

        {
            if (!ModelState.IsValid)
                return View();

            var exsitUser =await _userManager.FindByNameAsync(registrVM.UserName);
            if (exsitUser != null)
            {
                ModelState.AddModelError("UserName", "bu adda username var qaqa");
                return View();
            }
                    
            var user = new User
            {
                FullName = registrVM.FullName,
                UserName = registrVM.UserName,
                Email = registrVM.Email
            };
            var resultUser= await _userManager.CreateAsync(user,registrVM.Password);
            if (!resultUser.Succeeded)
            {
                foreach (var error in resultUser.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

                return View();
            }
            await _signInManager.SignInAsync(user, false);

            return RedirectToAction("Index", "Home");
        }
   
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction("Index", "Home");
        }
        
        public  IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public  async Task<IActionResult> Login(LoginVM loginVM)
        {
            if (!ModelState.IsValid)
                return View();

            var exsitUser= await _userManager.FindByNameAsync(loginVM.UserName);
            if (exsitUser == null)
            {
                ModelState.AddModelError("UserName", "bu adda user yoxdur");
                return View();
            }
            var result = await _signInManager.PasswordSignInAsync(exsitUser, loginVM.Password, loginVM.RememberMe, true);
            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "sehvliy var");
                return View();         
            }
          
             return RedirectToAction("Index", "Home");
        }
         
        public IActionResult Reset()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Reset(ResetPassword resetPassword)
        {
            if (!ModelState.IsValid)
                return View();
            
            var existEmail =await _userManager.FindByEmailAsync(resetPassword.Email);
            if(existEmail == null)
            {
                ModelState.AddModelError("Email", "bele Email yoxdu");
                return View();
            }
            string token=await _userManager.GenerateEmailConfirmationTokenAsync(existEmail);
            string link = Url.Action(nameof(ChangePassword), "Account", new { email = resetPassword.Email, token }, Request.Scheme, Request.Host.ToString());
            TempData["link1"] = link;
            MailMessage msg=new MailMessage();
            msg.From = new MailAddress("codep320@gmail.com", "idrisAlisimran");
            msg.To.Add(resetPassword.Email);
            string body=string.Empty;
            using (StreamReader reader = new StreamReader("wwwroot/template/ResetPassword.html")) 
            {
                body= reader.ReadToEnd();
            }
            msg.Body = body.Replace("{{link}}", link);
            msg.Subject = "Verify";
            msg.IsBodyHtml = true;
            SmtpClient smtp=new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.EnableSsl = true;
            smtp.Credentials = new NetworkCredential("codep320@gmail.com", "codeacademyp320");
            smtp.Send(msg);
            return RedirectToAction("index", "home");
        }
        public IActionResult ChangePassword()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangePassword(ResetPassword resetPassword,ChangePassword changePassword)
        {

            if (!ModelState.IsValid)
                return View();
            var existEmail = await _userManager.FindByEmailAsync(resetPassword.Email);
            if (existEmail == null)
            {
                ModelState.AddModelError("Email", "bele Email yoxdu");
                return View();
            }
            string token2 = await _userManager.GenerateEmailConfirmationTokenAsync(existEmail);
            string link2 = Url.Action(nameof(ChangePassword), "Account", new { email = resetPassword.Email, token2 }, Request.Scheme, Request.Host.ToString());
            TempData["link2"]=link2;
            var existUser = await _userManager.FindByEmailAsync(resetPassword.Email);
            if(existUser == null)
            {
                return Content("exsit is Null");
            }
            var token = await _userManager.GeneratePasswordResetTokenAsync(existUser);

              await _userManager.ResetPasswordAsync(existUser,token,changePassword.NewPassword);

            await _signInManager.RefreshSignInAsync(existUser);
            return RedirectToAction("index", "home");
        }
        public IActionResult ChangeOldPassword()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangeOldPassword(ChangeOldPassword changeOldPassword)
        {
            if (!ModelState.IsValid)
                return View();

             var user=await _userManager.GetUserAsync(User);

            var oldPassword = await _userManager.ChangePasswordAsync(user, changeOldPassword.OldPassword, changeOldPassword.NewPassword);
            if (!oldPassword.Succeeded)
            {
                ModelState.AddModelError("OldPassword", "sehvliy var");
                return View();
            }
            await _signInManager.RefreshSignInAsync(user);
            return RedirectToAction(nameof(Login));
        }
    }
}
