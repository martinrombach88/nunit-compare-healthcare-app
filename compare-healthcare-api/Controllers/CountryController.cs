using Microsoft.AspNetCore.Mvc;

using compare_healthcare_api.CountryModels;
using compare_healthcare_api.MockDatabase;

namespace compare_healthcare_api.Controllers;
[ApiController]
[Route("/")]

public class CountryController: ControllerBase {
	internal static string jsonData = DataGenerator.getJsonData("MockDatabase/json-files/countries.json");
	internal static IEnumerable<Country>? countries = DataGenerator.generateDataList<Country>(jsonData);

    [HttpGet("GetCountries")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
	public IActionResult GetCountries()
    {	
	    return countries != null ? Ok(countries) : NotFound();
    }
	/*
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
	*/
}
        