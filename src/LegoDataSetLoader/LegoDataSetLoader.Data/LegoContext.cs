using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using LegoDataSetLoader.Data.Models;

namespace LegoDataSetLoader.Data
{
    public partial class LegoContext : DbContext
    {
        public LegoContext()
        {
        }

        public LegoContext(DbContextOptions<LegoContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Color> Colors { get; set; } = null!;
        public virtual DbSet<Element> Elements { get; set; } = null!;
        public virtual DbSet<Inventory> Inventories { get; set; } = null!;
        public virtual DbSet<InventoryMinifig> InventoryMinifigs { get; set; } = null!;
        public virtual DbSet<InventoryPart> InventoryParts { get; set; } = null!;
        public virtual DbSet<InventorySet> InventorySets { get; set; } = null!;
        public virtual DbSet<Minifig> Minifigs { get; set; } = null!;
        public virtual DbSet<Part> Parts { get; set; } = null!;
        public virtual DbSet<PartCategory> PartCategories { get; set; } = null!;
        public virtual DbSet<PartRelationship> PartRelationships { get; set; } = null!;
        public virtual DbSet<Set> Sets { get; set; } = null!;
        public virtual DbSet<Theme> Themes { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Color>(entity =>
            {
                entity.HasKey(e => e.ColorId);

                entity.Property(e => e.ColorId).ValueGeneratedNever();

                entity.Property(e => e.ColorName)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Rgb)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("RGB")
                    .IsFixedLength();
            });

            modelBuilder.Entity<Element>(entity =>
            {
                entity.HasKey(e => e.ElementId);

                entity.Property(e => e.ElementId)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.PartNumber)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.Color)
                    .WithMany(p => p.Elements)
                    .HasForeignKey(d => d.ColorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Elements_Colors");

                entity.HasOne(d => d.PartNumberNavigation)
                    .WithMany(p => p.Elements)
                    .HasForeignKey(d => d.PartNumber)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Elements_Parts");
            });

            modelBuilder.Entity<Inventory>(entity =>
            {
                entity.HasKey(e => e.InventoryId);

                entity.Property(e => e.InventoryId).ValueGeneratedNever();

                entity.Property(e => e.SetNumber)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.SetNumberNavigation)
                    .WithMany(p => p.Inventories)
                    .HasForeignKey(d => d.SetNumber)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Inventories_Sets");
            });

            modelBuilder.Entity<InventoryMinifig>(entity =>
            {
                entity.HasKey(e => new { e.MinifigNumber, e.InventoryId });

                entity.Property(e => e.MinifigNumber)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.Inventory)
                    .WithMany()
                    .HasForeignKey(d => d.InventoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_InventoryMinifigs_Inventories");

                entity.HasOne(d => d.MinifigNumberNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.MinifigNumber)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_InventoryMinifigs_Minifigs");
            });

            modelBuilder.Entity<InventoryPart>(entity =>
            {
                entity.HasKey(e => new { e.InventoryId, e.PartNumber, e.ColorId, e.IsSpare });

                entity.Property(e => e.PartNumber)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.Color)
                    .WithMany()
                    .HasForeignKey(d => d.ColorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_InventoryParts_Colors");

                entity.HasOne(d => d.Inventory)
                    .WithMany()
                    .HasForeignKey(d => d.InventoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_InventoryParts_Inventory");

                entity.HasOne(d => d.PartNumberNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.PartNumber)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_InventoryParts_Parts");
            });

            modelBuilder.Entity<InventorySet>(entity =>
            {
                entity.HasKey(e => new { e.InventoryId, e.SetNumber });

                entity.Property(e => e.SetNumber)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.Inventory)
                    .WithMany()
                    .HasForeignKey(d => d.InventoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_InventorySets_Inventories");

                entity.HasOne(d => d.SetNumberNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.SetNumber)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_InventorySets_Sets");
            });

            modelBuilder.Entity<Minifig>(entity =>
            {
                entity.HasKey(e => e.MinifigNumber);

                entity.Property(e => e.MinifigNumber)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.MinifigName)
                    .HasMaxLength(256)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Part>(entity =>
            {
                entity.HasKey(e => e.PartNumber);

                entity.Property(e => e.PartNumber)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PartName)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.HasOne(d => d.PartCategory)
                    .WithMany(p => p.Parts)
                    .HasForeignKey(d => d.PartCategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Parts_PartCategories");
                
                entity.Property(e => e.Material)
                    .HasMaxLength(250)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PartCategory>(entity =>
            {
                entity.HasKey(e => e.PartCategoryId);

                entity.Property(e => e.PartCategoryId).ValueGeneratedNever();

                entity.Property(e => e.PartCategoryName)
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PartRelationship>(entity =>
            {
                entity.HasKey(e => new { e.ParentPartNumber, e.ChildPartNumber, e.RelationshipType });

                entity.Property(e => e.ChildPartNumber)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ParentPartNumber)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.RelationshipType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.HasOne(d => d.ChildPartNumberNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.ChildPartNumber)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PartRelationships_PartsChild");

                entity.HasOne(d => d.ParentPartNumberNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.ParentPartNumber)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PartRelationships_PartsParent");
            });

            modelBuilder.Entity<Set>(entity =>
            {
                entity.HasKey(e => e.SetNumber);

                entity.Property(e => e.SetNumber)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ReleaseYear)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.SetName)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.HasOne(d => d.Theme)
                    .WithMany(p => p.Sets)
                    .HasForeignKey(d => d.ThemeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Sets_Themes");
            });

            modelBuilder.Entity<Theme>(entity =>
            {
                entity.HasKey(e => e.ThemeId);

                entity.Property(e => e.ThemeId).ValueGeneratedNever();

                entity.Property(e => e.ThemeName)
                    .HasMaxLength(42)
                    .IsUnicode(false);

                entity.HasOne(d => d.ParentTheme)
                    .WithMany(p => p.InverseParentTheme)
                    .HasForeignKey(d => d.ParentThemeId)
                    .HasConstraintName("FK_Themes_ParentTheme");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
