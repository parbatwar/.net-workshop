using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace W18.Controllers;

[ApiController]
[Route(template: "[controller]")]
public class WeatherForecastController(IConfiguration configuration, IOptions<MyInfoConfig> myInfoConfig) : ControllerBase
{
    [HttpGet]
    public int GetTotalPresentStudent()
    {
        int count = configuration.GetValue<int>(key: "TotalPresentStudent");
        return count;
    }


    [HttpGet("myinfo")]
    public object GetMyInfo()
    {
        var data = new
        {
            Name = configuration["MyInfo: Name"],
            Age = configuration["MyInfo: Age"],
            Address = configuration["MyInfo: Address"],
        };
        return data;
    }


    [HttpGet("my-info-option-pattern")]
    public object GetMyInformationOptionPattern()
    {
        var myInfoConigValue = myInfoConfig.Value;
        var data = new
        {
            Name = myInfoConigValue.Name,
            Age = myInfoConigValue.Age,
            Address = myInfoConigValue.Address,
        };
        return data;
    }
}
