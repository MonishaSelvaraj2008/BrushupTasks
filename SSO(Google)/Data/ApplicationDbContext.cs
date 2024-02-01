using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SSO_Google_.Models;

namespace SSO_Google_.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public virtual DbSet<Login> Credentials { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); // This is important for Identity configurations

            modelBuilder.Entity<Login>()
                .HasKey(u => u.userEmail);
        }
    }
}
