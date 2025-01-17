using Microsoft.AspNetCore.Mvc;
using compare_healthcare_api.Models;

namespace compare_healthcare_api.Controllers;

[ApiController]
[Route("[controller]")]
public class CountryController: ControllerBase
{
    [HttpGet(Name = "GetCountry")]
        public Country GetCountry(string countryName) 
        //specific country as argument
    {
        //country object is retrieved if countryName matches Country.Name
        Country Britain = new Country();       
		Britain.Name = "United Kingdom";
		Britain.Rank = 36;
        Britain.MonthWaitingListDelay = 18;
        Britain.AandEHoursWait = 8;
        Britain.CustomerOpinion = "Awful";
        //cost of treatment?
        return Britain;
    }

	//get comparison result
	//make two calls to the GetCountry endpoint.
    
}
        