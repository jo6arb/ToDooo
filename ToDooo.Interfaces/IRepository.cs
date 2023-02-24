namespace ToDooo.Interfaces
{
    public interface IRepository <T> where T : class, IEntity, new()
    {
        IQueryable<T> Items { get; }

        T Get(int id);
        Task<T> GetAsync(int id, CancellationToken cancel = default);

        T Add(T entity);
        Task<T> AddAsync(T entity, CancellationToken cancel = default);

        void Update(T entity);
        void UpdateAsync(T entity, CancellationToken cancel = default);

        void Remove(int id);
        Task RemoveAsync(int id, CancellationToken cancel = default);
    }
}
