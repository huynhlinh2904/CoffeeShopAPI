using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CoffeeShopAPI.Data;

public partial class MilkTea2024Context : DbContext
{
    public MilkTea2024Context()
    {
    }

    public MilkTea2024Context(DbContextOptions<MilkTea2024Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<History> Histories { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Size> Sizes { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-DFAHC83\\HUYNHLINH;Initial Catalog=MilkTea2024;User ID=sa;Password=123456;Encrypt=True;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.ToTable("Category");

            entity.Property(e => e.CategoryId)
                .ValueGeneratedNever()
                .HasColumnName("categoryId");
            entity.Property(e => e.CategoryName)
                .HasMaxLength(50)
                .HasColumnName("categoryName");
            entity.Property(e => e.Status).HasColumnName("status");
        });

        modelBuilder.Entity<History>(entity =>
        {
            entity.ToTable("History");

            entity.Property(e => e.HistoryId)
                .ValueGeneratedNever()
                .HasColumnName("historyId");
            entity.Property(e => e.OderId).HasColumnName("oderId");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("phoneNumber");

            entity.HasOne(d => d.Oder).WithMany(p => p.Histories)
                .HasForeignKey(d => d.OderId)
                .HasConstraintName("FK_History_Order");

            entity.HasOne(d => d.PhoneNumberNavigation).WithMany(p => p.Histories)
                .HasForeignKey(d => d.PhoneNumber)
                .HasConstraintName("FK_History_Users");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.ToTable("Order");

            entity.Property(e => e.OrderId)
                .ValueGeneratedNever()
                .HasColumnName("orderId");
            entity.Property(e => e.Number).HasColumnName("number");
            entity.Property(e => e.OderName)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("oderName");
            entity.Property(e => e.ProductId).HasColumnName("productId");
            entity.Property(e => e.SizeId).HasColumnName("sizeId");
            entity.Property(e => e.TableNumber).HasColumnName("tableNumber");
            entity.Property(e => e.TotalPrice).HasColumnName("totalPrice");

            entity.HasOne(d => d.Product).WithMany(p => p.Orders)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK_Order_Product");

            entity.HasOne(d => d.Size).WithMany(p => p.Orders)
                .HasForeignKey(d => d.SizeId)
                .HasConstraintName("FK_Order_Size");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.ToTable("Product");

            entity.Property(e => e.ProductId)
                .ValueGeneratedNever()
                .HasColumnName("productId");
            entity.Property(e => e.BestSeller).HasColumnName("bestSeller");
            entity.Property(e => e.CategoryId).HasColumnName("categoryId");
            entity.Property(e => e.PriceOfSizeL).HasColumnName("priceOfSizeL");
            entity.Property(e => e.PriceOfSizeM).HasColumnName("priceOfSizeM");
            entity.Property(e => e.ProductName)
                .HasMaxLength(100)
                .HasColumnName("productName");
            entity.Property(e => e.Status).HasColumnName("status");

            entity.HasOne(d => d.Category).WithMany(p => p.Products)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("FK_Product_Category");
        });

        modelBuilder.Entity<Size>(entity =>
        {
            entity.ToTable("Size");

            entity.Property(e => e.SizeId)
                .ValueGeneratedNever()
                .HasColumnName("sizeId");
            entity.Property(e => e.Size1)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("size");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.PhoneNumber);

            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("phoneNumber");
            entity.Property(e => e.Address)
                .HasMaxLength(200)
                .HasColumnName("address");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
