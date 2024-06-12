﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EgyDynamics2.Models;

public partial class EgyDynamicsContext : DbContext
{
    public EgyDynamicsContext()
    {
    }

    public EgyDynamicsContext(DbContextOptions<EgyDynamicsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<العميل> العميلs { get; set; }

    public virtual DbSet<الموظف> الموظفs { get; set; }

    public virtual DbSet<مكالمهالعميل> مكالمهالعميلs { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=EgyDynamics;Integrated Security=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<العميل>(entity =>
        {
            entity.HasKey(e => e.كودالعميل).HasName("PK__العميل__C0A8EB72117F7C6F");

            entity.HasOne(d => d.اخرتعديلNavigation).WithMany(p => p.العميلاخرتعديلNavigations).HasConstraintName("FK__العميل__اخر تعدي__3A81B327");

            entity.HasOne(d => d.ادخالبواسطةNavigation).WithMany(p => p.العميلادخالبواسطةNavigations).HasConstraintName("FK__العميل__ادخال بو__398D8EEE");
        });

        modelBuilder.Entity<الموظف>(entity =>
        {
            entity.HasKey(e => e.كودالموظف).HasName("PK__الموظف__BEEAEAD9DB20784F");
        });

        modelBuilder.Entity<مكالمهالعميل>(entity =>
        {
            entity.HasKey(e => e.كودمكالمةالعميل).HasName("PK__مكالمه ا__FC46051E241B92C5");

            entity.HasOne(d => d.اخرتعديلNavigation).WithMany(p => p.مكالمهالعميلاخرتعديلNavigations).HasConstraintName("FK__مكالمه ال__اخر ت__3F466844");

            entity.HasOne(d => d.ادخالبواسطهNavigation).WithMany(p => p.مكالمهالعميلادخالبواسطهNavigations).HasConstraintName("FK__مكالمه ال__ادخال__3E52440B");

            entity.HasOne(d => d.الموظفNavigation).WithMany(p => p.مكالمهالعميلالموظفNavigations).HasConstraintName("FK__مكالمه ال__الموظ__3D5E1FD2");

            entity.HasOne(d => d.كودالعميلNavigation).WithMany(p => p.مكالمهالعميلs).HasConstraintName("FK__مكالمه ال__كود ا__403A8C7D");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}