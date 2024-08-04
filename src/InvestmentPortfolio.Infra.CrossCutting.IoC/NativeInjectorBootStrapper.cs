using InvestmentPortfolio.Application.Interfaces;
using InvestmentPortfolio.Application.Services;
using InvestmentPortfolio.Domain.Entities;
using InvestmentPortfolio.Domain.Interfaces;
using InvestmentPortfolio.Infra.CrossCutting.Interfaces;
using InvestmentPortfolio.Infra.CrossCutting.Services;
using InvestmentPortfolio.Infra.Data.Context;
using InvestmentPortfolio.Infra.Data.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace InvestmentPortfolio.Infra.CrossCutting.IoC
{
    public static class NativeInjectorBootStrapper
    {
        public static void Register(WebApplicationBuilder builder)
        {
            // Application
            builder.Services.AddScoped<IFinancialProductAppService, FinancialProductAppService>();            
            builder.Services.AddScoped<ITransactionAppService, TransactionAppService>();

            // Infra - CrossCutting
            builder.Services.AddScoped<IEmailService, EmailService>();

            // Infra - Data
            builder.Services.AddScoped<InvestmentPortfolioContext>();
            builder.Services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
            builder.Services.AddScoped<IFinancialProductRepository, FinancialProductRepository>();
            builder.Services.AddScoped<ITransactionRepository, TransactionRepository>();
            builder.Services.AddScoped<IUserRepository, UserRepository>();
        }
    }
}
