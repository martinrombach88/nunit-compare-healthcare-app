using System.Text.Json;

namespace compare_healthcare_api.MockDataContext

public class DataContext
{
    //Open Closed Principle
    //These methods should be reusable and know nothing about the <T> that is used here.
    
    public IEnumerable<T> generateDataList<T>(string jsonFilePath)
    {
        string jsonDataString = System.IO.File.ReadAllText(jsonFilePath);
        return System.Text.Json.JsonSerializer.Deserialize<IEnumerable<T>>
            (jsonDataString, new JsonSerializerOptions{IncludeFields = true});
    }
    
    
    
    public T getItemByName(IEnumerable<T> items, string itemName)
    {
        
        return items.SingleOrDefault(items =>
            String.Equals(items.itemName, itemName, StringComparison.OrdinalIgnoreCase));
    }
    
}

