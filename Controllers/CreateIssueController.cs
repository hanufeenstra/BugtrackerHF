using BugtrackerHF.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BugtrackerHF.Controllers
{
    public class CreateIssueController : Controller
    {
        [Authorize]
        public IActionResult CreateIssue()
        {
            return View();
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> CreateIssue([Bind("")] IssueViewModel issueViewModel)
        //{
        //    return View();
        //}
    }
}
