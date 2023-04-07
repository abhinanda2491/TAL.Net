using Microsoft.AspNetCore.Mvc;
using TAL.Net.Models;

namespace TAL.Net.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    [HttpGet("occupations")]
    public ActionResult<IEnumerable<Occupation>> ListOccupations()
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

}

