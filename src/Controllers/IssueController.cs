using BugtrackerHF.Models;
using BugtrackerHF.src.DAL.Repositories;
using BugtrackerHF.src.Models;
using BugtrackerHF.src.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BugtrackerHF.src.Controllers
{
    public class IssueController : Controller
    {
        private readonly IIssueRepository _issueRepository;
        private readonly IUserRepository _userRepository;
        private readonly ILogger<IssueModel> _logger;

        public IssueController(ILogger<IssueModel> logger, IIssueRepository issueRepository, IUserRepository userRepository)
        {
            _logger = logger;
            _issueRepository = issueRepository;
            _userRepository = userRepository;
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
        public async Task<IActionResult> CreateIssue([FromForm] CreateIssueViewModel model)
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

            var newIssue = await _issueRepository.AddAsync(issue);


            return RedirectToAction("View", "Issue", newIssue.Id);
        }

        [Authorize]
        public async Task<IActionResult> View(int id)
        {
            var issue = await _issueRepository.GetByIdAsync(id);

            if (issue == null)
                RedirectToAction("", "");

            return View(issue);
        }
    }
}
