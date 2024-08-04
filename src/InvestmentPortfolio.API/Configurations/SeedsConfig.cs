using InvestmentPortfolio.Infra.Data.Context;
using InvestmentPortfolio.Infra.Data.Seeds;
using Microsoft.EntityFrameworkCore;

namespace InvestmentPortfolio.API.Configurations
{
    public static class SeedsConfig
    {
        public static IApplicationBuilder InsertSeeds(this IApplicationBuilder app)
        {
            if (app == null) throw new ArgumentNullException(nameof(app));

            using (var context = new InvestmentPortfolioContext(CreateOptions()))
            {
                var seeds = new UserSeed(context);
                seeds.Insert();
            }

            return app;
        }        

        private static DbContextOptions<InvestmentPortfolioContext> CreateOptions()
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<InvestmentPortfolioContext>();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            return optionsBuilder.Options;
        }
    }
}