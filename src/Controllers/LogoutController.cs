using Microsoft.AspNetCore.Mvc;

namespace BugtrackerHF.Controllers
{
    public class LogoutController : Controller
    {
        public IActionResult LoggedOut()
        {
            return View();
        }
    }
}
