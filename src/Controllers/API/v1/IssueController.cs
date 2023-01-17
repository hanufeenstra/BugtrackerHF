using BugtrackerHF.Models;
using BugtrackerHF.DAL.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace BugtrackerHF.Controllers.API.v1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class IssueController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<IssueController> _logger;

        public IssueController(
            ILogger<IssueController> logger, 
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        // GET: /api/issue
        //[HttpGet]
        //public async Task<ActionResult> GetIssue()
        //{
        //    var model = await _unitOfWork.IssueRepository().

        //    return Ok(model);
        //}

        //GET: /api/issue/5
        [HttpGet("{Id}")]
        public async Task<ActionResult> GetIssue(int id)
        {
            var issue = await _unitOfWork.IssueRepository().GetByIdAsync(id);

            if (issue == null)
                return NotFound();

            return Ok(issue);
        }

        // POST: /api/issue?issueName&comment&creatorId&assignedToId
        [HttpPost]
        public async Task<ActionResult> Create(string issueName, string comment, int creatorId)
        {
            var issue = new IssueModel();
            //    issueName,
            //    creatorId,
            //    new MessageModel(creatorId, "Issue: " + comment + ", opened by: " + creatorId.ToString())
            //);


            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _unitOfWork.IssueRepository().InsertAsync(issue);
            _unitOfWork.Save();

            return CreatedAtAction("CreateIssue", issue);

        }

    }
}
