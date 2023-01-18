using System.Diagnostics.CodeAnalysis;
using System.Security.Claims;
using BugtrackerHF.DAL.UnitOfWork;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace BugtrackerHF.Services;

public class ClaimsTransformation : IClaimsTransformation
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger<ClaimsTransformation> _logger;

    public ClaimsTransformation(IUnitOfWork unitOfWork, ILogger<ClaimsTransformation> logger)
    {
        _unitOfWork = unitOfWork;
        _logger = logger;
    }

    [SuppressMessage("ReSharper.DPA", "DPA0009: High execution time of DB command", MessageId = "time: 2849ms")]
    public async Task<ClaimsPrincipal> TransformAsync(ClaimsPrincipal principal)
    {
        // Clone current identity
        var clone = principal.Clone();
        var newIdentity = clone.Identity as ClaimsIdentity;
        
        // Checks whether the claim has previously been modified
        if (principal.Claims.FirstOrDefault(c => c.ValueType == "Transformed")?.Value == "True")
            return clone;
        
        // Support AD and local accounts
        var authZeroId = principal.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
        
        if (authZeroId == null)
        {
            newIdentity.AddClaim(new Claim("UserModelId", ""));
            newIdentity.AddClaim(new Claim("UserPicture", ""));
            newIdentity.AddClaim(new Claim("UserNickname", ""));

            _logger.LogError("Auth0 Id not found, empty claim returned");
            return clone;
        }

        // Get user from database
        var user = await _unitOfWork.UserRepository().GetByAuthZeroIdAsync(authZeroId);

        if (user == null)
        {
            newIdentity.AddClaim(new Claim("UserModelId", ""));
            newIdentity.AddClaim(new Claim("UserPicture", ""));
            newIdentity.AddClaim(new Claim("UserNickname", ""));
            _logger.LogError("User linked to Auth0 Id not found, empty claim returned");
            return clone;
        }

        // Add userId claim to cloned identity
        var userId = new Claim("UserModelId", user.Id.ToString());

        // Add userPicture to cloned identity 
        var userPicture = new Claim("UserPicture", user.UserPicture!);

        // Add userNickname to cloned identity
        var userNickname = new Claim("UserNickname", user.UserNickname!);
        
        // Add transformedClaim to cloned identity
        var isTransformed = new Claim("Transformed", "True");

        newIdentity.AddClaim(userId);
        newIdentity.AddClaim(userPicture);
        newIdentity.AddClaim(userNickname);
        newIdentity.AddClaim(isTransformed);

        _logger.LogInformation("Transformed claim. Added userId: {0}, userPicture: {1}, userNickname: {2}", userId, userPicture, userNickname);

        return clone;
    }
}