using InvestmentPortfolio.Application.ViewModels;

namespace InvestmentPortfolio.Application.Interfaces
{
    public interface ITransactionAppService
    {
        IEnumerable<TransactionViewModel> GetAll(int clientId);
        TransactionViewModel GetById(int id);
        void Add(TransactionViewModel transactionViewModel);
        void Update(TransactionViewModel transactionViewModel);
    }
}
