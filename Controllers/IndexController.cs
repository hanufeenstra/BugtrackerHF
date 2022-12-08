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

            //explicit loading
            var user = _context.UserViewModel.Single(u => u.AuthZeroId == authZeroId);

            _context.Entry(user)
                .Collection(u => u.IssueList)
                .Load();

            return View(user);
        }

        [Authorize]
        public IActionResult Dashboard()
        {
            var authZeroId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            var user = _context.UserViewModel.SingleOrDefault(
                m => m.AuthZeroId == authZeroId);

            return View(user);
        }

        //[HttpPost]
        //[Authorize]
        //[ValidateAntiForgeryToken]
        //public async Task CreateIssue([Bind(", ,")] IssueViewModel issueViewModel, int id)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.IssueViewModel.Add(issueViewModel);
        //        await _context.SaveChangesAsync();
        //    }

        //    return
        //}

        
        [Authorize]
        public IActionResult Claims()
        {
            return RedirectToAction("Dashboard", "Index");
        }
    }



}
