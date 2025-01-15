using Microsoft.AspNetCore.Mvc;

namespace compare_healthcare_api.Controllers;

[ApiController]
[Route("[controller]")]
public class CountryController: ControllerBase
{
    [HttpGet(Name = "GetCountry")]
    
        public string Get()
    {
        return "britain";
    }
}