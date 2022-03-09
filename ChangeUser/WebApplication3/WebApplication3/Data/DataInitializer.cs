using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication3.DataAccsessLayer;
using WebApplication3.Models.Home;

namespace WebApplication3.Data
{
    public class DataInitializer
    {
        private readonly AppDbContext AppDbContext;
        private readonly UserManager<User> UserManager;
        private readonly RoleManager<IdentityRole> RoleManager;
        public DataInitializer(AppDbContext appDbContext, UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            AppDbContext = appDbContext;
            UserManager = userManager;
            RoleManager = roleManager;
        }
        public async Task SeedDataAsync()
        {
            await AppDbContext.Database.MigrateAsync();

            var roles = new List<string>
            {
                RoleConstans.AdminRole,
                RoleConstans.ModeratorRole,
                RoleConstans.UserRole
            };
            foreach (var role in roles)
            {
                if (await RoleManager.RoleExistsAsync(role)) 
                continue;
                await RoleManager.CreateAsync(new IdentityRole(role));
            }

            var Admin = new User
            {
                FullName = "Idris Jafarzade",
                UserName = "Idris",
                Email = "Idrisjj@code.edu.az"
            };
            var Moderator = new User
            {
                FullName = "Alisimran Mammadli",
                UserName = "Chiko",
                Email = "alisimranem@code.edu.az"
            };
            if (await UserManager.FindByNameAsync(Admin.UserName) != null && await UserManager.FindByNameAsync(Moderator.UserName) != null) 
            return;

            await UserManager.CreateAsync(Admin, "8858085@Ii");
            await UserManager.CreateAsync(Moderator, "2302006@Ii");
            await UserManager.AddToRoleAsync(Admin, RoleConstans.AdminRole);
            await UserManager.AddToRoleAsync(Moderator, RoleConstans.ModeratorRole);
        }


    }
}
