using InvestmentPortfolio.Domain.Entities;
using InvestmentPortfolio.Domain.Interfaces;
using InvestmentPortfolio.Infra.Data.Context;

namespace InvestmentPortfolio.Infra.Data.Repositories
{
    public class TransactionRepository(InvestmentPortfolioContext context) : RepositoryBase<Transaction>(context), ITransactionRepository
    {
    }
}
