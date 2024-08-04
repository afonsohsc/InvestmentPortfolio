using InvestmentPortfolio.Application.ViewModels;

namespace InvestmentPortfolio.Application.Interfaces
{
    public interface IFinancialProductAppService
    {
        IEnumerable<FinancialProductViewModel> GetAll();
        FinancialProductViewModel GetById(int id);
        void Add(FinancialProductViewModel financialProductViewModel);
        void Update(FinancialProductViewModel financialProductViewModel);
    }
}
