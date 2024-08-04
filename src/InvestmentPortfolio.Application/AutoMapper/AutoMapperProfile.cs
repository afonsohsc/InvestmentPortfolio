using AutoMapper;
using InvestmentPortfolio.Application.ViewModels;
using InvestmentPortfolio.Domain.Entities;

namespace InvestmentPortfolio.Application.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<FinancialProduct, FinancialProductViewModel>().ReverseMap();
            CreateMap<Transaction, TransactionViewModel>().ReverseMap();
        }
    }
}
