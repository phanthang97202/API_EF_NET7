using Microsoft.EntityFrameworkCore;

namespace API_EF_NET7.Models
{
    public class WCDbContext : DbContext
    {

        public WCDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Confederation> Confederations { get; set; }
        public DbSet<Team> Team { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Confederation>(entity =>
            {
                entity.ToTable("Confederation");
                entity.Property(e => e.ConfederationId).HasColumnName("ConfederationId");
                entity.Property(e => e.ConfederationName).HasMaxLength(255).IsFixedLength().HasColumnName("ConfederationName");
            });
            modelBuilder.Entity<Team>(entity =>
            {
                entity.ToTable("Team");
                entity.Property(e => e.TeamId).HasColumnName("TeamId");
                entity.Property(e => e.CountryName).HasMaxLength(255).IsFixedLength().HasColumnName("CountryName");
                entity.Property(e => e.ConfederationId).HasColumnName("ConfederationId");
                //entity.HasOne(e => e.Confederation).WithOne(); 
            });
        }
    }
}