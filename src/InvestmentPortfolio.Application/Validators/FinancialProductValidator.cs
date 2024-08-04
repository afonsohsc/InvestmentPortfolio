using FluentValidation;
using InvestmentPortfolio.Application.ViewModels;
using InvestmentPortfolio.Domain.Extensions;

namespace InvestmentPortfolio.Application.Validators
{
    public class FinancialProductValidator : AbstractValidator<FinancialProductViewModel>
    {
        public FinancialProductValidator()
        {
            RuleFor(p => p.Ticker)
                .NotEmpty().WithMessage("O nome do produto financeiro é obrigatório.")
                .Length(2, 100).WithMessage("O nome do produto financeiro deve ter entre 2 e 100 caracteres.");

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("O nome do produto financeiro é obrigatório.")
                .Length(2, 100).WithMessage("O nome do produto financeiro deve ter entre 2 e 100 caracteres.");

            RuleFor(p => p.MaturityDate)
              .Must(ValidationExtensions.BeAValidDate).WithMessage("A data fornecida não é válida.");

            RuleFor(p => p.Value)
                .GreaterThan(0).WithMessage("O preço deve ser maior que zero.");
        }
    }
}
