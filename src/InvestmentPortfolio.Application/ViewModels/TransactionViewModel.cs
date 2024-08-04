using InvestmentPortfolio.Domain.Enum;

namespace InvestmentPortfolio.Application.ViewModels
{
    public class TransactionViewModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int FinancialProductId { get; set; }
        public DateTime TransactionDate { get; set; }
        public decimal Value { get; set; }
        public TransactionType Type { get; set; }
    }
}
