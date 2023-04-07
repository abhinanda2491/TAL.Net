using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using TAL.Net.Models;
using TAL.Net.Services;

namespace TAL.Net.Controllers;

[ApiController]
[Route("Home")]
public class HomeController : ControllerBase
{
    private readonly IPremiumCalculator _premiumCalculator;

    public HomeController(IPremiumCalculator premiumCalculator)
    {
        _premiumCalculator = premiumCalculator;
    }


    [HttpGet]
    [Route("occupations")]
    public IActionResult ListOccupations()
    {
        var occupations = new List<Occupation>
        {
            new Occupation { Name = "Cleaner", Rating = "Light Manual", Factor = 1.5 },
            new Occupation { Name = "Doctor", Rating = "Professional", Factor = 1.0 },
            new Occupation { Name = "Author", Rating = "White Collar", Factor = 1.25 },
            new Occupation { Name = "Farmer", Rating = "Heavy Manual", Factor = 1.75 },
            new Occupation { Name = "Mechanic", Rating = "Heavy Manual", Factor = 1.75 },
            new Occupation { Name = "Florist", Rating = "Light Manual", Factor = 1.5 }
        };

        return Ok(occupations);
    }


    [HttpPost]
    [Route("caluclatePremium")]
    public async Task<IActionResult> CalculatePremium(PremiumCalculatorRequest premiumCalculator)
    {
        if (string.IsNullOrEmpty(premiumCalculator.SumInsured) || string.IsNullOrEmpty(premiumCalculator.OccupationRating)
            || string.IsNullOrEmpty(premiumCalculator.Age))
            return new BadRequestObjectResult("Invalid request.");

        if (Convert.ToDecimal(premiumCalculator.SumInsured) == 0 || Convert.ToDecimal(premiumCalculator.OccupationRating) == 0
            || Convert.ToInt32(premiumCalculator.Age) == 0)
            return new BadRequestObjectResult("Request is invalid. Values must be greater than 0.");

        var calculatedData =
            _premiumCalculator.CalculatePremiumAsync(Convert.ToDecimal(premiumCalculator.SumInsured),
            Convert.ToDecimal(premiumCalculator.OccupationRating), Convert.ToInt32(premiumCalculator.Age));

        if (calculatedData == null)
            return new BadRequestObjectResult("Error calculating the premium.");
        

        var result = JsonSerializer.Serialize(calculatedData, new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented = true
        });

        return Ok(result);
    }

}

