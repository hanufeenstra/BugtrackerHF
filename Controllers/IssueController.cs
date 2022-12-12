using Microsoft.AspNetCore.Mvc;

namespace BugtrackerHF.Controllers
{
    public class IssueController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
