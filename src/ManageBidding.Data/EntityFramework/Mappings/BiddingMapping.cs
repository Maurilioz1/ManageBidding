using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ManageBidding.Domain.Models;

namespace ManageBidding.Data.EntityFramework.Mappings
{
    public class BiddingMapping : IEntityTypeConfiguration<Bidding>
    {
        public void Configure(EntityTypeBuilder<Bidding> builder)
        {
            builder.HasKey(b => b.Id);

            builder.Property(b => b.Number).HasDefaultValueSql("NEXT VALUE FOR BiddingSequence");
            builder.Property(b => b.Description).HasColumnType("varchar(1000)").IsRequired();

            builder.ToTable("Biddings");
        }
    }
}
