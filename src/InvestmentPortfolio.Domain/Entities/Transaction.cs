using InvestmentPortfolio.Domain.Enum;
using InvestmentPortfolio.Domain.Interfaces;

namespace InvestmentPortfolio.Domain.Entities
{
    public class Transaction : IEntityBase
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int FinancialProductId { get; set; }
        public DateTime TransactionDate { get; set; }
        public decimal Value { get; set; }
        public int Quantity { get; set; }
        public TransactionType Type { get; set; }
    }

}
