using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Mvc;
using BugtrackerHF.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Auth0.AspNetCore.Authentication;

namespace BugtrackerHF.Controllers
{
    public class LoginController : Controller
    {
        //private readonly BugtrackerHFContext _context;
        private readonly ILogger<LoginController> _logger;

        public LoginController(ILogger<LoginController> logger)
        {
            //_context = context;
            _logger = logger;
        }

        public async Task Login()
        {
            var authenticationProperties = new LoginAuthenticationPropertiesBuilder()
                .WithRedirectUri("/index/index")
                .Build();

            await HttpContext.ChallengeAsync(Auth0Constants.AuthenticationScheme, authenticationProperties);
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Login([Bind("Email,Password,Remember")] LoginViewModel loginViewModel)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var registerViewModel = await _context.RegisterViewModel
        //            .FirstOrDefaultAsync(m => m.Email == loginViewModel.Email);

        //        loginViewModel.VerifyHash(registerViewModel);

        //        if (registerViewModel.Hashed == loginViewModel.Hashed)
        //        {
        //            _logger.LogInformation("User: {Email} verified successfully", loginViewModel.Email);

        //            //await CreateSession(registerViewModel);

        //            _logger.LogInformation("Checked: {Checked}",loginViewModel.Remember);

        //            return RedirectToAction("Index", "Index");
        //        }
        //    }
        //    return View(loginViewModel);
        //}
        // https://github.com/auth0-samples/auth0-aspnetcore-mvc-samples/blob/master/Quickstart/Sample/Controllers/AccountController.cs
        // https://auth0.com/docs/quickstart/webapp/aspnet-core/01-login

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task Login(string returnUrl = "/index/index")
        {
            var authenticationProperties = new LoginAuthenticationPropertiesBuilder()
                .WithRedirectUri(returnUrl)
                .Build();

            await HttpContext.ChallengeAsync(Auth0Constants.AuthenticationScheme, authenticationProperties);
        }

        [Authorize]
        public async Task Logout()
        {
            var authenticationProperties = new LogoutAuthenticationPropertiesBuilder()
                // Indicate here where Auth0 should redirect the user after a logout.
                // Note that the resulting absolute Uri must be whitelisted in 
                .WithRedirectUri(Url.Action("Login", "Login"))
                .Build();

            await HttpContext.SignOutAsync(Auth0Constants.AuthenticationScheme, authenticationProperties);
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        }

        //[Authorize]
        //public IActionResult Profile()
        //{
        //    return View(new UserProfileViewModel()
        //    {
        //        Name = User.Identity.Name,
        //        EmailAddress = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value,
        //        ProfileImage = User.Claims.FirstOrDefault(c => c.Type == "picture")?.Value
        //    });
        //}


        // <summary>
        // This is just a helper action to enable you to easily see all claims related to a user. It helps when debugging your
        // application to see the in claims populated from the Auth0 ID Token
        // </summary>
        // <returns></returns>

        //[Authorize]
        //public IActionResult Claims()
        //{
        //    return View();
        //}

        //public IActionResult AccessDenied()
        //{
        //    return View();
        //}
    }
}
