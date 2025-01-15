using Microsoft.AspNetCore.Mvc;

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
        
        //failure state? try catch?
        return Britain;
    }
    [HttpGet(Name = "GetComparison")]  
        public string GetComparison()
    {
        return "south korea is probably better than britain";
    }


        
        
        
        
        
        
        
        
        
}