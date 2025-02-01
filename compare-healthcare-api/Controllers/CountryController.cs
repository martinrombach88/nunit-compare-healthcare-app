using Microsoft.AspNetCore.Mvc;
using compare_healthcare_api.CountryModels;
using compare_healthcare_api.Repositories;
using compare_healthcare_api.Data;
using compare_healthcare_api.CountryRepositories;

namespace compare_healthcare_api.Controllers;
[ApiController]
[Route("/Country/")]

public class CountryController: ControllerBase {
	
	CountryRepository countryRepository = new CountryRepository();
	
	[HttpGet("GetCountries")]
	[ProducesResponseType(StatusCodes.Status200OK)]
	[ProducesResponseType(StatusCodes.Status404NotFound)]
	public IActionResult GetCountries()
	{	
		IEnumerable<Country> countries = countryRepository.getItems<Country>();
		return countries != null ? Ok(countries) : NotFound();
	}
	
	[HttpGet("GetCountry/{countryName}")]
	[ProducesResponseType(StatusCodes.Status200OK)]
	[ProducesResponseType(StatusCodes.Status400BadRequest)]
	[ProducesResponseType(StatusCodes.Status404NotFound)]
	public IActionResult GetCountry(string countryName)
	{
		Country country = countryRepository.getCountry(countryName);
		
		if (country == null) 
		{
			return BadRequest();
		}
		return Ok(country);
	}
	
	
	//comparison of two countries is generated here, the controller acting as
	//a 'client' whilst the data context and repository remain unopinionated about the data
	[HttpGet("GetComparisonResult/{baseCountryName}/{comparisonCountryName}")]
	[ProducesResponseType(StatusCodes.Status200OK)]
	[ProducesResponseType(StatusCodes.Status400BadRequest)]
	public IActionResult GetComparisonResult(string baseCountryName, string comparisonCountryName)
	{
		ComparisonResult countriesResult = null;
		Country baseCountry = countryRepository.getCountry(baseCountryName);
		Country comparisonCountry =  countryRepository.getCountry(comparisonCountryName);

		if (baseCountry == null || comparisonCountry == null) {
			return BadRequest();
		}

        return Ok(new ComparisonResult(baseCountry, comparisonCountry));
	}
	
}
        