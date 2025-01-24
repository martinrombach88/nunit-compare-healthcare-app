namespace compare_healthcare_api.Repositories

public interface IRepository<T>
{
    IENumerable<T> GetAll();
    T GetById(int id);
    T GetByName(string name);
    
    //comparison result endpoint, obj1 and obj2
    //are different types to return type
    T GetByObjects (T obj1, T obj2);
    void Add(T item);
    void Update(T item);
    void Delete(T item);
}