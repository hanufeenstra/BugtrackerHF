using System.Security.Claims;
using BugtrackerHF.Services;
using Microsoft.AspNetCore.Mvc;

namespace BugtrackerHF.Controllers
{
    public class ProfileController : Controller
    {
        private readonly IUserService _userService;

        public ProfileController(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<IActionResult> Profile()
        {
            return View(await _userService.GetProfileViewModel(GetUserAuthZeroId()));
        }

        /// <summary>
        /// A helper function to return the NameIdentifier string found in the User Claim
        /// </summary>
        /// <returns>nullable string: ClaimTypes.NameIdentifier</returns>
        private string GetUserAuthZeroId()
        {
            return User.Claims.FirstOrDefault(
                c => c.Type == ClaimTypes.NameIdentifier)?.Value!;
        }
    }
}
