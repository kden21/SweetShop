using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SweetShop.Domain.Entities;
using SweetShop.Domain.ViewModels.Account;
using SweetShop.Service.Interfaces;
using System.Security.Claims;

namespace SweetShop.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;
        private readonly UserManager<Microsoft.AspNetCore.Identity.IdentityUser> _userManager;
        private readonly SignInManager<Microsoft.AspNetCore.Identity.IdentityUser> _signInManager;
        private readonly RoleManager<Microsoft.AspNetCore.Identity.IdentityRole> _roleManager;

        public AccountController(RoleManager<Microsoft.AspNetCore.Identity.IdentityRole> roleManager, IAccountService accountService, UserManager<Microsoft.AspNetCore.Identity.IdentityUser> userManager, SignInManager<Microsoft.AspNetCore.Identity.IdentityUser> signInManager)
        {
            _accountService = accountService;
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        [HttpGet]
        public async Task<ActionResult> GetAccountsAsync()
        {
            var response = await _accountService.GetAccounts();
            if (response.StatusCode == Domain.Enums.StatusCode.OK)
                return View(response.Data.ToList());
            return RedirectToAction("Error", "Home");
        }

        [HttpGet]
        public async Task<ActionResult> GetAccount(int id)
        {
            var response = await _accountService.GetAccount(id);
            if (response.StatusCode == Domain.Enums.StatusCode.OK)
                return View(response.Data);
            return RedirectToAction("Error", "Home");
        }

        
        /*public AccountController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }*/
        

        [HttpGet]
        public IActionResult Register() => View();

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var response = await _accountService.Register(model);
                if(response.StatusCode == Domain.Enums.StatusCode.OK)
                {
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                       new ClaimsPrincipal(response.Data));
                    
                    return RedirectToAction("Login", "Account");
                }
                ModelState.AddModelError("", response.Description);
            }
            return View(model);
        }


        [HttpGet]
        public IActionResult Login(string? returnUrl = null)
        {
            return View(new LoginViewModel { ReturnUrl = returnUrl });
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {

            if (ModelState.IsValid)
             {
                 var response = await _accountService.Login(model);
                 if (response.StatusCode == Domain.Enums.StatusCode.OK)
                 {
                    var result = await _signInManager.PasswordSignInAsync(model.Name, model.Password, true, false);
                    return RedirectToAction("Index", "Home");
                 }
                 ModelState.AddModelError("",response.Description);
             }
             return View(model);
        }
        //public async Task<IActionResult> Logout() => View();
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }

    }

}
