
using InvestmentPortfolio.Application.AutoMapper;

namespace InvestmentPortfolio.API.Configurations
{
    public static class AutoMapperConfig
    {
        public static WebApplicationBuilder AddAutoMapperConfiguration(this WebApplicationBuilder builder)
        {
            if (builder == null) throw new ArgumentNullException(nameof(builder));

            builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

            return builder;
        }
    }
}