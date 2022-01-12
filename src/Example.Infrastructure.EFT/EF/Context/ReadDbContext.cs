﻿using Example.Infrastructure.EFT.EF.Config;
using Example.Infrastructure.EFT.EF.Models;
using Microsoft.EntityFrameworkCore;

namespace Example.Infrastructure.EFT.EF.Context
{
    internal class ReadDbContext : DbContext
    {
        public DbSet<ItemReadModel> Items { get; set; }

        public ReadDbContext(DbContextOptions<ReadDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.HasDefaultContainer("Items");
            builder.ApplyConfiguration(new ReadConfig());
            base.OnModelCreating(builder);
        }

    }
}
