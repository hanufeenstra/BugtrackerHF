using Microsoft.AspNetCore.Mvc;

namespace BugtrackerHF.Controllers
{
    public class IndexController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
