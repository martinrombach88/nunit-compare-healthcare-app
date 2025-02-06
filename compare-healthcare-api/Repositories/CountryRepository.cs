using compare_healthcare_api.Data;
using compare_healthcare_api.CountryModels;
using compare_healthcare_api.Repositories;
using System.Text.Json;
namespace compare_healthcare_api.CountryRepositories
{
    public class CountryRepository : Repository
    {
        //json file path replaces the config file
        private DataContext _dataContext = new DataContext("Data/json-files/countries.json");

        public IEnumerable<Country> getItems<Country>()
        {
            return _dataContext.getItems<Country>();
        }

        public Country getCountry(string countryName)
        {
            //Can you make this generic without the db?
            IEnumerable<Country> countries = _dataContext.getItems<Country>();
            return countries.SingleOrDefault(countries => String.Equals(countries.countryName, countryName, StringComparison.OrdinalIgnoreCase));
        }
    }
    
}