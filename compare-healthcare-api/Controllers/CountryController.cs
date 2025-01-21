using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using compare_healthcare_api.Models;
using compare_healthcare_api.Helpers;

namespace compare_healthcare_api.Controllers;
[ApiController]
[Route("[controller]")]

//optimise the endpoints:
//case insensitive search -> method is used often, should be abstracted into a class?
//error handling -> error codes don't yet match
//security measures? (e.g. sql injection)

public class CountryController: ControllerBase {
	//JSON file used instead of database (focus of project is tests, mocking, SOLID etc)
	//abstract these fields to JSON helper
	internal static string jsonData = System.IO.File.ReadAllText("Controllers/placeholder-data/countries.json");
	internal static IEnumerable<Country>? countries = System.Text.Json.JsonSerializer.Deserialize<IEnumerable<Country>>
	(jsonData, new JsonSerializerOptions{IncludeFields = true}); 

    [HttpGet("GetCountries")]
	public IActionResult GetCountries()
    {	
		if (countries == null || countries.Any() == false) 
		{
			return NotFound(new { message = "Country list unavailable.", error = "LISTEMPTY", statusCode = 404 });
		}
        return Ok(countries);
    }
	
	[HttpGet("GetCountry/{countryName}")]
	public IActionResult GetCountry(string countryName)
    {		
		//If handled by dapper and MS SQL, string could be:
		//string sql = @"SELECT countryName, rank, monthWaitingListDelay, aAndEHoursWait, 
		//CostOfTreatment, customerOpinion FROM healthcareDatabase WHERE countryName = britain"

		Country country = new Country();
		
		if (countries == null || countries.Any() == false) 
			//file not found error not handled
		{				
			return NotFound(new { message = "Country list unavailable.", error = "LISTEMPTY", statusCode = 404 });
		} 
		
		if (CountryHelper.getCountryFromList(countries, countryName) == null) 
		{
			//status code not matching swagger
			return NotFound(new { message = "Invalid country entered.", error = "INVALIDCOUNTRY", statusCode = 400 });
		}
		else
		{
			country = CountryHelper.getCountryFromList(countries, countryName);
		}

		return Ok(country);
    }

	[HttpGet("GetComparisonResult/{baseCountryName}/{comparisonCountryName}")]
	public IActionResult GetComparisonResult(string baseCountryName, string comparisonCountryName)
	//If handled by dapper and MS SQL, string could be:
	//???
	{
		ComparisonResult countriesResult = null;
		Country baseCountry = new Country();
		Country comparisonCountry = new Country();
		
		if (countries == null || countries.Any() == false) 
		{
			return NotFound(new { message = "Country list unavailable.", error = "LISTEMPTY", statusCode = 404 });
		} 
		if (CountryHelper.getCountryFromList(countries, baseCountryName) != null)  
		{
			baseCountry = CountryHelper.getCountryFromList(countries, baseCountryName);
		}
		if (CountryHelper.getCountryFromList(countries, comparisonCountryName) != null) 
		{
			comparisonCountry = CountryHelper.getCountryFromList(countries, comparisonCountryName);
		}
		if (baseCountry != null && comparisonCountry != null) {
			countriesResult = new ComparisonResult(baseCountry, comparisonCountry);
		}
		else
		{
			return NotFound(new { message = "Invalid country entered.", error = "INVALIDCOUNTRY", statusCode = 400 });
		}
        return Ok(countriesResult);
	}
}
        