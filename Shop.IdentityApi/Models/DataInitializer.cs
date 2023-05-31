using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Shop.IdentityApi.Models
{
    public static class DataInitializer
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            var adminId = "2288a9b4-35ee-4c13-b863-36184e701e0a";
            var firstUserId = "5eb5d348-b220-4148-8f9b-570de6262aa8";
            var secondUserId = "3758bb9b-3ad6-457c-9ff5-c88f338c7d48";
            var thirdUserId = "056096da-3246-40a7-af6f-726f5f4a74ee";
            
            var adminUser = new IdentityUser
            {
                Id = adminId,
                UserName = "admin@gmail.com",
                NormalizedUserName = "admin@gmail.com".ToUpper(),
                Email = "admin@gmail.com",
                NormalizedEmail = "admin@gmail.com".ToUpper(),
            };
            var firstUser = new IdentityUser
            {
                Id = firstUserId,
                UserName = "user1@gmail.com",
                NormalizedUserName = "user1@gmail.com".ToUpper(),
                Email = "user1@gmail.com",
                NormalizedEmail = "user1@gmail.com".ToUpper()
            };
            var secondUser = new IdentityUser
            {
                Id = secondUserId,
                UserName = "user2@gmail.com",
                NormalizedUserName = "user2@gmail.com".ToUpper(),
                Email = "user2@gmail.com",
                NormalizedEmail = "user2@gmail.com".ToUpper()
            };
            var thirdUser = new IdentityUser
            {
                Id = thirdUserId,
                UserName = "user3@gmail.com",
                NormalizedUserName = "user3@gmail.com".ToUpper(),
                Email = "user3@gmail.com",
                NormalizedEmail = "user3@gmail.com".ToUpper()
            };

            var passwordHasher = new PasswordHasher<IdentityUser>();
            adminUser.PasswordHash = passwordHasher.HashPassword(adminUser, "admin-123");
            firstUser.PasswordHash = passwordHasher.HashPassword(firstUser, "123456qw");
            secondUser.PasswordHash = passwordHasher.HashPassword(secondUser, "33N2vm");
            thirdUser.PasswordHash = passwordHasher.HashPassword(thirdUser, "AVA4uJ");

            modelBuilder.Entity<IdentityUser>().HasData(adminUser, firstUser, secondUser, thirdUser);

            var adminRoleId = "e1110812-5f76-4889-93a7-b4c677c2d8dd";
            var userRoleId = "beea0094-0cde-4f04-812b-98c02f4f8e27";
            var adminRole = "Admin";
            var userRole = "User";
            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole { Id = adminRoleId, Name = adminRole, NormalizedName = adminRole.ToUpper() },
                new IdentityRole { Id = userRoleId, Name = userRole, NormalizedName = userRole.ToUpper() }
            );

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string> { RoleId = adminRoleId, UserId = adminId },
                new IdentityUserRole<string> { RoleId = userRoleId, UserId = firstUserId },
                new IdentityUserRole<string> { RoleId = userRoleId, UserId = secondUserId },
                new IdentityUserRole<string> { RoleId = userRoleId, UserId = thirdUserId }
            );
        }
    }
}
