using Ios_api.DBContext.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ios_api.DBContext.EntitieMappers
{
    public class StockMapper : IEntityTypeConfiguration<Stock>
    {
        public void Configure(EntityTypeBuilder<Stock> builder)
        {
            //builder.ToTable("line_channel_access");

            //builder.HasKey(e => e.id)
            //     .HasName("PRIMARY");

            //builder.Property(e => e.CompanyId)
            //   .HasColumnName("company_id")
            //   .HasColumnType("int(11)");

            //builder.Property(e => e.ChannelAccessToken).HasColumnName("channel_access_token");

        }
    }
}
