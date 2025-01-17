using Microsoft.AspNetCore.Mvc;
using compare_healthcare_api.Models;

namespace compare_healthcare_api.Controllers;


[ApiController]
[Route("[controller]")]
public class CountryController: ControllerBase
{

    [HttpGet(Name = "GetCountry")]
        public Country GetCountry() 
        //specific country as argument
    {
        //country object is retrieved and returned.
        Country Britain = new Country();       
		Britain.Name = "United Kingdom";
		Britain.Rank = 36;
        Britain.MonthWaitingListDelay = 18;
        Britain.AandEHoursWait = 8;
        Britain.CustomerOpinion = "Awful";
        //cost of treatment o
        return Britain;
    }
    
}
        