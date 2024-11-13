using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;
using WebApi_Callidryas.Models;

namespace WebApi_Callidryas.Data;

public partial class CallidryasDbContext : DbContext
{
    public CallidryasDbContext()
    {
    }

    public CallidryasDbContext(DbContextOptions<CallidryasDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Driver> Drivers { get; set; }

    public virtual DbSet<DriverVehicleCheck> DriverVehicleChecks { get; set; }

    public virtual DbSet<Micro> Micros { get; set; }

//     protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
// #warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
//         => optionsBuilder.UseMySql("server=bmhrldfxeispmyvmmhrs-mysql.services.clever-cloud.com;database=bmhrldfxeispmyvmmhrs;user=uiogqkhtoifrqfhu;password=m6ueJB8Ev3tYZhSqQLDc", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.15-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8_general_ci")
            .HasCharSet("utf8");

        modelBuilder.Entity<Driver>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("Driver");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.DriverLastName).HasMaxLength(100);
            entity.Property(e => e.DriverName).HasMaxLength(100);
        });

        modelBuilder.Entity<DriverVehicleCheck>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("DriverVehicleCheck");

            entity.HasIndex(e => e.DriverId, "DriverID");

            entity.HasIndex(e => e.MicroId, "MicroID");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.BodyCondition).HasDefaultValueSql("'0'");
            entity.Property(e => e.BrakeFluidLevel).HasDefaultValueSql("'0'");
            entity.Property(e => e.Clarkson).HasDefaultValueSql("'0'");
            entity.Property(e => e.Cleanliness).HasDefaultValueSql("'0'");
            entity.Property(e => e.DriverId)
                .HasColumnType("int(11)")
                .HasColumnName("DriverID");
            entity.Property(e => e.EngineOilLevel).HasDefaultValueSql("'0'");
            entity.Property(e => e.FireExtinguisher).HasDefaultValueSql("'0'");
            entity.Property(e => e.FirstAidKit).HasDefaultValueSql("'0'");
            entity.Property(e => e.HydraulicJack).HasDefaultValueSql("'0'");
            entity.Property(e => e.InitialMileage).HasColumnType("int(11)");
            entity.Property(e => e.JackRod).HasDefaultValueSql("'0'");
            entity.Property(e => e.MicroId)
                .HasColumnType("int(11)")
                .HasColumnName("MicroID");
            entity.Property(e => e.RearviewMirrors).HasDefaultValueSql("'0'");
            entity.Property(e => e.ReflectiveVest).HasDefaultValueSql("'0'");
            entity.Property(e => e.Remarks).HasColumnType("text");
            entity.Property(e => e.ReviewDate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp");
            entity.Property(e => e.SteeringOilLevel).HasDefaultValueSql("'0'");
            entity.Property(e => e.TirePressure).HasDefaultValueSql("'0'");
            entity.Property(e => e.Trash).HasDefaultValueSql("'0'");
            entity.Property(e => e.WaterLevel).HasDefaultValueSql("'0'");

            entity.HasOne(d => d.Driver).WithMany(p => p.DriverVehicleChecks)
                .HasForeignKey(d => d.DriverId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("DriverVehicleCheck_ibfk_1");

            entity.HasOne(d => d.Micro).WithMany(p => p.DriverVehicleChecks)
                .HasForeignKey(d => d.MicroId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("DriverVehicleCheck_ibfk_2");
        });

        modelBuilder.Entity<Micro>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("Micro");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.Model).HasMaxLength(100);
            entity.Property(e => e.PlateNumber).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
