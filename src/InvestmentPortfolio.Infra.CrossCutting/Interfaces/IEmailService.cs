using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestmentPortfolio.Infra.CrossCutting.Interfaces
{
    public interface IEmailService
    {
        Task SendEmailAsync(string group, IEnumerable<string> emails, string subject, string message, CancellationToken cancellationToken = default);
    }
}
