using InvestmentPortfolio.Domain.Entities;
using InvestmentPortfolio.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestmentPortfolio.Infra.Data.Seeds
{
    public class UserSeed
    {
        private readonly InvestmentPortfolioContext _context;

        public UserSeed(InvestmentPortfolioContext context)
        {
            _context = context;
        }

        public void Insert()
        {
            if (_context.User.Any())
                return;

            _context.User.AddRange([
                new User { Email = "investimentAdmin@email.com.br", Name = "Admin", Role = Domain.Enum.Role.Administrator },
                new User { Email = "investimentUser@email.com.br", Name = "User", Role = Domain.Enum.Role.User } ]);

            _context.SaveChanges();
        }
    }
}
