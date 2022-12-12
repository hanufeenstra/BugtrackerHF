using BugtrackerHF.DAL.Repositories;
using BugtrackerHF.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BugtrackerHF.Controllers
{
    public class CreateIssueController : Controller
    {
        private readonly IIssueRepository _repository;
        private readonly ILogger<IssueViewModel> _logger;

        public CreateIssueController(ILogger<IssueViewModel> logger, IIssueRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        [Authorize]
        public IActionResult CreateIssue()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateIssue([Bind("")] IssueViewModel issue)
        {

            var newIssue = await _repository.AddAsync(issue);

            return RedirectToAction("","",newIssue.Id);
        }
    }
}
