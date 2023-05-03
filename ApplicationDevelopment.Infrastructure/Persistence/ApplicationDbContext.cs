using ApplicationDevelopment.Application.Common.Interfaces;
using ApplicationDevelopment.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDevelopment.Infrastructure.Persistence
{
    public class ApplicationDbContext : IdentityDbContext<User,Role,string>, IApplicationDbContext
    {
        private readonly IDateTime _dateTime;
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IDateTime dateTime): base(options)
        {
            _dateTime = dateTime;
        }

    
        public DbSet<Car> Car { get; set; }
        public DbSet<CarRequest> CarRequest { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<DamageRequest> DamageRequest { get; set; }
        public DbSet<RepairBill> RepairBill { get; set; }
        public DbSet<Staff> Staff { get; set; }
        public DbSet<Offer> Offer { get; set; }
        public DbSet<UserRole> UserRole { get; set; }
        public DbSet<Address> Address { get; set; }
        //public DbSet<Admin> Admin{ get; set; }
        //public DbSet<Role> Role { get; set; }
        //public DbSet<User> User { get; set; }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            // Add custom logic here
            int result = await base.SaveChangesAsync(cancellationToken);
            return result;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);


  

            builder.Entity<Address>()
            .HasKey(a => a.Id);

            builder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.HasOne(e => e.User)
                    .WithMany()
                    .HasForeignKey(e => e.UserId)
                    .OnDelete(DeleteBehavior.Cascade);
            });
            builder.Entity<Staff>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.HasOne(e => e.User)
                    .WithMany()
                    .HasForeignKey(e => e.UserId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            builder.Entity<UserRole>()
            .HasKey(ur => new { ur.UserId, ur.RoleId });
            builder.Entity<UserRole>()
                .HasOne(ur => ur.User)
                .WithMany(u => u.UserRole)
                .HasForeignKey(ur => ur.UserId);

            builder.Entity<UserRole>()
                .HasOne(ur => ur.Role)
                .WithMany(r => r.UserRole)
                .HasForeignKey(ur => ur.RoleId);

            builder.Entity<Role>().HasData(
                new Role { Id = "admin", Name = "Admin", NormalizedName = "ADMIN" },
                new Role { Id = "customer", Name = "Customer", NormalizedName = "CUSTOMER" },
                new Role { Id = "staff", Name = "Staff", NormalizedName = "STAFF" }
                );

            
            // Seed admin user
            var hasher = new PasswordHasher<User>();
            var adminUser = new User
            {
                Id = "65908038-d81f-4aa6-81d4-54364852184c",
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                Email = "admin@example.com",
                NormalizedEmail = "ADMIN@EXAMPLE.COM",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "AdminPassword123#")
            };

            builder.Entity<User>().HasData(adminUser);

            // Assign admin role to admin user
            builder.Entity<UserRole>().HasData(new UserRole { UserId = adminUser.Id, RoleId = "admin" });
            builder.Entity<Admin>().HasData(new Admin { UserId = adminUser.Id });
        }
    }
}
