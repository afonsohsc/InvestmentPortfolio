using InvestmentPortfolio.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InvestmentPortfolio.Infra.Data.Maps
{
    public class FinancialProductMap : IEntityTypeConfiguration<FinancialProduct>
    {
        public void Configure(EntityTypeBuilder<FinancialProduct> builder)
        {
            builder.HasKey(fp => fp.Id);

            builder.Property(fp => fp.Ticker)
                .IsRequired()
                .HasMaxLength(10);

            builder.Property(fp => fp.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(fp => fp.Type)
                .IsRequired()
                .HasConversion<string>()
                .HasMaxLength(30);

            builder.Property(fp => fp.MaturityDate)
                .IsRequired();

            builder.Property(fp => fp.Value)
                .IsRequired()
                .HasPrecision(18, 2);

            builder.HasIndex(fp => new { fp.Ticker, fp.Name });
        }
    }
}
