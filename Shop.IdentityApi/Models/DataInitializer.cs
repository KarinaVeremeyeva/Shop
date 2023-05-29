using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Shop.IdentityApi.Models
{
    public static class DataInitializer
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            var adminId = "2288a9b4-35ee-4c13-b863-36184e701e0a";
            var userId = "5eb5d348-b220-4148-8f9b-570de6262aa8";
            var adminUser = new IdentityUser
            {
                Id = adminId,
                UserName = "admin@gmail.com",
                NormalizedUserName = "admin@gmail.com".ToUpper(),
                Email = "admin@gmail.com",
                NormalizedEmail = "admin@gmail.com".ToUpper(),
            };
            var user = new IdentityUser
            {
                Id = userId,
                UserName = "user1@gmail.com",
                NormalizedUserName = "user1@gmail.com".ToUpper(),
                Email = "user1@gmail.com",
                NormalizedEmail = "user1@gmail.com".ToUpper()
            };

            var passwordHasher = new PasswordHasher<IdentityUser>();
            adminUser.PasswordHash = passwordHasher.HashPassword(adminUser, "admin-123");
            user.PasswordHash = passwordHasher.HashPassword(user, "123456qw");
           
            modelBuilder.Entity<IdentityUser>().HasData(adminUser, user);

            var adminRoleId = "e1110812-5f76-4889-93a7-b4c677c2d8dd";
            var userRoleId = "beea0094-0cde-4f04-812b-98c02f4f8e27";
            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole { Id = adminRoleId, Name = "Admin", NormalizedName = "Admin".ToUpper() },
                new IdentityRole { Id = userRoleId, Name = "User", NormalizedName = "User".ToUpper() }
            );

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string> { RoleId = adminRoleId, UserId = adminId },
                new IdentityUserRole<string> { RoleId = userRoleId, UserId = userId }
            );
        }
    }
}
