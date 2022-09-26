using Booking.Domain.Entities.HotelAggregate;
using Booking.Domain.Entities.OrderAggregate;
using Booking.Domain.Entities.RoomAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace Booking.Infrastructure.Context
{
    public class ApplicationDbContext : DbContext 
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {
        }

        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Hotel>().HasKey(i => i.Id);
            builder.Entity<Room>().HasKey(i => i.Id);
            builder.Entity<Order>().HasKey(i => i.Id);
            builder.Entity<Room>().Property(i => i.BedType).HasConversion<string>();
            builder.Entity<Room>().Property(i => i.RoomType).HasConversion<string>();

            builder.Entity<Hotel>()
                .HasMany(i => i.Rooms)
                .WithOne(i => i.Hotel)
                .HasForeignKey(i => i.HotelId);

            builder.Entity<Room>()
                .HasMany(i => i.Orders)
                .WithOne(i => i.Room)
                .HasForeignKey(i => i.RoomId);

        }



    }
    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var option = new DbContextOptionsBuilder<ApplicationDbContext>().UseNpgsql("Server=localhost;Port=5433;User Id=postgres; Password=1234;  Database=Booking;");
            return new ApplicationDbContext(option.Options);
        }
    }

}

