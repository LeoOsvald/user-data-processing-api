namespace UserDataProcessingApi.Repository
{

    public interface IMongoDbRepository<T>
    {
        Task<List<T>> GetAllAsync();
        Task<T> GetByIdAsync(string id);
        Task InsertAsync(T entity);
        Task InsertManyAsync(IEnumerable<T> entities);
        Task UpdateAsync(string id, T entity);
        Task DeleteAsync(string id);
    }

}
