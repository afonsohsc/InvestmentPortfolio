using FluentValidation.AspNetCore;
using FluentValidation;
using InvestmentPortfolio.Application.Validators;
using InvestmentPortfolio.Application.ViewModels;

namespace InvestmentPortfolio.API.Configurations
{
    public static class FluentValidationConfig
    {
        public static WebApplicationBuilder AddFluentValidationConfig(this WebApplicationBuilder builder)
        {
            if (builder == null) throw new ArgumentNullException(nameof(builder));
            
            builder.Services.AddFluentValidationAutoValidation();
            builder.Services.AddFluentValidationClientsideAdapters();
            builder.Services.AddScoped<IValidator<FinancialProductViewModel>, FinancialProductValidator>();
            builder.Services.AddScoped<IValidator<TransactionViewModel>, TransactionValidator>();


            return builder;
        }
    }
}
