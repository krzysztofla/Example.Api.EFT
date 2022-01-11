using Example.Core.EFT.Entities;
using Microsoft.EntityFrameworkCore;

namespace Example.Infrastructure.EFT.EF.Context
{
    internal class WriteDbContext : DbContext
    {
        public DbSet<Item> Items { get; set; }
        public WriteDbContext(DbContextOptions<WriteDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.HasDefaultContainer("items");
            base.OnModelCreating(builder);
        }

    }
}
