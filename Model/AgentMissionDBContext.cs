using Microsoft.EntityFrameworkCore;

namespace AlignAPITest.Model
{
    public class AgentMissionDBContext:DbContext
    {
        public AgentMissionDBContext(DbContextOptions<AgentMissionDBContext> options) : base(options)
        {
        }

        public virtual DbSet<AgentMission> AgentMission { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<AgentMission>().HasKey("AgentId");
        }
    }
}
