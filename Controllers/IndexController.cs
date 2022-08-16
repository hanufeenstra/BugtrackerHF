using Microsoft.AspNetCore.Mvc;
using BugtrackerHF.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using BugtrackerHF.DAL.Data;
using Microsoft.EntityFrameworkCore;

namespace BugtrackerHF.Controllers
{
    public class IndexController : Controller
    {
        private readonly BugtrackerHFContext _context;
        private readonly ILogger<IndexController> _logger;

        public IndexController(BugtrackerHFContext context, ILogger<IndexController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [Authorize]
        public IActionResult Issues()
        {
            var authZeroId = User.Claims.FirstOrDefault(
                c => c.Type == ClaimTypes.NameIdentifier)?.Value;

            var currentUserId = _context.UserViewModel.FirstOrDefault(
                m => m.AuthZeroId == authZeroId).Id;

            _logger.LogInformation("Current User Id: {currentUserId}",currentUserId);

            IEnumerable<IssueViewModel> issueList =
                _context.IssueViewModel.Where(m => m.AssignedToUserId == currentUserId);
            
            return View(issueList);
        }

        [Authorize]
        public IActionResult Dashboard()
        {
            var authZeroId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            var model = _context.UserViewModel.FirstOrDefault(m => m.AuthZeroId == authZeroId);
            return View(model);
        }

        //[HttpPost]
        //[Authorize]
        //[ValidateAntiForgeryToken]
        //public async Task CreateIssue([Bind(", ,")] IssueViewModel issueViewModel, int id)
        //{

        //    return
        //}

        
        [Authorize]
        public IActionResult Claims()
        {
            return RedirectToAction("Dashboard", "Index");
        }
    }



}
