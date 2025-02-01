namespace compare_healthcare_api.Repositories

{
    interface IRepository
    {
        public IEnumerable<T> GetAll<T>();
    }
}