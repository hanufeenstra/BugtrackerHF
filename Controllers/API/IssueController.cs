using System.Net;
using BugtrackerHF.DAL.Data;
using BugtrackerHF.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol;

namespace BugtrackerHF.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class IssueController : ControllerBase
    {
        private readonly BugtrackerHFContext _context;
        private readonly ILogger<IssueController> _logger;

        public IssueController(ILogger<IssueController> logger, BugtrackerHFContext context)
        {
            _context = context;
            _logger = logger;
        }

        // GET: /api/issue
        [HttpGet]
        public async Task<ActionResult> GetIssue()
        {
            var model = await _context.IssueViewModel.ToListAsync();

            return Ok(model);
        }

        //GET: /api/issue/5
        [HttpGet("{Id}")]

        public async Task<ActionResult> GetIssue(int id)
        {
            var model = await _context.IssueViewModel.FirstOrDefaultAsync(m => m.Id == id);

            

            if( model == null)
                return NotFound();

            return Ok(model);
        }

        // POST: /api/issue?issueName&comment&creatorId&assignedToId
        [HttpPost]
        public async Task<ActionResult> CreateIssue(string issueName, string comment, int creatorId)
        {
            var issue = new IssueViewModel( 
                issueName, 
                creatorId,
                new MessageViewModel(creatorId, "Issue: " + comment + ", opened by: " + creatorId.ToString())
            );


            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.IssueViewModel.Add(issue);
            await _context.SaveChangesAsync();
            return CreatedAtAction("CreateIssue", issue);
            
        }
        
    }
}
