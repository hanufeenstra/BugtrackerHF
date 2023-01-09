using BugtrackerHF.Models;
using Microsoft.EntityFrameworkCore;

namespace BugtrackerHF.DAL.Data;

public class BugtrackerHFContext : DbContext
{
    public BugtrackerHFContext (DbContextOptions<BugtrackerHFContext> options) 
        : base(options)
    {
        ChangeTracker.LazyLoadingEnabled = false;
    }

    public DbSet<ProjectModel>? ProjectModel { get; set; }
    public DbSet<UserModel>? UserModel { get; set; }
    public DbSet<IssueModel>? IssueModel { get; set; }
    public DbSet<MessageModel>? MessageModel { get; set; }

}