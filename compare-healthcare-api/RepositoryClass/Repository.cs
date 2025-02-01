using System.Collections.Generic;
using compare_healthcare_api.Data;

namespace compare_healthcare_api.Repositories
{
    public class Repository : IRepository
    {
        private readonly DataContext _dataContext;
        
 

        public IEnumerable<T> GetAll<T>()
        {
            return _dataContext.getItems<T>();
        }

    }
}