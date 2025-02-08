namespace compare_healthcare_api.Repositories

{
    public interface IRepository
    {
        public IEnumerable<T> GetAll<T>();
    }
}