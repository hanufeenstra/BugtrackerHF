using Microsoft.AspNetCore.Mvc;

namespace BugtrackerHF.Controllers
{
    public class CreateIssueController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
