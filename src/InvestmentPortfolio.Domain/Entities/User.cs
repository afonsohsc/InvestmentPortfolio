using InvestmentPortfolio.Domain.Enum;
using InvestmentPortfolio.Domain.Interfaces;

namespace InvestmentPortfolio.Domain.Entities
{
    public class User : IEntityBase
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public Role Role { get; set; }
    }
}
