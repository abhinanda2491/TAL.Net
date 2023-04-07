using TAL.Net.Models;

namespace TAL.Net.Services;

public interface IPremiumCalculator
{
    Response CalculatePremiumAsync(decimal sumInsured, decimal occupationRating,int age);
}
