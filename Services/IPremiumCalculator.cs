namespace TAL.Net.Services;

public interface IPremiumCalculator
{
    Tuple<decimal, decimal> CalculatePremiumAsync(decimal sumInsured, decimal occupationRating,int age);
}
