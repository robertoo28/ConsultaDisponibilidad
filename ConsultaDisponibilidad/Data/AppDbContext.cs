using ConsultaDisponibilidad.Model;
using Microsoft.EntityFrameworkCore;

namespace ConsultaDisponibilidad.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Availability> Availability { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Availability>()
                .HasKey(a => a.room_id); // Define the primary key

            base.OnModelCreating(modelBuilder);
        }
    }
}