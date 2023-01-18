using System.Security.Claims;
using BugtrackerHF.DAL.Repositories;
using BugtrackerHF.DAL.UnitOfWork;
using BugtrackerHF.Models;
using BugtrackerHF.Models.ViewModels;

namespace BugtrackerHF.Services;

public class UserService : IUserService
{
    private readonly IUnitOfWork _unitOfWork;

    public UserService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ProfileViewModel> GetProfileViewModel(string authZeroId)
    {
        var user = await _unitOfWork.UserRepository().GetByAuthZeroIdAsync(authZeroId);

        var viewModel = new ProfileViewModel
        {
            UserNickname = user.UserNickname,
            UserEmail = user.UserEmail,
            UserPicture = user.UserPicture
        };

        return viewModel;
    }

    public async Task<MyIssuesViewModel> GetMyIssuesViewModel(string authZeroId)
    {
        var user = await _unitOfWork.UserRepository().GetByAuthZeroIdAsync(authZeroId);
        await _unitOfWork.UserRepository().LoadIssuesAsync(user);

        var completedIssueList = new List<TableEntryViewModel>();
        
        foreach (var issue in user.IssueList)
        {
            completedIssueList.Add( new TableEntryViewModel
            {
                CurrentStatus = issue.CurrentStatus,
                CreatedDate = issue.CreatedDate,
                CreatorPicture = (await _unitOfWork.UserRepository().GetByIdAsync(issue.ReportedByUserId)).UserPicture,
                ProjectName = "Empty for now",
                RouteValue = issue.Id
            });    
        }
        var viewModel = new MyIssuesViewModel
        {
            Issues = completedIssueList
        };

        return viewModel;
    }
}