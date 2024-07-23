using Microsoft.EntityFrameworkCore;

namespace JobsAPI.Persistence
{
    public class JobsContext : DbContext
    {
        public JobsContext(DbContextOptions<JobsContext> options) : base(options)
        {
        }

        public DbSet<Domain.en_Job> Jobs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Domain.en_Job>().HasKey(j => j.ID_Job);
        }
    }
}
