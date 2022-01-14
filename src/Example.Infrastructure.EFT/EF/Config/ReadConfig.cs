using Example.Infrastructure.EFT.EF.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Example.Infrastructure.EFT.EF.Config
{
    internal class ReadConfig : IEntityTypeConfiguration<ItemReadModel>
    {
        public void Configure(EntityTypeBuilder<ItemReadModel> builder)
        {
            builder.ToTable("Items");
            builder.HasKey(k => k.Id);

            builder.Property(p => p.ItemName)
                   .HasConversion(n => n.ToString(), l => ItemNameReadModel.Build(l));

            builder.Property(i => i.Price)
                   .HasConversion(p => p.ToString(), p => PriceReadModel.Build(p));

            builder.Property(i => i.Description)
                   .HasConversion(p => p.ToString(), p => DescriptionReadModel.Build(p));

        }
    }
}
