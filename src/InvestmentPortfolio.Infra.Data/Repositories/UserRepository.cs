using InvestmentPortfolio.Domain.Entities;
using InvestmentPortfolio.Domain.Interfaces;
using InvestmentPortfolio.Infra.Data.Context;

namespace InvestmentPortfolio.Infra.Data.Repositories
{
    public class UserRepository(InvestmentPortfolioContext context) : RepositoryBase<User>(context), IUserRepository
    {
    }
}
