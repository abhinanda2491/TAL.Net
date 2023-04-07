using System.ComponentModel.DataAnnotations;

namespace TAL.Net.Models;

public class PremiumCalculatorRequest
{
    [Required]
    [MaxLength(3, ErrorMessage = "Maximum 3 digits accepted")]
    [Range(1, 70, ErrorMessage = "Minimum age is 1 and maximum age is 70 years.")]
    public string Age { get; set; }

    [Required]
    [RegularExpression(@"^\d+.?\d{0,2}$", ErrorMessage = "Invalid occupational rating, maximum two decimal points.")]
    public string OccupationRating { get; set; }

    [Required]
    [RegularExpression(@"^-?[0-9][0-9,\.]+$", ErrorMessage = "Invalid Sum Insured")]
    public string SumInsured { get; set; }
}
