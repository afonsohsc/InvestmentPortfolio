using InvestmentPortfolio.Domain.Enum;

namespace InvestmentPortfolio.Application.ViewModels
{
    public class FinancialProductViewModel
    {
        public int Id { get; set; }
        public string Ticker { get; set; }
        public string Name { get; set; }
        public FinancialProductType Type { get; set; }
        public DateTime MaturityDate { get; set; }
        public decimal Value { get; set; }
    }
}
