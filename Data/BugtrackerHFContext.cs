using BugtrackerHF.Models;
using Microsoft.EntityFrameworkCore;
namespace BugtrackerHF.Data
{
    public class BugtrackerHFContext : DbContext
    {
        public BugtrackerHFContext(DbContextOptions<BugtrackerHFContext> options)
            : base(options)
        {
        }

        public DbSet<RegisterViewModel>? RegisterViewModel { get; set; }
    }
}
