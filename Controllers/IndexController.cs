using Microsoft.AspNetCore.Mvc;
using BugtrackerHF.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using BugtrackerHF.DAL.Data;
using BugtrackerHF.ViewModels;
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

            IUserViewModel user = _context.UserViewModel.FirstOrDefault(
                m => m.AuthZeroId == authZeroId);

            _logger.LogInformation("Current User Id: {currentUserId}",user.Id);

            IEnumerable<IssueViewModel> issueList =
                _context.IssueViewModel.Where(m => m.AssignedToUserId == user.Id);

            IUserAndIssueViewModel viewModel = new UserAndIssueViewModel(user, issueList);

            return View(viewModel);

        [Authorize]
        public IActionResult Dashboard()
        {
            var authZeroId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            var model = _context.UserViewModel.SingleOrDefault(
                m => m.AuthZeroId == authZeroId);
            
            if(model!=null)
                return View(model);

            return View();
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
