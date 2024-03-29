﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Tours
{
    public partial class ToursContext : DbContext
    {
        private string ConnectionString { get; set; }

        public ToursContext(string conn)
        {
            ConnectionString = conn;
        }

        public ToursContext(DbContextOptions<ToursContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Booking> Bookings { get; set; }
        public virtual DbSet<Busticket> Bustickets { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Food> Foods { get; set; }
        public virtual DbSet<Hotel> Hotels { get; set; }
        public virtual DbSet<Planeticket> Planetickets { get; set; }
        public virtual DbSet<Tour> Tours { get; set; }
        public virtual DbSet<Trainticket> Traintickets { get; set; }
        public virtual DbSet<Transfer> Transfers { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql(ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Russian_Russia.1251");

            modelBuilder.Entity<Booking>(entity =>
            {
                entity.HasKey(e => e.Customer)
                    .HasName("booking_pkey");

                entity.ToTable("booking");

                entity.Property(e => e.Customer)
                    .ValueGeneratedNever()
                    .HasColumnName("customer");

                entity.Property(e => e.Accesslevel).HasColumnName("accesslevel");

                entity.Property(e => e.Login)
                    .HasMaxLength(30)
                    .HasColumnName("login");

                entity.Property(e => e.Password)
                    .HasMaxLength(30)
                    .HasColumnName("password");

                entity.Property(e => e.Toursid).HasColumnName("toursid");

                entity.HasOne(d => d.CustomerNavigation)
                    .WithOne(p => p.Booking)
                    .HasForeignKey<Booking>(d => d.Customer)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_bu");
            });

            modelBuilder.Entity<Busticket>(entity =>
            {
                entity.HasKey(e => e.Bustid)
                    .HasName("busticket_pkey");

                entity.ToTable("busticket");

                entity.Property(e => e.Bustid)
                    .ValueGeneratedNever()
                    .HasColumnName("bustid");

                entity.Property(e => e.Arrivaltime)
                    .HasColumnType("time without time zone")
                    .HasColumnName("arrivaltime");

                entity.Property(e => e.Bus).HasColumnName("bus");

                entity.Property(e => e.Cityfrom).HasColumnName("cityfrom");

                entity.Property(e => e.Cityto).HasColumnName("cityto");

                entity.Property(e => e.Cost).HasColumnName("cost");

                entity.Property(e => e.Departuretime)
                    .HasColumnType("time without time zone")
                    .HasColumnName("departuretime");

                entity.Property(e => e.Luggage).HasColumnName("luggage");

                entity.Property(e => e.Seat).HasColumnName("seat");

                entity.HasOne(d => d.CityfromNavigation)
                    .WithMany(p => p.BusticketCityfromNavigations)
                    .HasForeignKey(d => d.Cityfrom)
                    .HasConstraintName("fk_bcf");

                entity.HasOne(d => d.CitytoNavigation)
                    .WithMany(p => p.BusticketCitytoNavigations)
                    .HasForeignKey(d => d.Cityto)
                    .HasConstraintName("fk_bct");
            });

            modelBuilder.Entity<City>(entity =>
            {
                entity.ToTable("city");

                entity.HasIndex(e => e.Name, "uk_c")
                    .IsUnique();

                entity.Property(e => e.Cityid)
                    .ValueGeneratedNever()
                    .HasColumnName("cityid");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Food>(entity =>
            {
                entity.ToTable("food");

                entity.Property(e => e.Foodid)
                    .ValueGeneratedNever()
                    .HasColumnName("foodid");

                entity.Property(e => e.Bar).HasColumnName("bar");

                entity.Property(e => e.Category)
                    .IsRequired()
                    .HasMaxLength(40)
                    .HasColumnName("category");

                entity.Property(e => e.Childrenmenu).HasColumnName("childrenmenu");

                entity.Property(e => e.Cost).HasColumnName("cost");

                entity.Property(e => e.Vegmenu).HasColumnName("vegmenu");
            });

            modelBuilder.Entity<Hotel>(entity =>
            {
                entity.ToTable("hotel");

                entity.HasIndex(e => e.Name, "uk_h")
                    .IsUnique();

                entity.Property(e => e.Hotelid)
                    .ValueGeneratedNever()
                    .HasColumnName("hotelid");

                entity.Property(e => e.City).HasColumnName("city");

                entity.Property(e => e.Class).HasColumnName("class");

                entity.Property(e => e.Cost).HasColumnName("cost");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("name");

                entity.Property(e => e.Swimpool).HasColumnName("swimpool");

                entity.Property(e => e.Type)
                    .HasMaxLength(30)
                    .HasColumnName("type");

                entity.HasOne(d => d.CityNavigation)
                    .WithMany(p => p.Hotels)
                    .HasForeignKey(d => d.City)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_hc");
            });

            modelBuilder.Entity<Planeticket>(entity =>
            {
                entity.HasKey(e => e.Planetid)
                    .HasName("planeticket_pkey");

                entity.ToTable("planeticket");

                entity.Property(e => e.Planetid)
                    .ValueGeneratedNever()
                    .HasColumnName("planetid");

                entity.Property(e => e.Cityfrom).HasColumnName("cityfrom");

                entity.Property(e => e.Cityto).HasColumnName("cityto");

                entity.Property(e => e.Class).HasColumnName("class");

                entity.Property(e => e.Cost).HasColumnName("cost");

                entity.Property(e => e.Departuretime)
                    .HasColumnType("time without time zone")
                    .HasColumnName("departuretime");

                entity.Property(e => e.Luggage).HasColumnName("luggage");

                entity.Property(e => e.Plane).HasColumnName("plane");

                entity.Property(e => e.Seat).HasColumnName("seat");

                entity.HasOne(d => d.CityfromNavigation)
                    .WithMany(p => p.PlaneticketCityfromNavigations)
                    .HasForeignKey(d => d.Cityfrom)
                    .HasConstraintName("fk_pcf");

                entity.HasOne(d => d.CitytoNavigation)
                    .WithMany(p => p.PlaneticketCitytoNavigations)
                    .HasForeignKey(d => d.Cityto)
                    .HasConstraintName("fk_pct");
            });

            modelBuilder.Entity<Tour>(entity =>
            {
                entity.ToTable("tour");

                entity.Property(e => e.Tourid)
                    .ValueGeneratedNever()
                    .HasColumnName("tourid");

                entity.Property(e => e.Cost).HasColumnName("cost");

                entity.Property(e => e.Datebegin)
                    .HasColumnType("date")
                    .HasColumnName("datebegin");

                entity.Property(e => e.Dateend)
                    .HasColumnType("date")
                    .HasColumnName("dateend");

                entity.Property(e => e.Food).HasColumnName("food");

                entity.Property(e => e.Hotel).HasColumnName("hotel");

                entity.Property(e => e.Transfer).HasColumnName("transfer");

                entity.HasOne(d => d.FoodNavigation)
                    .WithMany(p => p.Tours)
                    .HasForeignKey(d => d.Food)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_tf");

                entity.HasOne(d => d.HotelNavigation)
                    .WithMany(p => p.Tours)
                    .HasForeignKey(d => d.Hotel)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_th");

                entity.HasOne(d => d.TransferNavigation)
                    .WithMany(p => p.Tours)
                    .HasForeignKey(d => d.Transfer)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_tt");
            });

            modelBuilder.Entity<Trainticket>(entity =>
            {
                entity.HasKey(e => e.Traintid)
                    .HasName("trainticket_pkey");

                entity.ToTable("trainticket");

                entity.Property(e => e.Traintid)
                    .ValueGeneratedNever()
                    .HasColumnName("traintid");

                entity.Property(e => e.Arrivaltime)
                    .HasColumnType("time without time zone")
                    .HasColumnName("arrivaltime");

                entity.Property(e => e.Cityfrom).HasColumnName("cityfrom");

                entity.Property(e => e.Cityto).HasColumnName("cityto");

                entity.Property(e => e.Coach).HasColumnName("coach");

                entity.Property(e => e.Cost).HasColumnName("cost");

                entity.Property(e => e.Departuretime)
                    .HasColumnType("time without time zone")
                    .HasColumnName("departuretime");

                entity.Property(e => e.Linens).HasColumnName("linens");

                entity.Property(e => e.Seat).HasColumnName("seat");

                entity.Property(e => e.Train).HasColumnName("train");

                entity.HasOne(d => d.CityfromNavigation)
                    .WithMany(p => p.TrainticketCityfromNavigations)
                    .HasForeignKey(d => d.Cityfrom)
                    .HasConstraintName("fk_tcf");

                entity.HasOne(d => d.CitytoNavigation)
                    .WithMany(p => p.TrainticketCitytoNavigations)
                    .HasForeignKey(d => d.Cityto)
                    .HasConstraintName("fk_tct");
            });

            modelBuilder.Entity<Transfer>(entity =>
            {
                entity.ToTable("transfer");

                entity.Property(e => e.Transferid)
                    .ValueGeneratedNever()
                    .HasColumnName("transferid");

                entity.Property(e => e.Busticket).HasColumnName("busticket");

                entity.Property(e => e.Planeticket).HasColumnName("planeticket");

                entity.Property(e => e.Trainticket).HasColumnName("trainticket");

                entity.HasOne(d => d.BusticketNavigation)
                    .WithMany(p => p.Transfers)
                    .HasForeignKey(d => d.Busticket)
                    .HasConstraintName("fk_tb");

                entity.HasOne(d => d.PlaneticketNavigation)
                    .WithMany(p => p.Transfers)
                    .HasForeignKey(d => d.Planeticket)
                    .HasConstraintName("fk_tp");

                entity.HasOne(d => d.TrainticketNavigation)
                    .WithMany(p => p.Transfers)
                    .HasForeignKey(d => d.Trainticket)
                    .HasConstraintName("fk_tt");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("users");

                entity.Property(e => e.Userid)
                    .ValueGeneratedNever()
                    .HasColumnName("userid");

                entity.Property(e => e.Name)
                    .HasMaxLength(30)
                    .HasColumnName("name");

                entity.Property(e => e.Surname)
                    .HasMaxLength(30)
                    .HasColumnName("surname");

                entity.Property(e => e.Year).HasColumnName("year");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
