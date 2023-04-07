namespace TAL.Net.Services;

public class PremiumCalculator : IPremiumCalculator
{
    public Tuple<decimal, decimal> CalculatePremiumAsync(decimal sumInsured, decimal occupationRating, int age)
    {
        //Calculate death premium
        decimal deathPremium = (sumInsured * occupationRating * age) / 1000 * 12;
        //calculate tpd premium for monthly
        decimal tpdPremiumMonthly = (sumInsured * occupationRating * age) / 1234;

        return new Tuple<decimal, decimal>(deathPremium, tpdPremiumMonthly);
    }
}
