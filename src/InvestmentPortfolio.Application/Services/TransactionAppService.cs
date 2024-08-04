using AutoMapper;
using InvestmentPortfolio.Application.Interfaces;
using InvestmentPortfolio.Application.ViewModels;
using InvestmentPortfolio.Domain.Entities;
using InvestmentPortfolio.Domain.Interfaces;

namespace InvestmentPortfolio.Application.Services
{
    public class TransactionAppService : ITransactionAppService
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IMapper _mapper;

        public TransactionAppService(ITransactionRepository transactionRepository, IMapper mapper)
        {
            _transactionRepository = transactionRepository;;
            _mapper = mapper;
        }

        public IEnumerable<TransactionViewModel> GetAll()
        {
            return _mapper.Map<IEnumerable<TransactionViewModel>>(_transactionRepository.GetAll());
        }

        public TransactionViewModel GetById(int id)
        {
            return _mapper.Map<TransactionViewModel>(_transactionRepository.GetById(id));
        }

        public void Add(TransactionViewModel transactionViewModel)
        {
            var transaction = _mapper.Map<Transaction>(transactionViewModel);
            _transactionRepository.Add(transaction);
        }

        public void Update(TransactionViewModel financialProductViewModel)
        {
            var financialProduct = _mapper.Map<Transaction>(financialProductViewModel);
            _transactionRepository.Update(financialProduct);
        }
    }

}
