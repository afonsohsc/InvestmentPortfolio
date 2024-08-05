using InvestmentPortfolio.Infra.CrossCutting.Entities;

namespace InvestmentPortfolio.Infra.CrossCutting.Interfaces
{
    public interface IEmailService
    {
        Task SendEmailAsync(string group, IEnumerable<MailAddressUser> emails, string subject, string message, CancellationToken cancellationToken = default);
    }
}
