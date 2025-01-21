using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using compare_healthcare_api.Models;

namespace compare_healthcare_api.Controllers;
[ApiController]
[Route("[controller]")]

//optimise the endpoints:
//case insensitive search
//error handling
//security measures? (e.g. sql injection)

public class CountryController: ControllerBase {
	//JSON file used instead of database (focus of project is tests, mocking, SOLID etc)
	//how could these fields be abstracted and imported?
	internal static string jsonData = System.IO.File.ReadAllText("Controllers/placeholder-data/test.json");
	internal static IEnumerable<Country>? countries = System.Text.Json.JsonSerializer.Deserialize<IEnumerable<Country>>
	(jsonData, new JsonSerializerOptions{IncludeFields = true}); 

    [HttpGet("GetCountries")]
	public IActionResult GetCountries()
    {	
		if (countries == null || countries.Any() == false) 
		{
			//handle no list error
		}
        return Ok(countries);
    }
	
	[HttpGet("GetCountry/{countryName}")]
	public IActionResult GetCountry(string countryName)
    {		
		//If handled by dapper MS SQL, string could be:
		//string sql = @"SELECT countryName, rank, monthWaitingListDelay, aAndEHoursWait, 
		//CostOfTreatment, customerOpinion FROM healthcareDatabase WHERE countryName = britain"

		Country country = new Country();
		if (countries == null || countries.Any() == false ) 
		{				
			//handle no list error
		} 
		if (countries.Single(listCountry =>listCountry.countryName == countryName) != null) 
		{
			//csharp linq creates concise syntax similar to for each
			country = countries.Single(listCountry => listCountry.countryName == countryName);
		}
		else {
			//handle no match error
		}
        return Ok(country);
    }

	[HttpGet("GetComparisonResult/{baseCountryName}/{comparisonCountryName}")]
	public IActionResult GetComparisonResult(string baseCountryName, string comparisonCountryName)
	//If handled by dapper MS SQL, string could be:
	//???
    {	
		ComparisonResult countriesResult = new ComparisonResult();
		Country baseCountry = new Country();
		Country comparisonCountry = new Country();
		
		if (countries == null || countries.Any() == false ) 
		{				
			//handle no list error
		} 
		if (countries.Single(listCountry =>listCountry.countryName == baseCountryName) != null) 
		{
			baseCountry = countries.Single(listCountry => listCountry.countryName == baseCountryName);
		}
		if (countries.Single(listCountry =>listCountry.countryName == comparisonCountryName) != null) 
		{
			comparisonCountry = countries.Single(listCountry => listCountry.countryName == comparisonCountryName);
		}
		if (baseCountry != null && comparisonCountry != null) {
			countriesResult.baseCountry = baseCountry;
			countriesResult.comparisonCountry = comparisonCountry;
		}
		else {
			//handle not found error
		}
        return Ok(countriesResult);
	}
}
        