using Microsoft.EntityFrameworkCore;

namespace MiraiSystem.Models
{
    public class MiraiDBContext : DbContext
    {
        public MiraiDBContext()
        {
        }

        public MiraiDBContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<ConcreteShoes> ConcreteShoes { get; set; }
        public DbSet<Shoes> Shoes { get; set; }
        public DbSet<ShoesImage> ShoesImage { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //shoes
            modelBuilder.Entity<Shoes>().HasKey(s => s.Id);
            //user
            modelBuilder.Entity<User>().HasKey(s => s.Id);
            //shoesImage
            modelBuilder.Entity<ShoesImage>()
                .HasOne(c => c.Shoes)
                .WithMany(s => s.ShoesImages)
                .HasForeignKey(c => c.ShoesId)
                .OnDelete(DeleteBehavior.Restrict);
            //inventory shoes
            modelBuilder.Entity<ConcreteShoes>()
               .HasOne(c => c.Shoes)
               .WithMany(s => s.ConcreteShoes)
               .HasForeignKey(c => c.ShoesId)
               .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
