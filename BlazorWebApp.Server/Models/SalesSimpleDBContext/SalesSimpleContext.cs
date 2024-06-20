using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BlazorWebApp.Server.Models.SalesSimpleDBContext;

public partial class SalesSimpleContext : DbContext
{
    public SalesSimpleContext()
    {
    }

    public SalesSimpleContext(DbContextOptions<SalesSimpleContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Blob> Blobs { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<DmlMaster> DmlMasters { get; set; }

    public virtual DbSet<DmlMaster2> DmlMaster2s { get; set; }

    public virtual DbSet<Imtr> Imtrs { get; set; }

    public virtual DbSet<LineItem> LineItems { get; set; }

    public virtual DbSet<Nation> Nations { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<Part> Parts { get; set; }

    public virtual DbSet<PartsSupp> PartsSupps { get; set; }

    public virtual DbSet<Region> Regions { get; set; }

    public virtual DbSet<Supplier> Suppliers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Server=.;Database=SalesSimple;Trusted_Connection=False;user id=sa;password=JVM;Persist Security Info=False;TrustServerCertificate=true;Encrypt=False;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Blob>(entity =>
        {
            entity.Property(e => e.Lob).IsUnicode(false);
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.CustKey);

            entity.HasIndex(e => new { e.NationKey, e.AcctBal }, "IX_C_A");

            entity.HasIndex(e => e.Name, "IX_Customers_Name");

            entity.HasIndex(e => e.Phone, "IX_Customers_Phone");

            entity.Property(e => e.CustKey).ValueGeneratedNever();
            entity.Property(e => e.AcctBal).HasColumnType("decimal(15, 2)");
            entity.Property(e => e.Address)
                .HasMaxLength(80)
                .IsUnicode(false);
            entity.Property(e => e.Comment)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.MktSegment)
                .HasMaxLength(20)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Phone)
                .HasMaxLength(30)
                .IsUnicode(false)
                .IsFixedLength();
        });

        modelBuilder.Entity<DmlMaster>(entity =>
        {
            entity.HasKey(e => e.OrderKey);

            entity.ToTable("DML_Master");

            entity.HasIndex(e => e.CustomerKey, "IX_DMLMaster_CustomerKey");

            entity.Property(e => e.CustomerKey)
                .HasMaxLength(5)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Note).IsUnicode(false);
            entity.Property(e => e.OrderDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.TotalPrice).HasColumnType("decimal(18, 2)");
        });

        modelBuilder.Entity<DmlMaster2>(entity =>
        {
            entity.HasKey(e => e.OrderKey);

            entity.ToTable("DML_Master2");

            entity.Property(e => e.OrderKey).ValueGeneratedNever();
            entity.Property(e => e.CustomerKey)
                .HasMaxLength(5)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Note).IsUnicode(false);
            entity.Property(e => e.OrderDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.TotalPrice).HasColumnType("decimal(18, 2)");
        });

        modelBuilder.Entity<Imtr>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("imtr");

            entity.Property(e => e.Code).HasColumnName("code");
        });

        modelBuilder.Entity<LineItem>(entity =>
        {
            entity.HasKey(e => new { e.OrderKey, e.LineNumber });

            entity.Property(e => e.Comment)
                .HasMaxLength(90)
                .IsUnicode(false);
            entity.Property(e => e.CommitDate).HasColumnType("datetime");
            entity.Property(e => e.Discount).HasColumnType("decimal(15, 2)");
            entity.Property(e => e.ExtendedPrice).HasColumnType("decimal(15, 2)");
            entity.Property(e => e.LineStatus)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Quantity).HasColumnType("decimal(15, 2)");
            entity.Property(e => e.ReceiptDate).HasColumnType("datetime");
            entity.Property(e => e.ReturnFlag)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.ShipDate).HasColumnType("datetime");
            entity.Property(e => e.ShipMode)
                .HasMaxLength(20)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.ShipinStruct)
                .HasMaxLength(50)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Tax).HasColumnType("decimal(15, 2)");

            entity.HasOne(d => d.OrderKeyNavigation).WithMany(p => p.LineItems)
                .HasForeignKey(d => d.OrderKey)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_LineItems_Orders");

            entity.HasOne(d => d.PartsSupp).WithMany(p => p.LineItems)
                .HasForeignKey(d => new { d.PartKey, d.SuppKey })
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_LineItems_PartsSupps");
        });

        modelBuilder.Entity<Nation>(entity =>
        {
            entity.HasKey(e => e.NationKey);

            entity.Property(e => e.NationKey).ValueGeneratedNever();
            entity.Property(e => e.Comment)
                .HasMaxLength(300)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .IsFixedLength();

            entity.HasOne(d => d.RegionKeyNavigation).WithMany(p => p.Nations)
                .HasForeignKey(d => d.RegionKey)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Nations_Regions");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.OrderKey).IsClustered(false);

            entity.HasIndex(e => e.OrderDate, "CL_Orders").IsClustered();

            entity.HasIndex(e => e.CustKey, "IX_Orders_CustKey");

            entity.Property(e => e.OrderKey).ValueGeneratedNever();
            entity.Property(e => e.Clerk)
                .HasMaxLength(30)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Comment)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.OrderDate).HasColumnType("datetime");
            entity.Property(e => e.OrderPriority)
                .HasMaxLength(30)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.OrderStatus)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.TotalPrice).HasColumnType("decimal(15, 2)");

            entity.HasOne(d => d.CustKeyNavigation).WithMany(p => p.Orders)
                .HasForeignKey(d => d.CustKey)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Orders_Customers");
        });

        modelBuilder.Entity<Part>(entity =>
        {
            entity.HasKey(e => e.PartKey);

            entity.Property(e => e.PartKey).ValueGeneratedNever();
            entity.Property(e => e.Brand)
                .HasMaxLength(20)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Comment)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Container)
                .HasMaxLength(20)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Mfgr)
                .HasMaxLength(50)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Name)
                .HasMaxLength(110)
                .IsUnicode(false);
            entity.Property(e => e.RetailPrice).HasColumnType("decimal(15, 2)");
            entity.Property(e => e.Type)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<PartsSupp>(entity =>
        {
            entity.HasKey(e => new { e.PartKey, e.SuppKey }).HasName("PK_PartSupps");

            entity.HasIndex(e => e.SuppKey, "IX_PartsSupps_SuppKey");

            entity.Property(e => e.Comment)
                .HasMaxLength(400)
                .IsUnicode(false);
            entity.Property(e => e.SupplyCost).HasColumnType("decimal(15, 2)");

            entity.HasOne(d => d.PartKeyNavigation).WithMany(p => p.PartsSupps)
                .HasForeignKey(d => d.PartKey)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PartsSupps_Parts");

            entity.HasOne(d => d.SuppKeyNavigation).WithMany(p => p.PartsSupps)
                .HasForeignKey(d => d.SuppKey)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PartsSupps_Suppliers");
        });

        modelBuilder.Entity<Region>(entity =>
        {
            entity.HasKey(e => e.RegionKey);

            entity.Property(e => e.RegionKey).ValueGeneratedNever();
            entity.Property(e => e.Comment)
                .HasMaxLength(300)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .IsFixedLength();
        });

        modelBuilder.Entity<Supplier>(entity =>
        {
            entity.HasKey(e => e.Suppkey);

            entity.Property(e => e.Suppkey).ValueGeneratedNever();
            entity.Property(e => e.AcctBal).HasColumnType("decimal(15, 2)");
            entity.Property(e => e.Address)
                .HasMaxLength(80)
                .IsUnicode(false);
            entity.Property(e => e.Comment)
                .HasMaxLength(202)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Phone)
                .HasMaxLength(30)
                .IsUnicode(false)
                .IsFixedLength();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
