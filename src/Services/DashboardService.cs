using BugtrackerHF.DAL.Repositories;
using BugtrackerHF.Models.ViewModels;

namespace BugtrackerHF.Services;

public class DashboardService : IDashboardService
{
    private readonly IUserRepository _userRepository;

    public DashboardService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<DashboardViewModel> GetDashboardViewModel(string authZeroId)
    {
        var user = await _userRepository.GetByAuthZeroIdAsync(authZeroId);

        return new DashboardViewModel();
    }
}