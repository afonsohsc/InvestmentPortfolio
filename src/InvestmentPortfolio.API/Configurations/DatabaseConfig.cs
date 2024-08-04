using InvestmentPortfolio.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace InvestmentPortfolio.API.Configurations
{
    public static class DatabaseConfig
    {
        public static WebApplicationBuilder AddDatabaseConfiguration(this WebApplicationBuilder builder)
        {
            if (builder == null) throw new ArgumentNullException(nameof(builder));

            builder.Services.AddDbContext<InvestmentPortfolioContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            return builder;
        }
    }
}