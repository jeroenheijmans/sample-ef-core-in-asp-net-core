using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

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

            modelBuilder.Entity<Team>();
            modelBuilder.Entity<Team>().HasIndex(t => t.Code).IsUnique();

            modelBuilder.Entity<Person>().OwnsOne(p => p.Pet);

            modelBuilder.Entity<TeamUser>().HasKey(tu => new { tu.TeamId, tu.UserName });
            modelBuilder.Entity<TeamUser>().HasOne<Team>().WithMany().HasForeignKey(tu => tu.TeamId);
        }

        public static void Seed(PeopleDbContext db)
        {
            var defaultTeam = db.Teams.SingleOrDefaultAsync(t => t.Code == Team.DefaultTeamCode).Result;

            if (defaultTeam == null)
            {
                db.Teams.Add(new Team { Code = Team.DefaultTeamCode, Name = Team.DefaultTeamCode });
            }
            
            db.SaveChanges();
        }
    }
}
