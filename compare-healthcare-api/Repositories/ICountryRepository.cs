using compare_healthcare_api.CountryModels;

namespace compare_healthcare_api.Repositories;

public interface ICountryRepository : IRepository
{
    public Country GetCountry(string countryName);

}