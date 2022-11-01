using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WorkWithADONET
{
    public partial class CourseWorkContext : DbContext
    {
        public CourseWorkContext()
        {
        }

        public CourseWorkContext(DbContextOptions<CourseWorkContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Activity> Activities { get; set; } = null!;
        public virtual DbSet<Exercise> Exercises { get; set; } = null!;
        public virtual DbSet<Food> Foods { get; set; } = null!;
        public virtual DbSet<Meal> Meals { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=CourseWork;Username=postgres;Password=123", x => x.UseNodaTime());
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Activity>(entity =>
            {
                entity.ToTable("activity");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CalloriesPerMinute).HasColumnName("callories_per_minute");

                entity.Property(e => e.Name)
                    .HasMaxLength(30)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Exercise>(entity =>
            {
                entity.ToTable("exercise");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Activityid)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("activityid");

                entity.Property(e => e.Finish)
                    .HasColumnType("time without time zone")
                    .HasColumnName("finish");

                entity.Property(e => e.Start)
                    .HasColumnType("time without time zone")
                    .HasColumnName("start");

                entity.Property(e => e.Userid)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("userid");

                entity.HasOne(d => d.Activity)
                    .WithMany(p => p.Exercises)
                    .HasForeignKey(d => d.Activityid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("exercise_activityid_fkey");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Exercises)
                    .HasForeignKey(d => d.Userid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("exercise_userid_fkey");
            });

            modelBuilder.Entity<Food>(entity =>
            {
                entity.ToTable("food");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Callories).HasColumnName("callories");

                entity.Property(e => e.Carbohydates).HasColumnName("carbohydates");

                entity.Property(e => e.Fats).HasColumnName("fats");

                entity.Property(e => e.Name)
                    .HasMaxLength(30)
                    .HasColumnName("name");

                entity.Property(e => e.Proteins).HasColumnName("proteins");

                entity.Property(e => e.Weight)
                    .HasPrecision(9, 3)
                    .HasColumnName("weight");
            });

            modelBuilder.Entity<Meal>(entity =>
            {
                entity.ToTable("meal");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Foodid)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("foodid");

                entity.Property(e => e.Mealtime)
                    .HasColumnType("time without time zone")
                    .HasColumnName("mealtime");

                entity.Property(e => e.Userid)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("userid");

                entity.HasOne(d => d.Food)
                    .WithMany(p => p.Meals)
                    .HasForeignKey(d => d.Foodid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("meal_foodid_fkey");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Meals)
                    .HasForeignKey(d => d.Userid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("meal_userid_fkey");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("users");

                entity.HasIndex(e => e.Username, "users_username_key")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Age).HasColumnName("age");

                entity.Property(e => e.DateOfBirth).HasColumnName("date_of_birth");

                entity.Property(e => e.Gender)
                    .HasMaxLength(30)
                    .HasColumnName("gender");

                entity.Property(e => e.Height).HasColumnName("height");

                entity.Property(e => e.Name)
                    .HasMaxLength(30)
                    .HasColumnName("name");

                entity.Property(e => e.Username)
                    .HasMaxLength(30)
                    .HasColumnName("username");

                entity.Property(e => e.Weight)
                    .HasPrecision(9, 2)
                    .HasColumnName("weight");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
