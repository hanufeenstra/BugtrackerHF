using System.Security.Claims;
using BugtrackerHF.DAL.Repositories;
using Microsoft.AspNetCore.Authentication;

namespace BugtrackerHF.Services;

public class ClaimsTransformation : IClaimsTransformation
{
    private readonly IUserRepository _userRepository;
    private readonly ILogger<ClaimsTransformation> _logger;

    public ClaimsTransformation(IUserRepository userRepository, ILogger<ClaimsTransformation> logger)
    {
        _userRepository = userRepository;
        _logger = logger;
    }

    public async Task<ClaimsPrincipal> TransformAsync(ClaimsPrincipal principal)
    {
        // Clone current identity
        var clone = principal.Clone();
        var newIdentity = clone.Identity as ClaimsIdentity;

        // Support AD and local accounts
        var authZeroId = principal.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
        if (authZeroId == null)
        {
            return principal;
        }

        // Get user from database
        var user = await _userRepository.GetByAuthZeroIdAsync(authZeroId);
        if (user == null)
        {
            return principal;
        }

        // Add userId claim to cloned identity
        var userId = new Claim("UserModelId", user.Id.ToString());

        // Add userPicture to cloned identity 
        var userPicture = new Claim("UserPicture", user.UserPicture!);

        // Add userNickname to cloned identity
        var userNickname = new Claim("UserNickname", user.UserNickname!);

        newIdentity.AddClaim(userId);
        newIdentity.AddClaim(userPicture);
        newIdentity.AddClaim(userNickname);

        _logger.LogInformation("Transformed claim. Added userId: {0}, userPicture: {1}, userNickname: {2}", userId, userPicture, userNickname);

        return clone;
    }
}