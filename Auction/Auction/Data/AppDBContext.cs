using Auction.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auction.Data
{
    public class AppDBContext : IdentityDbContext<User>
    {
        public DbSet<Lot> Lots { get; set; }
        public DbSet<Purchase> Purchases { get; set; }

        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder model)
        {
            base.OnModelCreating(model);
        }
    }
}
