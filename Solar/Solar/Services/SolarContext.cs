﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

public partial class SolarContext : DbContext
{
    public SolarContext()
    {
    }

    public SolarContext(DbContextOptions<SolarContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Assembly> Assemblies { get; set; }

    public virtual DbSet<Battery> Batteries { get; set; }

    public virtual DbSet<BatteryRequest> BatteryRequests { get; set; }

    public virtual DbSet<ConsumptionCategory> ConsumptionCategories { get; set; }

    public virtual DbSet<Dimensioning> Dimensionings { get; set; }

    public virtual DbSet<DimensioningConsumption> DimensioningConsumptions { get; set; }

    public virtual DbSet<DimensioningkWp> DimensioningkWps { get; set; }

    public virtual DbSet<Installer> Installers { get; set; }

    public virtual DbSet<Project> Projects { get; set; }

    public virtual DbSet<RoofMaterial> RoofMaterials { get; set; }

    public virtual DbSet<RoofType> RoofTypes { get; set; }

    public virtual DbSet<Status> Statuses { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Solar;Integrated Security=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Assembly>(entity =>
        {
            entity.HasKey(e => e.ProjectId).HasName("PK__Assembly__761ABED0CEEED6D9");

            entity.Property(e => e.ProjectId).ValueGeneratedNever();

            entity.HasOne(d => d.Project).WithOne(p => p.Assembly)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Assembly__Projec__36B12243");

            entity.HasOne(d => d.RoofMaterial).WithMany(p => p.Assemblies).HasConstraintName("FK__Assembly__RoofMa__38996AB5");

            entity.HasOne(d => d.RoofType).WithMany(p => p.Assemblies).HasConstraintName("FK__Assembly__RoofTy__37A5467C");
        });

        modelBuilder.Entity<Battery>(entity =>
        {
            entity.HasKey(e => e.ProjectId).HasName("PK__Battery__761ABED09429AC91");

            entity.Property(e => e.ProjectId).ValueGeneratedNever();

            entity.HasOne(d => d.Project).WithOne(p => p.Battery)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Battery__Project__3B75D760");
        });

        modelBuilder.Entity<BatteryRequest>(entity =>
        {
            entity.HasKey(e => e.ProjectId).HasName("PK__BatteryR__761ABED05B8AEFEC");

            entity.Property(e => e.ProjectId).ValueGeneratedNever();

            entity.HasOne(d => d.Project).WithOne(p => p.BatteryRequest)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__BatteryRe__Proje__3E52440B");
        });

        modelBuilder.Entity<ConsumptionCategory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Consumpt__3214EC27B47603B1");
        });

        modelBuilder.Entity<Dimensioning>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Dimensio__3214EC273718FF41");
        });

        modelBuilder.Entity<DimensioningConsumption>(entity =>
        {
            entity.HasKey(e => e.ProjectId).HasName("PK__Dimensio__761ABED02CECD789");

            entity.Property(e => e.ProjectId).ValueGeneratedNever();

            entity.HasOne(d => d.Category).WithMany(p => p.DimensioningConsumptions).HasConstraintName("FK__Dimension__Categ__46E78A0C");

            entity.HasOne(d => d.Project).WithOne(p => p.DimensioningConsumption)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Dimension__Proje__45F365D3");
        });

        modelBuilder.Entity<DimensioningkWp>(entity =>
        {
            entity.HasKey(e => e.ProjectId).HasName("PK__Dimensio__761ABED02D79C273");

            entity.Property(e => e.ProjectId).ValueGeneratedNever();

            entity.HasOne(d => d.Project).WithOne(p => p.DimensioningkWp)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Dimension__Proje__412EB0B6");
        });

        modelBuilder.Entity<Installer>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Installe__1788CCACF4DFB6E1");

            entity.Property(e => e.UserId).ValueGeneratedNever();
            entity.Property(e => e.PhoneNumber).IsFixedLength();

            entity.HasOne(d => d.User).WithOne(p => p.Installer)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Installer__UserI__267ABA7A");
        });

        modelBuilder.Entity<Project>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Project__3214EC279A996EA0");

            entity.Property(e => e.PhoneNumber).IsFixedLength();

            entity.HasOne(d => d.Dimensioning).WithMany(p => p.Projects).HasConstraintName("FK__Project__Dimensi__2F10007B");

            entity.HasOne(d => d.Status).WithMany(p => p.Projects).HasConstraintName("FK__Project__StatusI__2D27B809");

            entity.HasOne(d => d.User).WithMany(p => p.Projects).HasConstraintName("FK__Project__UserID__2E1BDC42");
        });

        modelBuilder.Entity<RoofMaterial>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__RoofMate__3214EC279360088E");

            entity.HasOne(d => d.RoofType).WithMany(p => p.RoofMaterials).HasConstraintName("FK__RoofMater__RoofT__33D4B598");
        });

        modelBuilder.Entity<RoofType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__RoofType__3214EC27022E148D");
        });

        modelBuilder.Entity<Status>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Status__3214EC277D9A71AA");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Users__3214EC2762108C75");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}