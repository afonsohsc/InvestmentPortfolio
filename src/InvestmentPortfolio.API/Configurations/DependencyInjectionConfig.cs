using InvestmentPortfolio.API.HostedServices;
using InvestmentPortfolio.Infra.CrossCutting.IoC;

namespace InvestmentPortfolio.API.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static WebApplicationBuilder AddDependencyInjectionConfiguration(this WebApplicationBuilder builder)
        {
            if (builder == null) throw new ArgumentNullException(nameof(builder));

            NativeInjectorBootStrapper.Register(builder);
            //builder.Services.AddHostedService<EmailHostedService>();

            return builder;
        }
    }
}