namespace compare_healthcare_api_tests;
using Moq;


public class Tests
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
