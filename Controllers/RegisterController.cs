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
    }
}
