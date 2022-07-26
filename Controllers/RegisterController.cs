using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BugtrackerHF.Models;
using BugtrackerHF.Data;

namespace BugtrackerHF.Controllers
{
    public class RegisterController : Controller
    {
        private readonly BootstrapMVCContext _context;
        private readonly ILogger<RegisterController> _logger;

        public RegisterController(BootstrapMVCContext context, ILogger<RegisterController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // GET: Authentication/Register
        public ActionResult Register()
        {
            return View();
        }

        // POST: Authentication/Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register([Bind("FirstName,LastName,Email,Password,ConfirmPassword")] RegisterViewModel registerViewModel)
        {
            if (ModelState.IsValid)
            {
                // check email for existence in DB
                //var userEmail = await _context.RegisterViewModel
                //    .FirstOrDefaultAsync(m => m.Email == registerViewModel.Email);

                //if (userEmail.Email == registerViewModel.Email)
                //{
                //    return
                //}

                _context.Add(registerViewModel);
                registerViewModel.HashPassword();
                await _context.SaveChangesAsync();

                return RedirectToAction("Login", "Login");
            }
            return View(registerViewModel);
        }
    }
}
