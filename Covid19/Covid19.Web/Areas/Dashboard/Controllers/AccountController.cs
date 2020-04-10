using System.Threading.Tasks;
using AutoMapper;
using Covid19.Contracts;
using Covid19.Web.Areas.Dashboard.Models;
using Covid19.Web.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Covid19.Web.Areas.Dashboard.Controllers
{
    [Area("dashboard")]
    public class AccountController : DashboardController
    {
        private readonly UserManager<WebUser> userManager;
        private readonly SignInManager<WebUser> signInManager;
        private const string ADMINISTRATOR_ROLE = "Administrator";
        
        public AccountController(IRepositoryWrapper repository, IMapper mapper, ILoggerManager logger,
            SignInManager<WebUser> signInManager,UserManager<WebUser> userManager)
            : base(repository, mapper, logger)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public async Task<IActionResult> Login(UserLoginViewModel model, string returnUrl = null)
        {
            if (!ModelState.IsValid)
            {
                TempData["message"] = "Invalid request";
                return RedirectToAction("Index", "Home", new { area = "" });
            }


            var result = await this.signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure:false);
            if (result.Succeeded)
            {
                return RedirectToLocal(returnUrl);
            }
            else
            {
                TempData["message"] = "Invalid UserName or Password";
                return RedirectToAction("Index", "Home", new { area = ""});
            }

        }


        [HttpGet]
        public IActionResult ChangePassword()
        {
            var model = new ChangePasswordViewModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                TempData["message_pwd_change"] = "Invalid submission!";
                return RedirectToAction("Index", "Home",new { area = "" });
            }

            var user = await this.userManager.FindByEmailAsync(User.Identity.Name);
            if (user == null)
            {
                TempData["message_pwd_change"] = "User is not registered!";
                return RedirectToAction("Index", "Home",new { area = "" });
            }

            var result = await this.userManager.ChangePasswordAsync(user, model.CurrentPassword, model.Password);

            if (!result.Succeeded)
            {
                var msg = string.Empty;
                foreach(var error in result.Errors)
                {
                    msg += $"{error.Code} {error.Description}";
                }

                TempData["message_pwd_change"] = msg;
            }

            TempData["message_pwd_change"] = "Password successfully changed!";
            return RedirectToAction("Index", "Home");
        }


        //[HttpGet]
        //public IActionResult Register()
        //{
        //    return View();
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Register(UserRegistrationViewModel model)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return View(model);
        //    }

        //    var user = this.mapper.Map<WebUser>(model);

        //    var result = await this.userManager.CreateAsync(user, model.Password);
        //    if (!result.Succeeded)
        //    {
        //        foreach (var error in result.Errors)
        //        {
        //            ModelState.TryAddModelError(error.Code, error.Description);
        //        }
        //        return View(model);
        //    }


        //    await this.userManager.AddToRoleAsync(user, ADMINISTRATOR_ROLE);

        //    await this.signInManager.SignInAsync(user, isPersistent: false);
        //    return RedirectToAction(nameof(HomeController.Index));
        //}

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout(string returnUrl = null)
        {
            await this.signInManager.SignOutAsync();
            return Redirect("/");
        }


        private IActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
                return Redirect(returnUrl);
            else
                return RedirectToAction(nameof(HomeController.Index), "Home");

        }
    }
}