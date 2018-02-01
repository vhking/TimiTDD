using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TimiTDD.Models;

namespace TimiTDD.Data
{
    class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        
        public DbSet<WorkParticipation> WorkParticipation { get; set; }
        public DbSet<Project> Project { get; set; }
        public DbSet<Client> Client { get; set; }
        public DbSet<ActivityType> ActivityType { get; set; }
        public DbSet<AbsenceCategory> AbsenceCategory { get; set; }
        public DbSet<WorkCategory> WorkCategory { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
            
        }
        

    }
}

