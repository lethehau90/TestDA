using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoAn.Model.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace DoAn.Data
{
    public class DoAnDbContext : IdentityDbContext<ApplicationUser>
    {
        public DoAnDbContext(): base("DoAnConnection")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }
        public DbSet<ControlPanel> Controlpanels { get; set; }
        public DbSet<CustomImage> CustomImages { get; set; }
        public DbSet<CustomHeader> CustomHeaders { get; set; }
        public DbSet<Donation> Donations { get; set; }
        public DbSet<Laudatory> Laudatorys { get; set; }
        public static DoAnDbContext Create()
        {
            return new DoAnDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder builder)
        {
            builder.Entity<IdentityUserRole>().HasKey(i => new { i.UserId, i.RoleId });
            builder.Entity<IdentityUserLogin>().HasKey(i => i.UserId);
        }
    }
}
