using Auth0.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BugtrackerHF.src.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILogger<LoginController> _logger;

        public LoginController(ILogger<LoginController> logger)
        {
            _logger = logger;
        }

        public async Task Login()
        {
            var authenticationProperties = new LoginAuthenticationPropertiesBuilder()
                .WithRedirectUri(Url.Action("Dashboard", "Index"))
                .Build();

            await HttpContext.ChallengeAsync(Auth0Constants.AuthenticationScheme, authenticationProperties);
        }

        [Authorize]
        public async Task Logout()
        {
            var authenticationProperties = new LogoutAuthenticationPropertiesBuilder()
                .WithRedirectUri(Url.Action("LoggedOut", "Logout"))
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
