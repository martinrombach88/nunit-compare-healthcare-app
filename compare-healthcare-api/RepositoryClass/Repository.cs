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
/*
        public T GetItemByString<T>(string paramString)
        {
            IEnumerable<T> items = _dataContext.getItems<T>();
			//return items.FirstOrDefault(i
		}*/
			/*
            User? user = _entityFramework.Users
                .Where(u => u.UserId == userId)
                .FirstOrDefault<User>();

            if (user != null)
            {
                return user;
            }
            
            throw new Exception("Failed to Get User");
			*/
            //add a generic search of the list.
            //Normally you would just make a call to the db so this is actually harder...
        
    }
}