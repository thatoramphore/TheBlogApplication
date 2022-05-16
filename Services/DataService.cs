using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using TheBlogApplication.Data;
using Microsoft.AspNetCore.Identity;
using TheBlogApplication.Enums;
using TheBlogApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace TheBlogApplication.Services
{
    public class DataService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<IdentityUser> _userManager;

        //constructor injection
        public DataService(ApplicationDbContext dbContext,
                           RoleManager<IdentityRole> roleManager,
                           UserManager<IdentityUser> userManager)
        {
            this._dbContext = dbContext;
            this._roleManager = roleManager;
            this._userManager = userManager;
        }

        public async Task ManagerDataAsync()
        {
            //Create the DB from the Migrations
            await _dbContext.Database.MigrateAsync();

            //Task 1: seed roles in DB
            await SeedRolesAsync();

            //Task 2: seed users in DB
            await SeedUsersAsync();
        }

        private async Task SeedRolesAsync()
        {
            //if roles exist in DB, do nothing
            if (_dbContext.Roles.Any()) return;
            //otherwise create roles
            foreach (var role in Enum.GetNames(typeof(BlogRole)))
            {
                //roleManager for creating roles
                await _roleManager.CreateAsync(new IdentityRole(role));
            }
        }

        private async Task SeedUsersAsync()
        {
            //if users exist in DB, do nothing
            if (_dbContext.Users.Any()) return;

            //ADMINISTRATOR
            //Step 1:Create a new instance of BlogUser
            var adminUser = new BlogUser()
            {
                Email = "r2.thato@gmail.com",
                UserName = "r2thato@gmail.com",
                FirstName = "Thato",
                LastName = "Ramphore",
                PhoneNumber = "0123456789",
                EmailConfirmed = true
            };

            //Step 2:Use the UserManager to create a new user that is defined by adminUser
            await _userManager.CreateAsync(adminUser, "Abc&123!");

            //Step 3: Add this new user to the Administrator role
            await _userManager.AddToRoleAsync(adminUser, BlogRole.Administrator.ToString());

            //MODERATOR
            //Step 1:Create a new instance of BlogUser
            var modUser = new BlogUser()
            {
                Email = "altonthato64@gmail.com",
                UserName = "altonthato64@gmail.com",
                FirstName = "Alton",
                LastName = "Thato",
                PhoneNumber = "0987654321",
                EmailConfirmed = true
            };

            //Step 2:Use the UserManager to create a new user that is defined by adminUser
            await _userManager.CreateAsync(modUser, "Abc&123!");

            //Step 3: Add this new user to the Administrator role
            await _userManager.AddToRoleAsync(modUser, BlogRole.Moderator.ToString());
        }


    }
}
