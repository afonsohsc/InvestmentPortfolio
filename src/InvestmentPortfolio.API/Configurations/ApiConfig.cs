using InvestmentPortfolio.Infra.CrossCutting.Entities;

namespace InvestmentPortfolio.API.Configurations
{
    public static class ApiConfig
    {
        public static WebApplicationBuilder AddApiConfiguration(this WebApplicationBuilder builder)
        {
            if (builder == null) throw new ArgumentNullException(nameof(builder));

            builder.Configuration
                        .SetBasePath(builder.Environment.ContentRootPath)
                        .AddJsonFile("appsettings.json", true, true)
                        .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", true, true)
                        .AddEnvironmentVariables();

            builder.Services.Configure<EmailSettings>(builder.Configuration.GetSection("EmailSettings"));

            builder.Services.AddControllers();

            return builder;
        }
    }
}
