using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Notespace.Web.Models.ViewModels;
using Notespace.Web.Models;
using System.Collections.Generic;
using System.Linq;

namespace Notespace.Web.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<ApplicationUser> userManager;
        private SignInManager<ApplicationUser> signInManager;
        
        public AccountController(UserManager<ApplicationUser> userMgr,
               SignInManager<ApplicationUser> signInMgr)
        {
            userManager = userMgr;
            signInManager = signInMgr;
        }

        public ViewResult Login(string returnUrl)
        {
            return View(new LoginModel
            {
                ReturnUrl = returnUrl
            });
        }

        public ViewResult Register(string returnUrl)
        {
            return View(new RegisterModel
            { 
                ReturnUrl = returnUrl
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel loginModel)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user =
                await userManager.FindByNameAsync(loginModel.Name);
                if (user != null)
                {
                    await signInManager.SignOutAsync();
                    if ((await signInManager.PasswordSignInAsync(user,
                    loginModel.Password, false, false)).Succeeded)
                    {
                        return Redirect(loginModel?.ReturnUrl ?? "/");
                    }
                }
            }
            ModelState.AddModelError("", "Invalid name or password");
            ViewBag.Error = "Invalid username or password";
            return View(loginModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterModel registerModel)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = new ApplicationUser { UserName = registerModel.Username, Email = registerModel.Email };
                var result = await userManager.CreateAsync(user, registerModel.Password);
                if (result.Succeeded)
                {
                    await signInManager.SignOutAsync();
                    if ((await signInManager.PasswordSignInAsync(registerModel.Username,
                    registerModel.Password, false, false)).Succeeded)
                    {
                        return Redirect(registerModel?.ReturnUrl ?? "/");
                    }
                }
                
                foreach (var error in result.Errors)
                {
                    return View(new RegisterModel { ErrorMessage = error.Description });
                }

            }

            foreach (var modelState in ViewData.ModelState.Values)
            {
                foreach (var error in modelState.Errors)
                {
                    return View(new RegisterModel { ErrorMessage = error.ErrorMessage });
                }
            }

            return View(new RegisterModel { ErrorMessage = "Unable to create user!" });
        }

        [Authorize]
        public async Task<RedirectResult> Logout(string returnUrl = "/")
        {
            await signInManager.SignOutAsync();
            return Redirect(returnUrl);
        }
    }
}
