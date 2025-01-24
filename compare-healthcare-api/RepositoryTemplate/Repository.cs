namespace compare_healthcare_api.Repositories
namespace compare_healthcare_api.MockDataContext

public class Repository<T> : IRepository
{
    private readonly DataContext _dataContext;
    private readonly DataFilePath _dataFilePath;

    public Repository(DataContext dataContext, string dataFilePath)
    {
        _dataContext = dataContext;
        _dataFilePath = dataFilePath;
        //explore this
        //_dbSet = _context.Set<T>();
    }

    public getByName(IENumerable<T> items, string name)
    {
        return _dataContext.getItemByName(items, name);
    }
    public IENumerable<T> GetAll();
    {
        return _context.generateDataList(_dataFilePath);
    }
    
    
}