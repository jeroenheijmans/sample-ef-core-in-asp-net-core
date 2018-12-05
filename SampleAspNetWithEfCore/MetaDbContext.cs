using Microsoft.EntityFrameworkCore;

namespace SampleAspNetWithEfCore
{
    public class MetaDbContext : DbContext
    {
        public MetaDbContext(DbContextOptions<MetaDbContext> options)
            : base(options)
        { }

        public DbSet<TeamUser> TeamUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TeamUser>().HasKey(tu => new { tu.TeamId, tu.UserName });
            modelBuilder.Entity<TeamUser>().HasOne<Team>().WithMany().HasForeignKey(tu => tu.TeamId);
        }
    }
}
