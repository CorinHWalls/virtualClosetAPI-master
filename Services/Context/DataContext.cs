using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using virtualClosetApi.Models;
using virtualClosetAPI.Models;

namespace virtualClosetApi.Services.Context
{
    public class DataContext : DbContext
    {
        //Creates Tables
        public DbSet<UserModel> UserInfo { get; set; }
        public DbSet<ItemModel> ItemInfo { get; set; }
        public DbSet<OutfitModel> OutfitInfo { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}