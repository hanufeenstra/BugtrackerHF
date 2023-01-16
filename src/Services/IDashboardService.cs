using BugtrackerHF.Models.ViewModels;

namespace BugtrackerHF.Services;

public interface IDashboardService
{
    Task<DashboardViewModel> GetDashboardViewModel(string authZeroId);
}