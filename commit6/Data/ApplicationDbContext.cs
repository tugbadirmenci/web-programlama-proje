using WebApplication1.Models;  // Hizmet, Personel ve Randevu sınıflarının bulunduğu namespace
using Microsoft.EntityFrameworkCore;


namespace WebApplication1.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
         public DbSet<Kullanici>? Kullanici { get; set; }
        public DbSet<Hizmet>? Hizmet { get; set; }
        public DbSet<Personel>? Personel { get; set; }
        public DbSet<Randevu>? Randevu { get; set; } // Randevu DbSet'i
         public DbSet<Admin>? Admins { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // İlişkileri belirlemek için yapılandırmalar ekleyebilirsiniz
        }
    }
}

