using Microsoft.AspNetCore.Mvc;
using BugtrackerHF.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using BugtrackerHF.DAL.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication;
using System.Security.Principal;
using BugtrackerHF.DAL.Repositories;

namespace BugtrackerHF.Controllers
{
    public class IndexController : Controller
    {
        private readonly ILogger<IndexController> _logger;
        private readonly IUserRepository _userRepository;

        public IndexController(
            ILogger<IndexController> logger, 
            IUserRepository userRepository)
        {
            _logger = logger;
            _userRepository = userRepository;
        }

        [Authorize]
        public async Task<IActionResult> Issues()
        {
            //explicit loading
            var user = await _userRepository.LoadIssuesByAuthZeroIdAsync(GetAuthZeroId());

            return View(user);
        }

        [Authorize]
        public async Task<IActionResult> Dashboard()
        {
            var user = await _userRepository.GetByAuthZeroIdAsync(GetAuthZeroId());

            var identity = HttpContext.User.Identity as ClaimsIdentity;
            identity.AddClaim(new Claim("UserViewModelId", user.Id.ToString()));

            return View(user);
        }


        /// <summary>
        /// Helper function to return authZeroId from the claim
        /// </summary>
        /// <returns>authZeroId from User.Claims => ClaimType == NameIdentifier</returns>
        private string GetAuthZeroId()
        {
            var authZeroId = User.Claims.FirstOrDefault(
                c => c.Type == ClaimTypes.NameIdentifier)?.Value;

            return authZeroId;
        }

        // var identity = HttpContext.User.Identity as ClaimsIdentity;
        // identity.AddClaim(new Claim("UserViewModelId", user.Id.ToString()));

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
