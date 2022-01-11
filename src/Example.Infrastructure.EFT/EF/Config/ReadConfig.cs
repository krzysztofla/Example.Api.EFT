using Example.Infrastructure.EFT.EF.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Example.Infrastructure.EFT.EF.Config
{
    internal class ReadConfig : IEntityTypeConfiguration<ItemReadModel>,
                                IEntityTypeConfiguration<DescriptionReadModel>,
                                IEntityTypeConfiguration<ItemNameReadModel>,
                                IEntityTypeConfiguration<PriceReadModel>
    {
        public void Configure(EntityTypeBuilder<ItemReadModel> builder)
        {
            throw new NotImplementedException();
        }

        public void Configure(EntityTypeBuilder<PriceReadModel> builder)
        {
            throw new NotImplementedException();
        }

        public void Configure(EntityTypeBuilder<ItemNameReadModel> builder)
        {
            throw new NotImplementedException();
        }

        public void Configure(EntityTypeBuilder<DescriptionReadModel> builder)
        {
            throw new NotImplementedException();
        }

    }
}
