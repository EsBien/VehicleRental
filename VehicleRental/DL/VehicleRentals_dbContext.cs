using System;
using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace DL
{
    public partial class VehicleRentals_dbContext : DbContext
    {
        public VehicleRentals_dbContext()
        {
        }

        public VehicleRentals_dbContext(DbContextOptions<VehicleRentals_dbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CustomerTbl> CustomerTbls { get; set; }
        public virtual DbSet<DescVehicleTbl> DescVehicleTbls { get; set; }
        public virtual DbSet<DesignsTbl> DesignsTbls { get; set; }
        public virtual DbSet<OrdersTbl> OrdersTbls { get; set; }
        public virtual DbSet<Rating> Ratings { get; set; }
        public virtual DbSet<StationTbl> StationTbls { get; set; }
        public virtual DbSet<VehicleDesignsTbl> VehicleDesignsTbls { get; set; }
        public virtual DbSet<VehicleTypeTbl> VehicleTypeTbls { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=LAPTOP-ODKQSO4A;Database=VehicleRentals_db;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Hebrew_CI_AS");

            modelBuilder.Entity<CustomerTbl>(entity =>
            {
                entity.HasKey(e => e.Email)
                    .HasName("PK__Customer__DB43864A126208BF");

                entity.ToTable("Customer_tbl");

                entity.HasIndex(e => e.PasswordCust, "UQ__Customer__F6967CAE61B03791")
                    .IsUnique();

                entity.Property(e => e.Email)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.PasswordCust)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<DescVehicleTbl>(entity =>
            {
                entity.HasKey(e => e.IdVehicle)
                    .HasName("PK__DescVehi__64D74CC872498E9F");

                entity.ToTable("DescVehicle_tbl");

                entity.Property(e => e.Company)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PricePerDay).HasColumnType("money");

                entity.Property(e => e.PricePerHour).HasColumnType("money");

                entity.Property(e => e.Production).HasColumnType("datetime");

                entity.Property(e => e.TrunckSize)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdStationNavigation)
                    .WithMany(p => p.DescVehicleTbls)
                    .HasForeignKey(d => d.IdStation)
                    .HasConstraintName("FK__DescVehic__IdSta__619B8048");

                entity.HasOne(d => d.IdVehicleTypeNavigation)
                    .WithMany(p => p.DescVehicleTbls)
                    .HasForeignKey(d => d.IdVehicleType)
                    .HasConstraintName("FK__DescVehic__IdVeh__60A75C0F");
            });

            modelBuilder.Entity<DesignsTbl>(entity =>
            {
                entity.HasKey(e => e.IdDesign)
                    .HasName("PK__Designs___D3386497E6566F22");

                entity.ToTable("Designs_tbl");

                entity.Property(e => e.DescDesign)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.DesignPrice).HasColumnType("money");
            });

            modelBuilder.Entity<OrdersTbl>(entity =>
            {
                entity.HasKey(e => e.IdOrder)
                    .HasName("PK__Orders_t__C38F30092FC0AD1D");

                entity.ToTable("Orders_tbl");

                entity.Property(e => e.IdCustomer)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.OrderDate).HasColumnType("datetime");

                entity.Property(e => e.OrderHour).HasColumnType("datetime");

                entity.Property(e => e.ReturnDate).HasColumnType("datetime");

                entity.Property(e => e.ReturnHour).HasColumnType("datetime");

                entity.HasOne(d => d.IdCustomerNavigation)
                    .WithMany(p => p.OrdersTbls)
                    .HasForeignKey(d => d.IdCustomer)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Orders_tb__IdCus__6B24EA82");

                entity.HasOne(d => d.IdDesignNavigation)
                    .WithMany(p => p.OrdersTbls)
                    .HasForeignKey(d => d.IdDesign)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Orders_tb__IdDes__6A30C649");

                entity.HasOne(d => d.IdStationNavigation)
                    .WithMany(p => p.OrdersTbls)
                    .HasForeignKey(d => d.IdStation)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Orders_tb__IdSta__68487DD7");

                entity.HasOne(d => d.IdVehicleNavigation)
                    .WithMany(p => p.OrdersTbls)
                    .HasForeignKey(d => d.IdVehicle)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Orders_tb__IdVeh__693CA210");
            });

            modelBuilder.Entity<Rating>(entity =>
            {
                entity.ToTable("RATING");

                entity.Property(e => e.RatingId).HasColumnName("RATING_ID");

                entity.Property(e => e.Host)
                    .HasMaxLength(50)
                    .HasColumnName("HOST");

                entity.Property(e => e.Method)
                    .HasMaxLength(10)
                    .HasColumnName("METHOD")
                    .IsFixedLength(true);

                entity.Property(e => e.Path)
                    .HasMaxLength(50)
                    .HasColumnName("PATH");

                entity.Property(e => e.RecordDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Record_Date");

                entity.Property(e => e.Referer)
                    .HasMaxLength(100)
                    .HasColumnName("REFERER");

                entity.Property(e => e.UserAgent).HasColumnName("USER_AGENT");
            });

            modelBuilder.Entity<StationTbl>(entity =>
            {
                entity.HasKey(e => e.IdStation)
                    .HasName("PK__Station___FBB9BA0A2DA3CA7A");

                entity.ToTable("Station_tbl");

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Neighborhood)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Street)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<VehicleDesignsTbl>(entity =>
            {
                entity.HasKey(e => e.IdVehicleDesign)
                    .HasName("PK__VehicleD__EC1573170A7153A0");

                entity.ToTable("VehicleDesigns_tbl");

                entity.HasIndex(e => e.IdDesign, "IX_VehicleDesigns_tbl_IdDesign");

                entity.HasIndex(e => e.IdVehicleType, "IX_VehicleDesigns_tbl_IdVehicleType");

                entity.HasOne(d => d.IdDesignNavigation)
                    .WithMany(p => p.VehicleDesignsTbls)
                    .HasForeignKey(d => d.IdDesign)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__VehicleDe__IdDes__47DBAE45");

                entity.HasOne(d => d.IdVehicleTypeNavigation)
                    .WithMany(p => p.VehicleDesignsTbls)
                    .HasForeignKey(d => d.IdVehicleType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__VehicleDe__IdVeh__48CFD27E");
            });

            modelBuilder.Entity<VehicleTypeTbl>(entity =>
            {
                entity.HasKey(e => e.IdVehicleType)
                    .HasName("PK__VehicleT__4CC6297403FBA570");

                entity.ToTable("VehicleType_tbl");

                entity.Property(e => e.VehicleType)
                    .IsRequired()
                    .HasMaxLength(1000)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
