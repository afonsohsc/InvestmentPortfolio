using InvestmentPortfolio.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InvestmentPortfolio.Infra.Data.Maps
{
    public class TransactionMap : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            builder.HasKey(t => t.Id);

            builder.Property(t => t.UserId)
                .IsRequired();

            builder.Property(t => t.FinancialProductId)
                .IsRequired();

            builder.Property(t => t.TransactionDate)
                .IsRequired();

            builder.Property(t => t.Value)
                .IsRequired()
                .HasPrecision(18, 2);

            builder.Property(t => t.Quantity)
                .IsRequired();

            builder.Property(t => t.Type)
                .IsRequired()
                .HasConversion<string>()
                .HasMaxLength(30);

            builder.HasOne<User>()
                .WithMany()
                .HasForeignKey(t => t.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne<FinancialProduct>()
                .WithMany()
                .HasForeignKey(t => t.FinancialProductId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
