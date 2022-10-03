using Booking.Domain.Entities.HotelAggregate;
using Booking.Domain.Entities.OrderAggregate;
using Booking.Domain.Entities.RoomAggregate;
using Booking.Domain.Entities.UserAggregate;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace Booking.Infrastructure.Context
{
    public class ApplicationDbContext : IdentityDbContext<AppUser,AppRole,int,IdentityUserClaim<int>,AppUserRole,IdentityUserLogin<int>,IdentityRoleClaim<int>,IdentityUserToken<int>> 
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {
        }

        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<HotelImages> HotelImages { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Hotel>().HasKey(i => i.Id);
            builder.Entity<Room>().HasKey(i => i.Id);
            builder.Entity<Order>().HasKey(i => i.Id);
            builder.Entity<HotelImages>().HasKey(I => I.Id);
            builder.Entity<Room>().Property(i => i.BedType).HasConversion<string>();
            builder.Entity<Room>().Property(i => i.RoomType).HasConversion<string>();

            builder.Entity<HotelImages>().ToTable("HotelImages");

            builder.Entity<Hotel>()
                .HasMany(i => i.Rooms)
                .WithOne(i => i.Hotel)
                .HasForeignKey(i => i.HotelId);

            builder.Entity<Room>()
                .HasMany(i => i.Orders)
                .WithOne(i => i.Room)
                .HasForeignKey(i => i.RoomId);

            builder.Entity<AppUser>()
                .HasMany(i => i.Orders)
                .WithOne(i => i.AppUser)
                .HasForeignKey(i => i.AppUserId);

            builder.Entity<AppUser>()
                .HasMany(i => i.AppUserRoles)
                .WithOne(i => i.AppUser)
                .HasForeignKey(i => i.UserId);
            builder.Entity<AppRole>()
                .HasMany(i => i.AppUserRoles)
                .WithOne(i => i.AppRole)
                .HasForeignKey(i => i.RoleId);

            builder.Entity<AppUser>()
                .HasMany(i => i.Hotels)
                .WithMany(i => i.Users);

            builder.Entity<Hotel>()
                .HasMany(i => i.Images)
                .WithOne(i => i.Hotel)
                .HasForeignKey(i => i.HotelId);

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

