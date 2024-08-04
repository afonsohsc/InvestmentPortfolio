using FluentValidation;
using InvestmentPortfolio.Application.ViewModels;
using InvestmentPortfolio.Domain.Extensions;

namespace InvestmentPortfolio.Application.Validators
{
    public class TransactionValidator : AbstractValidator<TransactionViewModel>
    {
        public TransactionValidator()
        {
            RuleFor(p => p.UserId)
               .GreaterThan(0).WithMessage("O cliente informado não é valido.");

            RuleFor(p => p.FinancialProductId)
              .GreaterThan(0).WithMessage("O produto informado não é valido.");

            RuleFor(p => p.TransactionDate)
              .Must(ValidationExtensions.BeAValidDate).WithMessage("A data fornecida não é válida.");

            RuleFor(p => p.Value)
                .GreaterThan(0).WithMessage("O preço deve ser maior que zero.");
        }
    }
}
