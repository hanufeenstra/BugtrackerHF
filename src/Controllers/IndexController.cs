using System.Security.Claims;
using BugtrackerHF.DAL.Repositories;
using BugtrackerHF.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BugtrackerHF.Controllers
{
    public class IndexController : Controller
    {
        private readonly ILogger<IndexController> _logger;
        private readonly IUserRepository _userRepository;
        private readonly IIssueService _issueService;

        public IndexController(
            ILogger<IndexController> logger,
            IUserRepository userRepository,
            IIssueService issueService)
        {
            _logger = logger;
            _userRepository = userRepository;
            _issueService = issueService;
        }

        [Authorize]
        public async Task<IActionResult> MyIssues()
        {
            var viewModel = await _issueService.GetViewIssueViewModel(GetAuthZeroId());

            return View(viewModel);
        }

        [Authorize]
        public async Task<IActionResult> Dashboard()
        {
            var user = await _userRepository.GetByAuthZeroIdAsync(GetAuthZeroId());

            return View(user);
        }


        private string GetAuthZeroId()
        {
            var authZeroId = User.Claims.FirstOrDefault(
                c => c.Type == ClaimTypes.NameIdentifier)?.Value;

            return authZeroId;
        }


        // var identity = HttpContext.User.Identity as ClaimsIdentity;
        // identity.AddClaim(new Claim("UserViewModelId", user.Id.ToString()));

    }
}
