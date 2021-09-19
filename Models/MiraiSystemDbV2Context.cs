using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace MiraiSystem.Models
{
    public partial class MiraiDBContext : DbContext
    {
        public MiraiDBContext()
        {
        }

        public MiraiDBContext(DbContextOptions<MiraiDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Brand> Brand { get; set; }
        public virtual DbSet<Category> Categorie { get; set; }
        //public virtual DbSet<FashionProduct> FashionProduct { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<OrderItem> OrderItem { get; set; }
        public virtual DbSet<Permission> Permission { get; set; }
        //public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<ProductImage> ProductImage { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<RolePermission> RolePermission { get; set; }
        public virtual DbSet<Shoes> Shoes { get; set; }
        public virtual DbSet<Transaction> Transaction { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=MiraiSystemDbV3;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Brand>(entity =>
            {
                entity.ToTable("Brand");

                entity.Property(e => e.Id)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasColumnName("ID");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasMaxLength(2048)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.Slug)
                    .HasMaxLength(1024)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedBy)
                    .IsRequired()
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.HasOne(d => d.Creator)
                    .WithMany(p => p.CreatedBrands)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Brand_User1");

                entity.HasOne(d => d.Editor)
                    .WithMany(p => p.UpdatedBrands)
                    .HasForeignKey(d => d.UpdatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Brand_User");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("Category");

                entity.Property(e => e.Id)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasColumnName("ID");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasMaxLength(2048)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.Slug)
                    .IsRequired()
                    .HasMaxLength(1024)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedBy)
                    .IsRequired()
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.HasOne(d => d.Creator)
                    .WithMany(p => p.CreatedCategories)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Category_User");

                entity.HasOne(d => d.Editor)
                    .WithMany(p => p.UpdatedCategories)
                    .HasForeignKey(d => d.UpdatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Category_User1");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("Order");

                entity.Property(e => e.Id)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasColumnName("ID");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasColumnName("UserID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Order_User");
            });

            modelBuilder.Entity<OrderItem>(entity =>
            {
                entity.ToTable("OrderItem");

                entity.Property(e => e.Id)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasColumnName("ID");

                entity.Property(e => e.OrderId)
                    .IsRequired()
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasColumnName("OrderID");

                entity.Property(e => e.Sku)
                    .IsRequired()
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasColumnName("SKU");

                entity.Property(e => e.UpdatedBy)
                    .IsRequired()
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.HasOne(s => s.Editor)
                .WithMany(e => e.OrderItems)
                .HasForeignKey(s => s.UpdatedBy)
                .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderItems)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrderItem_Order");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderItems)
                    .HasForeignKey(d => d.Sku)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrderItem_Product");

                entity.HasOne(d => d.Shoes)
                    .WithMany(p => p.OrderItems)
                    .HasForeignKey(d => d.UpdatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrderItem_User");
            });

            modelBuilder.Entity<Permission>(entity =>
            {
                entity.ToTable("Permission");

                entity.Property(e => e.Id)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasColumnName("ID");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasMaxLength(2048)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedBy)
                    .IsRequired()
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.HasOne(d => d.Creator)
                    .WithMany(p => p.CreatedPermissions)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Permission_User");

                entity.HasOne(d => d.Editor)
                    .WithMany(p => p.UpdatedPermissions)
                    .HasForeignKey(d => d.UpdatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Permission_User1");
            });

            modelBuilder.Entity<Shoes>(entity =>
            {
                entity.HasKey(e => e.Sku);

                entity.ToTable("Shoes");

                entity.Property(e => e.Size).HasColumnType("decimal(2, 1)");

                entity.Property(e => e.Sku)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasColumnName("SKU");

                entity.Property(e => e.BrandId)
                    .IsRequired()
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasColumnName("BrandID");

                entity.Property(e => e.CategoryId)
                    .IsRequired()
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasColumnName("CategoryID");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasMaxLength(4096)
                    .IsUnicode(false);

                entity.Property(e => e.ModelCode)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedBy)
                    .IsRequired()
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.HasOne(d => d.Brand)
                    .WithMany(p => p.ShoesList)
                    .HasForeignKey(d => d.BrandId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Product_Brand");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.ShoesList)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Product_Category");

                entity.HasOne(d => d.Creator)
                    .WithMany(p => p.CreatedShoesList)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Product_User");

                entity.HasOne(d => d.Editor)
                    .WithMany(p => p.UpdatedShoesList)
                    .HasForeignKey(d => d.UpdatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Product_User1");
            });

            modelBuilder.Entity<ProductImage>(entity =>
            {
                entity.HasKey(e => e.ImageId);

                entity.ToTable("ProductImage");

                entity.Property(e => e.ImageId)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasColumnName("ImageID");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.Property(e => e.ImageRole)
                    .IsRequired()
                    .HasMaxLength(124)
                    .IsUnicode(false);

                entity.Property(e => e.Sku)
                    .IsRequired()
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasColumnName("SKU");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedBy)
                    .IsRequired()
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.Property(e => e.Url)
                    .IsRequired()
                    .HasMaxLength(2048)
                    .IsUnicode(false)
                    .HasColumnName("URL");

                entity.HasOne(d => d.Creator)
                    .WithMany(p => p.CreatedProductImages)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductImage_User");

                entity.HasOne(d => d.Shoes)
                    .WithMany(p => p.ProductImages)
                    .HasForeignKey(d => d.Sku)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductImage_Product");

                entity.HasOne(d => d.Editor)
                    .WithMany(p => p.UpdatedProductImages)
                    .HasForeignKey(d => d.UpdatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductImage_User1");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("Role");

                entity.Property(e => e.Id)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasColumnName("ID");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasMaxLength(2056)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.Slug)
                    .IsRequired()
                    .HasMaxLength(1024)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedBy)
                    .IsRequired()
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.HasOne(d => d.Creator)
                    .WithMany(p => p.CreatedRoles)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Role_User");

                entity.HasOne(d => d.Editor)
                    .WithMany(p => p.UpdatedRoles)
                    .HasForeignKey(d => d.UpdatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Role_User1");
            });

            modelBuilder.Entity<RolePermission>(entity =>
            {
                entity.ToTable("RolePermission");

                entity.Property(e => e.Id)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasColumnName("ID");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.Property(e => e.PermissionId)
                    .IsRequired()
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasColumnName("PermissionID");

                entity.Property(e => e.RoleId)
                    .IsRequired()
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasColumnName("RoleID");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedBy)
                    .IsRequired()
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.HasOne(d => d.Creator)
                    .WithMany(p => p.CreatedRolePermissions)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RolePermission_User");

                entity.HasOne(d => d.Permission)
                    .WithMany(p => p.RolePermissions)
                    .HasForeignKey(d => d.PermissionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RolePermission_Permission");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.RolePermissions)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RolePermission_Role");

                entity.HasOne(d => d.Editor)
                    .WithMany(p => p.UpdatedRolePermissions)
                    .HasForeignKey(d => d.UpdatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RolePermission_User1");
            });

            modelBuilder.Entity<Shoes>(entity =>
            {
                //entity.HasKey(e => e.Sku);

                entity.Property(e => e.Sku)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasColumnName("SKU");

                entity.Property(e => e.Size).HasColumnType("decimal(2, 1)");
            });

            modelBuilder.Entity<Transaction>(entity =>
            {
                entity.ToTable("Transaction");

                entity.Property(e => e.Id)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasColumnName("ID");

                entity.Property(e => e.CreatedAt)
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.OrderId)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasColumnName("OrderID");

                entity.Property(e => e.UserId)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasColumnName("UserID");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.HasIndex(e => e.Email, "UNIQUE_USER_EMAIL")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasColumnName("ID");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.Firstname)
                    .IsRequired()
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.Lastname)
                    .IsRequired()
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.RoleId)
                    .IsRequired()
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasColumnName("RoleID");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_User_Role");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
