using Microsoft.EntityFrameworkCore;

namespace Globalque
{
    public class PeopleDbContext : DbContext
    {
        public PeopleDbContext(DbContextOptions<PeopleDbContext> options)
            : base (options)
        { }

        public DbSet<Person> People { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<TeamUser> TeamUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Person>().OwnsOne(p => p.Pet);

            modelBuilder.Entity<TeamUser>().HasKey(tu => new { tu.TeamId, tu.UserName });
            modelBuilder.Entity<TeamUser>().HasOne<Team>().WithMany().HasForeignKey(tu => tu.TeamId);
        }
    }
}
