using compare_healthcare_api.CountryModels;
using compare_healthcare_api.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace compare_healthcare_api.Controllers;
[ApiController]
[Route("/Country/")]

public class CountryController: ControllerBase
{

	private readonly ICountryRepository _iCountryRepository;

	public CountryController(ICountryRepository countryRepository)  // DI through constructor
	{
		_iCountryRepository = countryRepository;
	}
	
	
	[HttpGet("GetCountries")]
	[ProducesResponseType(StatusCodes.Status200OK)]
	[ProducesResponseType(StatusCodes.Status404NotFound)]
	public IActionResult GetCountries()
	{	
		IEnumerable<Country> countries = _iCountryRepository.GetAll<Country>();
		return countries != null ? Ok(countries) : NotFound();
	}
	
	[HttpGet("GetCountry/{countryName}")]
	[ProducesResponseType(StatusCodes.Status200OK)]
	[ProducesResponseType(StatusCodes.Status400BadRequest)]
	[ProducesResponseType(StatusCodes.Status404NotFound)]
	public IActionResult GetCountry(string countryName)
	{
		Country country = _iCountryRepository.GetCountry(countryName);
		
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
		Country baseCountry = _iCountryRepository.GetCountry(baseCountryName);
		Country comparisonCountry =  _iCountryRepository.GetCountry(comparisonCountryName);

		if (baseCountry == null || comparisonCountry == null) {
			return BadRequest();
		}

        return Ok(new ComparisonResult(baseCountry, comparisonCountry));
	}
	
}
        