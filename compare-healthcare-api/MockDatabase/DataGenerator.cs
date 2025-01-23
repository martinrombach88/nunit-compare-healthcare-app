using System.Text.Json;

namespace compare_healthcare_api.MockDatabase;

public class DataGenerator
{
    //Open Closed Principle
    //These methods should be reusable and know nothing about the <T> that is used here.

    public static string getJsonData(string jsonFilePath)
    {
        return System.IO.File.ReadAllText(jsonFilePath);
    }

    public static IEnumerable<T> generateDataList<T>(string jsonDataString)
    {
        return System.Text.Json.JsonSerializer.Deserialize<IEnumerable<T>>
            (jsonDataString, new JsonSerializerOptions{IncludeFields = true});
    }
    /*
    public static T getItemFromList(IEnumerable<T> items, string itemName)
    {
        //csharp linq creates concise syntax similar to for each (singleOrDefault accounts for errors)
        return items.SingleOrDefault(items =>
            String.Equals(items.itemName, itemName, StringComparison.OrdinalIgnoreCase));
    }
    */
}

