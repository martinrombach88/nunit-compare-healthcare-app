using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace compare_healthcare_api.Data
{
    public class DataContext
    {
    //Open Closed Principle
    //These methods should be reusable and know nothing about the <T> that is used here.
    private string _jsonDataString;
    
        public DataContext(string jsonFilePath)
        {
            _jsonDataString =  System.IO.File.ReadAllText(jsonFilePath);
        }

        public IEnumerable<T> getItems<T>()
        {
            return System.Text.Json.JsonSerializer.Deserialize<IEnumerable<T>>
                (_jsonDataString, new JsonSerializerOptions { IncludeFields = true });
        }
        
    }
}
