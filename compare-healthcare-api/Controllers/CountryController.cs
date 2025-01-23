using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using compare_healthcare_api.Models;
using compare_healthcare_api.Helpers;

namespace compare_healthcare_api.Controllers;
[ApiController]
[Route("/")]

//optimise the endpoints:
//error handling -> error codes don't yet match
//can you use TDD for this?
//nunit testing
//apply SOLID


public class CountryController: ControllerBase {
	//JSON file used instead of database (focus of project is tests, mocking, SOLID etc)
	internal static string jsonData = System.IO.File.ReadAllText("Controllers/placeholder-data/countries.json");
	
	internal static IEnumerable<Country>? countries = System.Text.Json.JsonSerializer.Deserialize<IEnumerable<Country>>
	(jsonData, new JsonSerializerOptions{IncludeFields = true}); 

	//sample 404 internal static IEnumerable<Country>? countries = null;

    [HttpGet("GetCountries")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
	public IActionResult GetCountries()
    {	
	    return countries != null ? Ok(countries) : NotFound();
    }
	
	[HttpGet("GetCountry/{countryName}")]
	[ProducesResponseType(StatusCodes.Status200OK)]
	[ProducesResponseType(StatusCodes.Status400BadRequest)]
	[ProducesResponseType(StatusCodes.Status404NotFound)]
	public IActionResult GetCountry(string countryName)
    {	
		Country country = new Country();
		
		if (countries == null || countries.Any() == false) 
		{				
			return NotFound();
		} 
		
		if (CountryHelper.getCountryFromList(countries, countryName) == null) 
		{
			return BadRequest();
		}

		country = CountryHelper.getCountryFromList(countries, countryName);
		return Ok(country);
    }

	[HttpGet("GetComparisonResult/{baseCountryName}/{comparisonCountryName}")]
	[ProducesResponseType(StatusCodes.Status200OK)]
	[ProducesResponseType(StatusCodes.Status400BadRequest)]
	[ProducesResponseType(StatusCodes.Status404NotFound)]
	public IActionResult GetComparisonResult(string baseCountryName, string comparisonCountryName)
	{
		ComparisonResult countriesResult = null;
		Country baseCountry = new Country();
		Country comparisonCountry = new Country();
		
		if (countries == null || countries.Any() == false) 
		{
			return NotFound();
		} 
		
		if (CountryHelper.getCountryFromList(countries, baseCountryName) == null || CountryHelper.getCountryFromList(countries, comparisonCountryName) == null) {
			return BadRequest();
		}

		baseCountry = CountryHelper.getCountryFromList(countries, baseCountryName);
		comparisonCountry = CountryHelper.getCountryFromList(countries, comparisonCountryName);

        return Ok(new ComparisonResult(baseCountry, comparisonCountry));
	}
}
        