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
                new ProjectModel(){ Id = 1, ProjectName = "TestProject" }
            };

            var viewModel = new CreateIssueViewModel()
            {
                ProjectList = projectList
            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> CreateIssue([FromForm] int selectedProjectId, CreateIssueViewModel model)
        {
            Console.WriteLine(model.SelectedProject.ProjectName);
            var userId = int.Parse(User.Claims.FirstOrDefault(c => c.Type == "UserViewModelId").Value);
            var messageList = new List<MessageModel>();
            var message = new MessageModel()
            {
                CreatedByUserId = userId,
                CreatedTime = DateTime.Now,
                Message = model.Description
            };
            messageList.Add(message);

            var issue = new IssueModel()
            {
                MessageList = messageList,
                CreatedDate = DateTime.Now,
                CurrentStatus = Status.Unopened,
                CurrentSeverity = Severity.Cosmetic,
                IssueName = model.Description,
                LastUpdateDate = DateTime.Now
            };

            await _unitOfWork.IssueRepository().InsertAsync(issue);
            _unitOfWork.Save();

            var newIssue = _unitOfWork.IssueRepository().GetAsync(issue);


            return RedirectToAction("DisplayIssue", "Issue", newIssue.Id);
        }

        [Authorize]
        public async Task<IActionResult> DisplayIssue(int id)
        {
            return View(await _issueService.GetDisplayIssueViewModel(id));
        }
    }
}
