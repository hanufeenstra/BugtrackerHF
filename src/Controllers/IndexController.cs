using System.Security.Claims;
using BugtrackerHF.DAL.Repositories;
using BugtrackerHF.Models.ViewModels;
using BugtrackerHF.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BugtrackerHF.Controllers
{
    public class IndexController : Controller
    {
        private readonly ILogger<IndexController> _logger;
        private readonly IIssueService _issueService;
        private readonly IDashboardService _dashboardService;

        public IndexController(
            ILogger<IndexController> logger,
            IIssueService issueService,
            IDashboardService dashboardService)
        {
            _logger = logger;
            _issueService = issueService;
            _dashboardService = dashboardService;
        }

        [Authorize]
        public async Task<IActionResult> MyIssues()
        {
            return View(await _issueService.GetViewIssueViewModel(GetUserAuthZeroId()));
        }

        [Authorize]
        public async Task<IActionResult> Dashboard()
        {
            return View(await _dashboardService.GetDashboardViewModel(GetUserAuthZeroId()));
        }

        /// <summary>
        /// A helper function to return the NameIdentifier string found in the User Claim
        /// </summary>
        /// <returns>nullable string: ClaimTypes.NameIdentifier</returns>
        private string GetUserAuthZeroId()
        {
            return User.Claims.FirstOrDefault(
                c => c.Type == ClaimTypes.NameIdentifier)?.Value!;
        }


        // var identity = HttpContext.User.Identity as ClaimsIdentity;
        // identity.AddClaim(new Claim("UserViewModelId", user.Id.ToString()));

    }
}
