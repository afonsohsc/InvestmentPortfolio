
using InvestmentPortfolio.Domain.Interfaces;
using InvestmentPortfolio.Infra.CrossCutting.Interfaces;
using InvestmentPortfolio.Infra.CrossCutting.Services;

namespace InvestmentPortfolio.API.HostedServices
{
    public class EmailHostedService : IHostedService, IDisposable
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;
        private readonly IServiceScope _singletonScope;
        private CancellationTokenSource _cancellationTokenSource;
        private Timer _timer;
        private readonly TimeSpan _dailyExecutionTime = TimeSpan.FromHours(8);

        public EmailHostedService(IServiceScopeFactory serviceScopeFactory, IServiceScope singletonScope)
        {
            _serviceScopeFactory = serviceScopeFactory;
            _singletonScope = singletonScope;
            _singletonScope = _serviceScopeFactory.CreateScope();
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            while (!_cancellationTokenSource.IsCancellationRequested)
            {
                ScheduleDailyTask();
            }
            return Task.CompletedTask;
        }

        private void ScheduleDailyTask()
        {
            DateTime currentTime = DateTime.Now;
            DateTime nextExecutionTime = new DateTime(
                currentTime.Year,
                currentTime.Month,
                currentTime.Day,
                _dailyExecutionTime.Hours,
                _dailyExecutionTime.Minutes,
                _dailyExecutionTime.Seconds);

            //if (currentTime > nextExecutionTime)
            //{
            //    nextExecutionTime = nextExecutionTime.AddDays(1); // Se já passou das 8h hoje, executa amanhã
            //}

            TimeSpan timeToGo = nextExecutionTime - currentTime;

            _timer = new Timer(
                async _ => await ExecuteNotificationDailyTask(),
                null,
                timeToGo,
                TimeSpan.FromDays(1)); // Repete a cada 24 horas
        }

        private async Task ExecuteNotificationDailyTask()
        {
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var repository = scope.ServiceProvider.GetRequiredService<IFinancialProductRepository>();
                var emailService = scope.ServiceProvider.GetRequiredService<IEmailService>();

                await emailService.SendEmailAsync("", [], "", "", _cancellationTokenSource.Token);
            }
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _cancellationTokenSource.Cancel();
            return Task.CompletedTask;
        }

        public async void Dispose()
        {
            _cancellationTokenSource?.Dispose();
            _singletonScope?.Dispose();
        }
    }
}
