using BugtrackerHF.DAL.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BugtrackerHF.Models;

namespace BugtrackerHF.Controllers
{
    public class RegisterController : Controller
    {
        private readonly BugtrackerHFContext _context;
        private readonly ILogger<RegisterController> _logger;

        public RegisterController(ILogger<RegisterController> logger, BugtrackerHFContext context)
        {
            _context = context;
            _logger = logger;
        }

        // POST: Register
        [HttpPost]
        public async Task<IActionResult> Register(UserViewModel userViewModel)
        {
            _logger.LogInformation("API Received: {0}, {1}, {2}", userViewModel.UserNickname, userViewModel.AuthZeroId, userViewModel.UserEmail);
            
            if (ModelState.IsValid)
            {
                _context.Add(userViewModel);
                await _context.SaveChangesAsync();
                _logger.LogInformation("New user: {0} added to database", userViewModel.UserNickname);

                return Ok();
            }
            return BadRequest("");
        }
    }
}
