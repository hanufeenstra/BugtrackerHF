using BugtrackerHF.DAL.Repositories;
using BugtrackerHF.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BugtrackerHF.Controllers
{
    public class IssueController : Controller
    {
        private readonly IIssueRepository _issueRepository;
        private readonly ILogger<IssueViewModel> _logger;

        public IssueController(ILogger<IssueViewModel> logger, IIssueRepository issueRepository)
        {
            _logger = logger;
            _issueRepository = issueRepository;
        }

        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromForm] IssueViewModel issue)
        {
            issue.LastUpdateDate = DateTime.Now;
            issue.AddInitMessage(int.Parse(User.Claims.FirstOrDefault(c => c.Type == "UserViewModelId")?.Value));
            var newIssue = await _issueRepository.AddAsync(issue);

            return RedirectToAction("View","Issue", newIssue.Id);
        }

        [Authorize]
        public async Task<IActionResult> View(int id)
        {
            var issue = await _issueRepository.GetByIdAsync(id);

            if (issue == null)
                RedirectToAction("","");

            return View(issue);
        }
    }
}
