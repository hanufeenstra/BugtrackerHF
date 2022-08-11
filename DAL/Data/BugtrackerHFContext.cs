using BugtrackerHF.Models;
using Microsoft.EntityFrameworkCore;

namespace BugtrackerHF.DAL.Data;

public class BugtrackerHFContext : DbContext
{
    public BugtrackerHFContext (DbContextOptions<BugtrackerHFContext> options) 
        : base(options)
    {
    }

    public DbSet<ProjectViewModel>? ProjectViewModel { get; set; }
    public DbSet<AdminViewModel>? AdminViewModel { get; set; }
    public DbSet<UserViewModel>? UserViewModel { get; set; }
    public DbSet<IssueViewModel>? IssueViewModel { get; set; }
    public DbSet<NotificationViewModel>? NotificationViewModels { get; set; }
    public DbSet<MessageViewModel>? MessageViewModel { get; set; }

}