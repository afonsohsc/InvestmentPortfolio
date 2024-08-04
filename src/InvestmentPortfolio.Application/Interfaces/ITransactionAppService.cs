using InvestmentPortfolio.Application.ViewModels;

namespace InvestmentPortfolio.Application.Interfaces
{
    public interface ITransactionAppService
    {
        IEnumerable<TransactionViewModel> GetAll();
        TransactionViewModel GetById(int id);
        void Add(TransactionViewModel transactionViewModel);
        void Update(TransactionViewModel transactionViewModel);
    }
}
