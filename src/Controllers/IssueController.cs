using BugtrackerHF.Models;
using BugtrackerHF.DAL.Repositories;
using BugtrackerHF.DAL.UnitOfWork;
using BugtrackerHF.Models.ViewModels;
using BugtrackerHF.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BugtrackerHF.Controllers
{
    public class IssueController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IIssueService _issueService;
        private readonly ILogger<IssueModel> _logger;

        public IssueController(
            ILogger<IssueModel> logger, 
            IUnitOfWork unitOfWork,
            IIssueService issueService)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
            _issueService = issueService;
        }

        [Authorize]
        public IActionResult CreateIssue()
        {
            var projectList = new List<ProjectModel>
            {
                new ProjectModel(){ Id = 1, ProjectName = "TestProjectId1" },
                new ProjectModel(){ Id = 3, ProjectName = "TestProjectId3" },
                new ProjectModel(){ Id = 5, ProjectName = "TestProjectId5" }
            };

            var viewModel = new CreateIssueViewModel()
            {
                ProjectList = projectList
            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> CreateIssue([FromForm] CreateIssueViewModel model)
        {
            var creatorUserId = int.Parse(User.Claims.FirstOrDefault(c => c.Type == "UserViewModelId").Value);

            return RedirectToAction("DisplayIssue", "Issue", _issueService);
        }

        [Authorize]
        public async Task<IActionResult> DisplayIssue(int id)
        {
            return View(await _issueService.GetDisplayIssueViewModel(id));
        }
    }
}
