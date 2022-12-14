using System.Net;
using BugtrackerHF.DAL.Data;
using BugtrackerHF.DAL.Repositories;
using BugtrackerHF.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BugtrackerHF.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly ILogger<UserController> _logger;

        public UserController(ILogger<UserController> logger, IUserRepository userRepository)
        {
            _userRepository = userRepository;
            _logger = logger;
        }


        // Registers a user in the database
        // Takes an Auth0 claim ID as parameter
        // POST: /api/user
        [HttpPost]
        public async Task<IActionResult> CreateUser(string authZeroId, string userEmail, string userNickname, string userPicture)
        {
            _logger.LogInformation("API Received: {0}", authZeroId);

            var model = await _userRepository.GetByAuthZeroIdAsync(authZeroId);

            if (model != null)
            {
                _logger.LogInformation("User: {0}, already in database", authZeroId);
                return Ok();
            }

            var userViewModel = new UserViewModel()
            {
                AuthZeroId = authZeroId,
                UserEmail = userEmail,
                UserNickname = userNickname,
                UserPicture = userPicture
            };

            await _userRepository.AddUserAsync(userViewModel);

            _logger.LogInformation("New user: {0}, added to database", userViewModel.AuthZeroId);

            return CreatedAtAction("CreateUser", userViewModel);
        }

    }
}
