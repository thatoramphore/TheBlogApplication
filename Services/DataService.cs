using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheBlogApplication.Data;
using TheBlogApplication.Enums;
using TheBlogApplication.Models;

namespace TheBlogApplication.Services
{
    public class DataService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<BlogUser> _userManager;

        public DataService(ApplicationDbContext dbContext,
                            UserManager<BlogUser> userManager, 
                            RoleManager<IdentityRole> roleManager)
        {
            _dbContext = dbContext;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task ManageDataAsync()
        {
            //Task 0: Create the DB from the Migrations
            await _dbContext.Database.MigrateAsync();

            //Task 1: Seed a few Roles into the system
            await SeedRolesAsync();

            //Task 2: Seed a few Usesr into the system
            await SeedUsersAsync();
        }

        private async Task SeedRolesAsync()
        {
            //if there are roles already in the system, do nothing
            if(_dbContext.Roles.Any()) { return; }

            //otherwise create a few roles
            foreach(var role in Enum.GetNames(typeof(BlogRole)))
            {
                //use the role manager to create roles
                await _roleManager.CreateAsync(new IdentityRole(role));

            }
        }

        private async Task SeedUsersAsync()
        {
            //if there are users already in the system, do nothing
            if (_dbContext.Users.Any()) { return; }

            //ADMIN
            //Step 1: create a new instance of BlogUser
            var adminUser = new BlogUser()
            {
                Email = "altonthato64@gmail.com",
                UserName = "altonthato64@gmail.com",
                FirstName = "Thato",
                LastName = "Alton",
                PhoneNumber = "(012) 345-6789",
                EmailConfirmed = true
            };

            //Step 2: Use the UserManager to create a new user that is defined by adminUser
            await _userManager.CreateAsync(adminUser, "Abc&123!");

            //Step 3: Add this new user to the Administrator role
            await _userManager.AddToRoleAsync(adminUser, BlogRole.Administrator.ToString());

            //MODERATOR
            //Step 1: create a new instance of BlogUser
            var modUser = new BlogUser()
            {
                Email = "r2.thato@gmail.com",
                UserName = "r2thato@gmail.com",
                FirstName = "Alton",
                LastName = "Thato",
                PhoneNumber = "(098) 765-4321",
                EmailConfirmed = true
            };

            //Step 2: Use the UserManager to create a new user that is defined by adminUser
            await _userManager.CreateAsync(modUser, "Abc&123!");

            //Step 3: Add this new user to the Moderator role
            await _userManager.AddToRoleAsync(modUser, BlogRole.Moderator.ToString());
        }
    }
}
