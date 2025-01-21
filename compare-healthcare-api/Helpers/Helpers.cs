using compare_healthcare_api.Models;

namespace compare_healthcare_api.Helpers;
public class CountryHelper
{
    
    public static void logCountryList(IEnumerable<Country> countries)
    {
        foreach (var country in countries) {
            Console.WriteLine($"Name: {country.countryName}, Customer Opinion: {country.customerOpinion}");
        }
    }

    public static Country getCountryFromList(IEnumerable<Country> countries, string countryName)
    {
        //csharp linq creates concise syntax similar to for each (singleOrDefault accounts for errors)
        return countries.SingleOrDefault(listCountry =>
            String.Equals(listCountry.countryName, countryName, StringComparison.OrdinalIgnoreCase));
    }
}

public class JSONDataHelper
{
    
}