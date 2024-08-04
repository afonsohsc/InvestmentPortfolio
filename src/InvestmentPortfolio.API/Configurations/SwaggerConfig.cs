using Microsoft.Extensions.Configuration;
using Microsoft.OpenApi.Models;

namespace InvestmentPortfolio.API.Configurations
{
    public static class SwaggerConfig
    {
        public static WebApplicationBuilder AddSwaggerConfiguration(this WebApplicationBuilder builder)
        {
            if (builder == null) throw new ArgumentNullException(nameof(builder));

            builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Investment Portfolio Project",
                    Description = "Investment Portfolio API Swagger surface",
                    Contact = new OpenApiContact { Name = "Afonso Carvalho", Email = "afonsohenriquesc@hotmail.com", Url = new Uri("https://www.linkedin.com/in/afonsohscarvalho/") }
                });                               
            });

            return builder;
        }

        public static IApplicationBuilder UseSwaggerSetup(this IApplicationBuilder app)
        {
            if (app == null) throw new ArgumentNullException(nameof(app));

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
            });

            return app;
        }
    }
}