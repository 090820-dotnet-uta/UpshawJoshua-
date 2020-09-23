using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace UpshawP0.Models
{
    public partial class SGDB2Context : DbContext
    {
        public SGDB2Context()
        {
        }

        public SGDB2Context(DbContextOptions<SGDB2Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Customers> Customers { get; set; }
        public virtual DbSet<Inventory> Inventory { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<Products> Products { get; set; }
        public virtual DbSet<Stores> Stores { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=LAPTOP-5TFSV06B;Initial Catalog=SGDB2;Database=SGDB2;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customers>(entity =>
            {
                entity.HasKey(e => e.CustomerId)
                    .HasName("PK__Customer__A4AE64B82021F977");

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.AptNum)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.DefaultStore).HasDefaultValueSql("((1))");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Pword)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.State)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.Street)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Zip).HasColumnType("numeric(5, 0)");
            });

            modelBuilder.Entity<Inventory>(entity =>
            {
                entity.Property(e => e.ProductCurrentQuantity).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.ItemInInventoryNavigation)
                    .WithMany(p => p.Inventory)
                    .HasForeignKey(d => d.ItemInInventory)
                    .HasConstraintName("FK__Inventory__ItemI__093F5D4E");

                entity.HasOne(d => d.StoreInventoryNavigation)
                    .WithMany(p => p.Inventory)
                    .HasForeignKey(d => d.StoreInventory)
                    .HasConstraintName("FK__Inventory__Store__084B3915");
            });

            modelBuilder.Entity<Orders>(entity =>
            {
                entity.HasKey(e => e.Pk)
                    .HasName("PK__Orders__321507873CFA0500");

                entity.Property(e => e.Pk).HasColumnName("PK");

                entity.Property(e => e.OrderDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.OrderTotal).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.OrderedProductAmount).HasDefaultValueSql("((1))");

                entity.HasOne(d => d.OrderedProductNavigation)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.OrderedProduct)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Orders__OrderedP__13BCEBC1");

                entity.HasOne(d => d.StoreOrderedFromNavigation)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.StoreOrderedFrom)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK__Orders__StoreOrd__14B10FFA");

                entity.HasOne(d => d.WhoOrderedNavigation)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.WhoOrdered)
                    .HasConstraintName("FK__Orders__WhoOrder__15A53433");
            });

            modelBuilder.Entity<Products>(entity =>
            {
                entity.HasKey(e => e.Skunum)
                    .HasName("PK__Products__5778E6EA3B1BE189");

                entity.Property(e => e.Skunum).HasColumnName("SKUNum");

                entity.Property(e => e.ProductDescrip)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ProductDiscount)
                    .HasColumnType("decimal(2, 2)")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.ProductName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UnitPrice)
                    .HasColumnType("decimal(10, 2)")
                    .HasDefaultValueSql("((1.00))");
            });

            modelBuilder.Entity<Stores>(entity =>
            {
                entity.HasKey(e => e.StoreId)
                    .HasName("PK__Stores__3B82F0E1E0CBDEBD");

                entity.Property(e => e.StoreId).HasColumnName("StoreID");

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(22);

                entity.Property(e => e.State)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.Street)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Zip).HasColumnType("numeric(5, 0)");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
