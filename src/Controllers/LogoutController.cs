using Microsoft.AspNetCore.Mvc;

namespace BugtrackerHF.src.Controllers
{
    public class LogoutController : Controller
    {
        public IActionResult LoggedOut()
        {
            return View();
        }
    }
}
