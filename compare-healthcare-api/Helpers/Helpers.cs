using compare_healthcare_api.Models;

namespace compare_healthcare_api.Helpers;
public class Helpers
{
    
    public void logCountryList(IEnumerable<Country> countries)
    {
        foreach (var country in countries) {
            Console.WriteLine($"Name: {country.countryName}, Customer Opinion: {country.customerOpinion}");
        }
    }
}