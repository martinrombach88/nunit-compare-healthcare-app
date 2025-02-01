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
        
        //you can't make singleordefault comparisons on classes that don't exist yet.
        //come back to this and have a simple 'get items' end point running first.
        
        //public T getItemByName<T>()
        //{
         //   IEnumerable<T> items = getItems<T>();

            
                //return items.SingleOrDefault(items =>
                  //  String.Equals(items.itemName, itemName, StringComparison.OrdinalIgnoreCase));
            
            //you are running a comparison on a list that doesn't contain
            //the field .itemName yet.

        //}

    }
}
