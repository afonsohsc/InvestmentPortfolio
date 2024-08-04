using InvestmentPortfolio.Infra.CrossCutting.Entities;
using Microsoft.Extensions.Options;
using MimeKit;
using MailKit.Net.Smtp;
using InvestmentPortfolio.Infra.CrossCutting.Interfaces;

namespace InvestmentPortfolio.Infra.CrossCutting.Services
{
    public class EmailService : IEmailService
    {
        private readonly EmailSettings _emailSettings;

        public EmailService(IOptions<EmailSettings> emailSettings)
        {
            _emailSettings = emailSettings.Value;
        }

        public async Task SendEmailAsync(string group, IEnumerable<string> emails, string subject, string message, CancellationToken cancellationToken = default)
        {
            MimeMessage mimeMessage = CreateEmailMessage(group,emails, subject, message);

            using (var client = new SmtpClient())
            {
                try
                {
                    await client.ConnectAsync(_emailSettings.SmtpServer, _emailSettings.Port, useSsl: false, cancellationToken);
                    await client.AuthenticateAsync(_emailSettings.UserName, _emailSettings.Password, cancellationToken);

                    await client.SendAsync(mimeMessage, cancellationToken);
                }
                catch (Exception ex)
                {
                    // Lidar com exceções de envio de e-mail (por exemplo, logar ou rethrow)
                    throw new InvalidOperationException($"Failed to send email: {ex.Message}");
                }
                finally
                {
                    await client.DisconnectAsync(true);
                    client.Dispose();
                }
            }
        }

        private MimeMessage CreateEmailMessage(string group, IEnumerable<string> emails, string subject, string message)
        {
            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress(_emailSettings.Name, _emailSettings.From));
            var mailboxAddressList = emails.Select(e => new MailboxAddress(e.Split('@').FirstOrDefault(), e));
            emailMessage.To.Add(new GroupAddress(group, mailboxAddressList));
            emailMessage.Subject = subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = message
            };

            return emailMessage;
        }
    }
}
