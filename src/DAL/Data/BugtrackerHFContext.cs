using BugtrackerHF.Models;
using BugtrackerHF.src.Models;
using Microsoft.EntityFrameworkCore;

namespace BugtrackerHF.src.DAL.Data;

public class BugtrackerHFContext : DbContext
{
    public BugtrackerHFContext(DbContextOptions<BugtrackerHFContext> options)
        : base(options)
    {
        ChangeTracker.LazyLoadingEnabled = false;
    }

    public DbSet<ProjectModel>? ProjectModel { get; set; }
    public DbSet<UserModel>? UserModel { get; set; }
    public DbSet<IssueModel>? IssueModel { get; set; }
    public DbSet<MessageModel>? MessageModel { get; set; }

}