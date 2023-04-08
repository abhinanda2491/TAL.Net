using TAL.Net.Models;

namespace TAL.Net.Services;

public class PremiumCalculator : IPremiumCalculator
{
    public Response CalculatePremiumAsync(decimal sumInsured, decimal occupationRating, int age)
    {
        try
        {
            //Calculate death premium
            decimal deathPremium = (sumInsured * occupationRating * age) / 1000 * 12;
            //calculate tpd premium for monthly
            decimal tpdPremiumMonthly = (sumInsured * occupationRating * age) / 1234;

            return new Response()
            {
                DeathPremium = Math.Round(deathPremium, 2, MidpointRounding.ToEven),
                TPDPremiumMonthly = Math.Round(tpdPremiumMonthly, 2, MidpointRounding.ToEven)
            };
        }
        catch (Exception)
        {
            return null;
        }

    }
}
