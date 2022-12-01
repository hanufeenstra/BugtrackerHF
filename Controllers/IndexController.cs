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
            
                
            var user = _context.UserViewModel.FirstOrDefault(
                m => m.AuthZeroId == authZeroId);

            _logger.LogInformation("Current User Id: {currentUserId}", user.Id);

            IEnumerable<IssueViewModel> issueList = _context.IssueViewModel
                .Where(m => m.AssignedToUserId == user.Id);


            user.IssueList = issueList;
            user.UserNickname = User.Identity.Name;


            return View(user);
        }

        [Authorize]
        public IActionResult Dashboard()
        {
            var authZeroId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            var user = _context.UserViewModel.SingleOrDefault(
                m => m.AuthZeroId == authZeroId);

            //user.UserEmail = User.Identity.Name;
            //user.UserNickname = User.Claims.FirstOrDefault(c => c.Value == ClaimTypes.GivenName)?.Value;

            return View(user);
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
