using Microsoft.AspNetCore.Mvc;

namespace BugtrackerHF.Controllers
{
    public class ForgotPasswordController : Controller
    {
        public ActionResult ForgotPassword()
        {
            return View();
        }
    }
}
