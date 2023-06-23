using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Slobodianiuk.University.Example.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Slobodianuik.University.Example.Database
{
    public class FlowersShopDbContext : IdentityDbContext
    {
        public DbSet<Flower> Flower { get; set; }
        public DbSet<Order> Order { get; set; }
        public FlowersShopDbContext() { }
        public FlowersShopDbContext(DbContextOptions<FlowersShopDbContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseLazyLoadingProxies();
            options.UseSqlServer("Server=tcp:flowershops.database.windows.net,1433;Initial Catalog=FlowerShop;Persist Security Info=False;User ID=sqladmin;Password=Manka12345_;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
