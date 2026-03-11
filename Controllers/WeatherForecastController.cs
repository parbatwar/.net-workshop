using Microsoft.AspNetCore.Mvc;

namespace W18.Controllers;

[ApiController]
[Route(template:"[controller]")]
public class WeatherForecastController(IConfiguration configuration) : ControllerBase
{
    [HttpGet]
    public int GetTotalPresentStudent()
    {
        int count = 0;
        count = configuration.GetValue<int>(key: "TotalPresentStudent");
        return count;
    }
}
