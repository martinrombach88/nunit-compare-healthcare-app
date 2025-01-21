using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using compare_healthcare_api.Models;

namespace compare_healthcare_api.Controllers;
[ApiController]
[Route("[controller]")]

//optimise the endpoints:
//case insensitive search -> method is used often, should be abstracted into a class?
//error handling -> error codes don't yet match
//security measures? (e.g. sql injection)

public class CountryController: ControllerBase {
	//JSON file used instead of database (focus of project is tests, mocking, SOLID etc)
	//how could these fields be abstracted and imported?
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
		
		if (countries == null || countries.Any() == false || jsonData == null) 
		{				
			return NotFound(new { message = "Country list unavailable.", error = "LISTEMPTY", statusCode = 404 });
		} 
		//csharp linq creates concise syntax similar to for each (singleOrDefault accounts for errors)
		if (countries.SingleOrDefault(listCountry =>String.Equals(listCountry.countryName, countryName, StringComparison.OrdinalIgnoreCase)) == null) 
		{
			
			return NotFound(new { message = "Invalid country entered.", error = "INVALIDCOUNTRY", statusCode = 400 });
		}
		else
		{
			country = countries.SingleOrDefault(listCountry =>
				String.Equals(listCountry.countryName, countryName, StringComparison.OrdinalIgnoreCase));
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
		if (countries.SingleOrDefault(listCountry =>listCountry.countryName == baseCountryName) != null) 
		{
			baseCountry = countries.SingleOrDefault(listCountry => listCountry.countryName == baseCountryName);
		}
		if (countries.SingleOrDefault(listCountry =>listCountry.countryName == comparisonCountryName) != null) 
		{
			comparisonCountry = countries.SingleOrDefault(listCountry => listCountry.countryName == comparisonCountryName);
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
        