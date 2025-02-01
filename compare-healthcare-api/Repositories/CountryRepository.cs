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
    }
    
}