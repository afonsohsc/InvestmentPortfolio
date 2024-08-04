using AutoMapper;
using InvestmentPortfolio.Application.Interfaces;
using InvestmentPortfolio.Application.ViewModels;
using InvestmentPortfolio.Domain.Entities;
using InvestmentPortfolio.Domain.Interfaces;

namespace InvestmentPortfolio.Application.Services
{
    public class FinancialProductAppService : IFinancialProductAppService
    {
        private readonly IFinancialProductRepository _financialProductRepository;
        private readonly IMapper _mapper;

        public FinancialProductAppService(IFinancialProductRepository financialProductRepository, IMapper mapper)
        {
            _financialProductRepository = financialProductRepository;
            _mapper = mapper;
        }

        public IEnumerable<FinancialProductViewModel> GetAll()
        {
            return _mapper.Map<IEnumerable<FinancialProductViewModel>>(_financialProductRepository.GetAll());
        }

        public FinancialProductViewModel GetById(int id)
        {
            return _mapper.Map<FinancialProductViewModel>(_financialProductRepository.GetById(id));
        }

        public void Add(FinancialProductViewModel financialProductViewModel)
        {
            var financialProduct = _mapper.Map<FinancialProduct>(financialProductViewModel);
            _financialProductRepository.Add(financialProduct);
        }

        public void Update(FinancialProductViewModel financialProductViewModel)
        {
            var financialProduct = _mapper.Map<FinancialProduct>(financialProductViewModel);
            _financialProductRepository.Update(financialProduct);
        }
    }
}
