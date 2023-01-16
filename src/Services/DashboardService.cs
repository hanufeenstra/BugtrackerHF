using BugtrackerHF.DAL.Repositories;

namespace BugtrackerHF.Services;

public class DashboardService
{
    private readonly IUserRepository _userRepository;

    public DashboardService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }


}