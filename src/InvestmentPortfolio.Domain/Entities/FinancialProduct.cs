using InvestmentPortfolio.Domain.Enum;
using InvestmentPortfolio.Domain.Interfaces;

namespace InvestmentPortfolio.Domain.Entities
{
    public class FinancialProduct : IEntityBase
    {
        public int Id { get; set; }
        public string Ticker { get; set; }
        public string Name { get; set; }
        public FinancialProductType Type { get; set; }
        public DateTime MaturityDate { get; set; }
        public decimal Value { get; set; }
    }
}
