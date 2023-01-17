using BugtrackerHF.Models;
using BugtrackerHF.DAL.Repositories;
using BugtrackerHF.DAL.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace BugtrackerHF.Controllers.API.v1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<UserController> _logger;

        public UserController(
            ILogger<UserController> logger, 
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }


        // Registers a user in the database
        // Takes an Auth0 claim ID as parameter
        // POST: /api/user
        [HttpPost]
        public async Task<IActionResult> CreateUser(string authZeroId, string userEmail, string userNickname, string userPicture)
        {
            _logger.LogInformation("API Received: {0}", authZeroId);

            var model = await _unitOfWork.UserRepository().GetByAuthZeroIdAsync(authZeroId);

            if (model != null)
            {
                _logger.LogInformation("User: {0}, already in database", authZeroId);
                return Ok();
            }

            var userViewModel = new UserModel()
            {
                AuthZeroId = authZeroId,
                UserEmail = userEmail,
                UserNickname = userNickname,
                UserPicture = userPicture
            };

            await _unitOfWork.UserRepository().InsertAsync(userViewModel);

            _logger.LogInformation("New user: {0}, added to database", userViewModel.AuthZeroId);

            return CreatedAtAction("CreateUser", userViewModel);
        }

    }
}
