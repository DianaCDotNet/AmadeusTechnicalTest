using AmadeusWebAPI.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AmadeusWebAPI.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Airline> Airlines { get; set; }


        // datos cquemados para usuarios
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var roleId = Guid.NewGuid().ToString();
            builder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = roleId,
                Name = "Admin",
                NormalizedName = "ADMIN"
            });

            // Crear usuario Admin
            var userId = Guid.NewGuid().ToString();
            var hasher = new PasswordHasher<IdentityUser>();
            var adminUser = new IdentityUser
            {
                Id = userId,
                UserName = "admin@as.com",
                NormalizedUserName = "ADMIN@AS.COM",
                Email = "admin@AS.com",
                NormalizedEmail = "ADMIN@AS.COM",
                EmailConfirmed = true,
                SecurityStamp = string.Empty
            };
            adminUser.PasswordHash = hasher.HashPassword(adminUser, "-Admin-123.");

            builder.Entity<IdentityUser>().HasData(adminUser);

            // Relacionar usuario con rol
            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = roleId,
                UserId = userId
            });
        }
    }

}
