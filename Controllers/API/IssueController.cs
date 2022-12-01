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
        public async Task<ActionResult<IList<IssueViewModel>>> GetIssue()
        {
            var model = await _context.IssueViewModel.ToListAsync();

            return model;
        }

        //GET: /api/issue/5
        [HttpGet("{Id}")]

        public async Task<ActionResult<IssueViewModel>> GetIssue(int id)
        {
            var model = await _context.IssueViewModel.FirstOrDefaultAsync(m => m.Id == id);

            if( model == null)
                return NotFound();

            return model;
        }

        // POST: /api/issue
        //[HttpPost]
        //public async Task<ActionResult> CreateIssue(IssueViewModel issue)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.IssueViewModel.Add(issue);
        //        await _context.SaveChangesAsync();
        //        return Ok(_context.IssueViewModel.SingleOrDefaultAsync());
        //    }
        //    return 
        //}
    }
}
