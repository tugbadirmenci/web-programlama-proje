using WebApplication1.Models;  // Hizmet, Personel ve Randevu sınıflarının bulunduğu namespace
using Microsoft.EntityFrameworkCore;


namespace WebApplication1.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Hizmet>? Hizmet { get; set; }
        public DbSet<Personel>? Personel { get; set; }
        public DbSet<Randevu>? Randevu { get; set; } // Randevu DbSet'i

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // İlişkileri belirlemek için yapılandırmalar ekleyebilirsiniz
        }
    }
}

