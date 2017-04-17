﻿namespace DoAn.Data.Migrations
{
    using Model.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Collections.Generic;
    using DoAn.Model.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<DoAn.Data.DoAnDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DoAn.Data.DoAnDbContext context)
        {
            //CreateUser(context);
            CreateControlPanel(context);
            CreateCustomImage(context);
            CreateCustomHeader(context);

        }

        private void CreateUser(DoAnDbContext context)
        {
            var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new DoAnDbContext()));

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new DoAnDbContext()));

            var user = new ApplicationUser()
            {
                UserName = "admin",
                Email = "admin@gmail.com",
                EmailConfirmed = true,
                BirthDay = DateTime.Now,
                FullName = "admin"
            };

            manager.Create(user, "123456$");

            if (!roleManager.Roles.Any())
            {
                roleManager.Create(new IdentityRole { Name = "Admin" });
                roleManager.Create(new IdentityRole { Name = "User" });
            }

            var adminUser = manager.FindByEmail("admin@gmail.com");

            manager.AddToRoles(adminUser.Id, new string[] { "Admin", "User" });
        }

        private void CreateControlPanel(DoAnDbContext context)
        {
            if(context.Controlpanels.Count() == 0)
            {
                List<ControlPanel> listControlPanel = new List<ControlPanel>
                {
                    new ControlPanel() { Name = "Tổ chức", Status = false },
                    new ControlPanel() {Name = "Quyên góp", Status = true }
                };
                context.Controlpanels.AddRange(listControlPanel);
                context.SaveChanges();
            }
        }

        private void CreateCustomImage(DoAnDbContext context)
        {
            if (context.CustomImages.Count() == 0)
            {
                List<CustomImage> listCustomImage = new List<CustomImage>
                {
                    new CustomImage() {  Type = "Logo", Status = true  , CreatedDate = DateTime.Now},
                    new CustomImage() {  Type = "Background", Status = true  , CreatedDate = DateTime.Now}
                };
                context.CustomImages.AddRange(listCustomImage);
                context.SaveChanges();
            }
        }
        private void CreateCustomHeader(DoAnDbContext context)
        {
            if (context.CustomHeaders.Count() == 0)
            {
                List<CustomHeader> listCustomHeader = new List<CustomHeader>
                {
                    new CustomHeader() {  Type = "Header", Status = true  , CreatedDate = DateTime.Now},
                };
                context.CustomHeaders.AddRange(listCustomHeader);
                context.SaveChanges();
            }
        }
    }
}
