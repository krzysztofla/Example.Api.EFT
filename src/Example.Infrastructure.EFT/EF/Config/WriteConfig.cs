using Example.Core.EFT.Entities;
using Example.Core.EFT.Value_Object;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Example.Infrastructure.EFT.EF.Config
{
    internal class WriteConfig : IEntityTypeConfiguration<Item>
    {
        public void Configure(EntityTypeBuilder<Item> builder)
        {
            builder.ToContainer("Items");

            builder.HasKey(p => p.Id);

            var nameConverter = new ValueConverter<ItemName, string>(v => v.ToString(), v => new ItemName(v));
            builder.Property(typeof(ItemName), "_itemName").HasConversion(nameConverter);

            var descriptionConverter = new ValueConverter<Description, string>(v => v.ToString(), v => new Description(v));
            builder.Property(typeof(Description), "_description").HasConversion(descriptionConverter);

            var priceConverter = new ValueConverter<Price, string>(v => v.ToString(), v => Price.Build(v));
            builder.Property(typeof(Price), "_price").HasConversion(priceConverter);


        }
    }
}
