using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using compare_healthcare_api.Models;

namespace compare_healthcare_api.Controllers;
[ApiController]
[Route("[controller]")]
public class CountryController: ControllerBase {
	//JSON file used instead of database (focus is mocking, SOLID etc)
	public string _jsonFileString = "Controllers/placeholder-data/test.json";
    [HttpGet(Name = "GetCountry")]
		//use IActionResult and/or throw exceptions correctly
		public string GetCountry()
    {
		string jsonData = System.IO.File.ReadAllText(_jsonFileString);
        IEnumerable<Country>? countries = System.Text.Json.JsonSerializer.Deserialize<IEnumerable<Country>>(jsonData, new JsonSerializerOptions
{
    IncludeFields = true,  // Enables deserialization of fields
});
		//if countries != null 
		//log each country
		if (countries != null)
		{

		foreach (var country in countries) {
    			Console.WriteLine($"Name: {country.countryName}, Customer Opinion: {country.customerOpinion}");
			}
			}
		else
		{
			Console.WriteLine("No countries found in the data.");
		}

		
		
        //Country Britain = new Country("United Kingdom", 36, 18, 8, ukCosts, "Awful");       
        //Console.WriteLine(Britain._costOfTreatment._taxPercentage);
        return "yes";

    }
}
        