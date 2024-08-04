using InvestmentPortfolio.API.Configurations;

var builder = WebApplication.CreateBuilder(args);

// Configure Services
builder.AddApiConfiguration()                   // Api Configurations
       .AddDatabaseConfiguration()              // Setting DBContexts
       .AddAutoMapperConfiguration()            // AutoMapper Settings
       .AddSwaggerConfiguration()               // Swagger Config
       .AddDependencyInjectionConfiguration();  // DotNet Native DI Abstraction

var app = builder.Build();

// Configure the HTTP request.
if (app.Environment.IsDevelopment())
{
    app.UseSwaggerSetup();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
