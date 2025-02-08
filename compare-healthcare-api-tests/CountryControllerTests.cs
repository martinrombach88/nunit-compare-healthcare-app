//added a reference to the target project (compare-healthcare-api)
//on this project (see screenshot 5, 6)
using compare_healthcare_api.Repositories;
using compare_healthcare_api.Controllers;
using compare_healthcare_api.CountryModels;
using Moq;
using Microsoft.AspNetCore.Mvc;

namespace compare_healthcare_api_tests;
[TestFixture]
/// <summary>
/// Tests for the methods in the CountryController
/// </summary>
/// 
public class CountryControllerTests
{
    private Mock<ICountryRepository> _mockCountryRepo;
    private CountryController _controller;
   
    [SetUp]
    public void Setup()
    {
        //Arrange generate mock repository interface
        //and pass to controller
        _mockCountryRepo = new Mock<ICountryRepository>();
        _controller = new CountryController(_mockCountryRepo.Object);
        
        IEnumerable<Country> successCountries = new List<Country>
        {
            new Country {aAndEHoursWait = 24, countryName = "LoserLand", monthWaitingListDelay = 12, rank = 2, customerOpinion = "awful", costOfTreatment = new CostOfTreatment {cashPercentage = 0, taxPercentage = 100}},
            new Country {aAndEHoursWait = 2, countryName = "WinnerLand", monthWaitingListDelay = 3, rank =1, customerOpinion = "great", costOfTreatment = new CostOfTreatment {cashPercentage = 50, taxPercentage = 50}}

        };
        
        _mockCountryRepo.Setup(repo => repo.GetAll<Country>()).Returns(fakeCountries);
        
    }
    
    //you have progress here. implement these inputs and you have tests
    [TestCase(fakeCountries, ExpectedResult = true) ]
    [TestCase(null, ExpectedResult = NotFoundObjectResult())]
    public IActionResult GetAllEndpointReturnsListOfCountries()
    {
        //Arrange - init fake data for tests
        IActionResult result = _controller.GetCountries();
       // return countries != null ? Ok(countries) : NotFound();
       
    }
}
