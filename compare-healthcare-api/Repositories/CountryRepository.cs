using compare_healthcare_api.CountryModels;
using compare_healthcare_api.Data;

namespace compare_healthcare_api.Repositories
{
    public class CountryRepository : ICountryRepository
    {
        //stretch goal -> fully implement swagger data context and db
        private DataContext _dataContext = new ("Data/json-files/countries.json");

        public IEnumerable<Country> GetAll<Country>()
        {
            return _dataContext.GetItems<Country>();
        }

        public Country GetCountry(string countryName)
        {
            //Can you make this generic without the db?
            IEnumerable<Country> countries = _dataContext.GetItems<Country>();
            return countries.SingleOrDefault(countries => String.Equals(countries.countryName, countryName, StringComparison.OrdinalIgnoreCase));
        }


    }
    
}