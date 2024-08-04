using InvestmentPortfolio.Domain.Entities;
using InvestmentPortfolio.Infra.Data.Maps;
using Microsoft.EntityFrameworkCore;

namespace InvestmentPortfolio.Infra.Data.Context
{
    public class InvestmentPortfolioContext : DbContext
    {
        public InvestmentPortfolioContext(DbContextOptions<InvestmentPortfolioContext> options) : base(options) { }

        public DbSet<User> User { get; set; }
        public DbSet<FinancialProduct> FinancialProduct { get; set; }
        public DbSet<Transaction> Transaction { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new FinancialProductMap());
            modelBuilder.ApplyConfiguration(new TransactionMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
