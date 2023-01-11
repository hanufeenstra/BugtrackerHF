using System.Security.Claims;
using BugtrackerHF.DAL.Repositories;
using Microsoft.AspNetCore.Authentication;

namespace BugtrackerHF.src.Services;

public class ClaimsTransformation : IClaimsTransformation
{
    private readonly IUserRepository _userRepository;

    public ClaimsTransformation(IUserRepository userRepository)
    {
        _userRepository = userRepository;
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
        var claim = new Claim("UserViewModelId", user.Id.ToString());
        newIdentity.AddClaim(claim);

        return clone;
    }
}