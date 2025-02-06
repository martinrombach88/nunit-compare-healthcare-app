//added a reference to the target project on this project (see screenshot 5, 6)
using compare_healthcare_api.CountryModels;
using compare_healthcare_api.CountryRepositories;
using Moq;

namespace compare_healthcare_api_tests;



public class CountryControllerTests
{
    /// <summary>
    /// Arrange: Setup method initialising mocks before each test
    /// </summary>
    /// 
    [SetUp]
    public void Setup()
    {
        //controller method tested
        //mock repository made
        //mock results
        
        CountryRepository countryRepository = new CountryRepository();  
        
    }

    [Test]
    public void GetAll()
    {
        //IEnumerable<Country> countries = 
        //Act
		//The target endpoint fulfills its function
		
        
        
		//Assert
		//The expected result is seen
    }
    
    //test getone
    //test get comparison

    //analyse memory usage and try to use tear downs appropriately
    [TearDown]
    public void TearDown()
    {
        
    }

}
