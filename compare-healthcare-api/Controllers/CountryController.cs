using Microsoft.AspNetCore.Mvc;
using compare_healthcare_api.CountryModels;
using compare_healthcare_api.Repositories;
using compare_healthcare_api.Data;
using compare_healthcare_api.CountryRepositories;

namespace compare_healthcare_api.Controllers;
[ApiController]
[Route("/Country/")]

public class CountryController: ControllerBase {
	
	[HttpGet("GetCountries")]
	[ProducesResponseType(StatusCodes.Status200OK)]
	[ProducesResponseType(StatusCodes.Status404NotFound)]
	public IActionResult GetCountries()
	{	
		CountryRepository countryRepository = new CountryRepository();
		IEnumerable<Country> countries = countryRepository.getItems<Country>();
		return countries != null ? Ok(countries) : NotFound();
	}
	
	//comparison result should be generated here. 
	//the repository is unopinionated, so the controller should handle
	//get calls, calling repository.get() twice with the two string inputs.
	//if the controller acts on this data and returns a result class,
	//it should be done here, the controller being the 'client' in this situation.
	/*internal static IEnumerable<Country>? countries = DataGenerator.generateDataList<Country>
		(DataGenerator.getJsonData("MockDatabase/json-files/countries.json"));


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
        