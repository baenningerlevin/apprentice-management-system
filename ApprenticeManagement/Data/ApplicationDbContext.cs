using ApprenticeManagement.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace ApprenticeManagement.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Apprentice> Apprentices { get; set; }
        public DbSet<Contract> Contracts { get; set; }
        public DbSet<Parent> Parents { get; set; }
        public DbSet<Apprentice_Parent> Apprentice_Parents { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Apprentice_Parent>()
            .HasKey(ap => new { ap.ParentId, ap.ApprenticeId });

            modelBuilder.Entity<Apprentice_Parent>()
                .HasOne(ap => ap.Apprentice)
                .WithMany(a => a.Apprentice_Parents)
                .HasForeignKey(ap => ap.ApprenticeId);

            modelBuilder.Entity<Apprentice_Parent>()
                .HasOne(ap => ap.Parent)
                .WithMany(a => a.Apprentice_Parents)
                .HasForeignKey(ap => ap.ParentId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
