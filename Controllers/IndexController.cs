using Microsoft.AspNetCore.Mvc;
using BugtrackerHF.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace BugtrackerHF.Controllers
{
    public class IndexController : Controller
    {
        [Authorize]
        [ValidateAntiForgeryToken]
        public IActionResult Index()
        {
            var name = User.Identity.Name;
            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            var givenName = User.Claims.FirstOrDefault(c => c.Type == "nickname")?.Value;
            
            Console.WriteLine("Email: " + name);
            Console.WriteLine("User Id: " + userId);
            Console.WriteLine("Nickname: " + givenName);
            return View();
        }

        //[HttpPost]
        //[Authorize]
        //[ValidateAntiForgeryToken]
        //public async Task CreateIssue([Bind(", ,")] IssueViewModel issueViewModel, int id)
        //{

        //    return
        //}

        
        [Authorize]
        public IActionResult Claims()
        {
            return RedirectToAction("Index", "Index");
        }
    }



}
