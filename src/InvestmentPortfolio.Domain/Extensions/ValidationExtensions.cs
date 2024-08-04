namespace InvestmentPortfolio.Domain.Extensions
{
    public static class ValidationExtensions
    {
        public static bool BeAValidDate(DateTime date)
        {
            return date != default(DateTime) && date != DateTime.MinValue && date != DateTime.MaxValue;
        }
    }
}
