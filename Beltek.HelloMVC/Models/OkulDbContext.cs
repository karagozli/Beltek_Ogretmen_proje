using Microsoft.EntityFrameworkCore;

namespace Beltek.HelloMVC.Models
{
    public class OkulDbContext:DbContext
    {
        public DbSet<Ogrenci> Ogrenciler { get; set; }
        public DbSet<Ogretmen> Ogretmenler { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-VT6CIUK\\SQLEXPRESS;Initial Catalog=OkulDBMVC;Integrated Security=true;TrustServerCertificate=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Ogrenci>().ToTable("tblOgrenciler");
            modelBuilder.Entity<Ogrenci>().Property(o => o.Ad).HasColumnType("varchar").HasMaxLength(20).IsRequired();
            modelBuilder.Entity<Ogrenci>().Property(o => o.Soyad).HasColumnType("varchar").HasMaxLength(30).IsRequired();
            modelBuilder.Entity<Ogrenci>().Property(o => o.Numara).HasColumnType("varchar").HasMaxLength(15).IsRequired();
            modelBuilder.Entity<Ogrenci>().Property(o => o.Bolum).HasColumnType("varchar").HasMaxLength(30).IsRequired();

            modelBuilder.Entity<Ogretmen>().ToTable("tblOgretmenler"); 
            modelBuilder.Entity<Ogretmen>().Property(o => o.Tckimlik).HasColumnType("varchar").HasMaxLength(11).IsRequired();
            modelBuilder.Entity<Ogretmen>().HasKey(o => o.Tckimlik);
            modelBuilder.Entity<Ogretmen>().Property(o => o.Ad).HasColumnType("varchar").HasMaxLength(20).IsRequired();
            modelBuilder.Entity<Ogretmen>().Property(o => o.Soyad).HasColumnType("varchar").HasMaxLength(30).IsRequired();
            modelBuilder.Entity<Ogretmen>().Property(o => o.Alan).HasColumnType("varchar").HasMaxLength(30).IsRequired();
           

        }
    }
}
