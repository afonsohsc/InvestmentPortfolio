
using InvestmentPortfolio.Domain.Enum;
using InvestmentPortfolio.Domain.Interfaces;
using InvestmentPortfolio.Infra.CrossCutting.Entities;
using InvestmentPortfolio.Infra.CrossCutting.Interfaces;

namespace InvestmentPortfolio.API.HostedServices
{
    public class EmailHostedService : IHostedService, IDisposable
    {
        private readonly IServiceProvider _serviceProvider;
        private CancellationTokenSource _cancellationTokenSource;
        private Timer _timer;
        private readonly TimeSpan _dailyExecutionTime = TimeSpan.FromHours(8);
        private readonly string _subject = "Produtos com vencimento próximo";

        public EmailHostedService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _cancellationTokenSource = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);
            ScheduleDailyTask();
            
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

            if (currentTime > nextExecutionTime)
            {
                nextExecutionTime = nextExecutionTime.AddDays(1);
            }

            TimeSpan timeToGo = nextExecutionTime - currentTime;

            _timer = new Timer(
                async _ => await ExecuteNotificationDailyTask(),
                null,
                timeToGo,
                TimeSpan.FromDays(1));
        }

        private async Task ExecuteNotificationDailyTask()
        {
            await using (var scope = _serviceProvider.CreateAsyncScope())
            {
                var financialProductRepository = scope.ServiceProvider.GetRequiredService<IFinancialProductRepository>();
                var userRepository = scope.ServiceProvider.GetRequiredService<IUserRepository>();
                var emailService = scope.ServiceProvider.GetRequiredService<IEmailService>();

                var tickersNearMaturity = TickersNearMaturity(financialProductRepository);
                if (tickersNearMaturity.Length == 0)
                    return;

                var msg = $"Ticker near maturity [{string.Join(',', tickersNearMaturity)}]";
                
                var userAdmin = MaillAddressUserAdmin(userRepository);

                await emailService.SendEmailAsync(Role.Administrator.ToString(), userAdmin, _subject, msg, _cancellationTokenSource.Token);
            }
        }

        private static List<MailAddressUser> MaillAddressUserAdmin(IUserRepository userRepository)
        {
            return userRepository.GetAll()
                               .Where(p => p.Role == Role.Administrator)
                               .Select(u => new MailAddressUser() { Name = u.Name, Email = u.Email })
                               .ToList();
        }

        private static string[] TickersNearMaturity(IFinancialProductRepository financialProductRepository)
        {
            return financialProductRepository.GetAll()
                                .Where(p => p.MaturityDate <= DateTime.Now.AddDays(7))
                                .Select(p => p.Ticker)
                                .ToArray();

        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _timer?.Change(Timeout.Infinite, 0);
            _cancellationTokenSource.Cancel();
            return Task.CompletedTask;
        }

        public async void Dispose()
        {
            _timer?.Dispose();
            _cancellationTokenSource?.Dispose();
        }
    }
}
