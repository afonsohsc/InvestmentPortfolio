using InvestmentPortfolio.Domain.Entities;
using InvestmentPortfolio.Domain.Interfaces;
using InvestmentPortfolio.Infra.Data.Context;

namespace InvestmentPortfolio.Infra.Data.Repositories
{
    public class FinancialProductRepository(InvestmentPortfolioContext context) : RepositoryBase<FinancialProduct>(context), IFinancialProductRepository
    {
    }
}
