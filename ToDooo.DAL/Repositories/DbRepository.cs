using Microsoft.EntityFrameworkCore;
using ToDooo.DAL.Context;
using ToDooo.Interfaces;

namespace ToDooo.DAL.Repositories
{
    internal class DbRepository<T> : IRepository<T> where T : Entity.Base.Entity, new ()
    {
        private readonly GoalDb _db;
        private readonly DbSet<T> _set;

        public bool AutoSaveChanges { get; set; } = true;

        public DbRepository(GoalDb db)
        {
            _db = db;
            _set = _db.Set<T>();
        }

        public IQueryable<T> Items => _set;

        public T Add(T entity)
        {
            if(entity == null) throw new ArgumentNullException(nameof(entity));
            _db.Entry(entity).State = EntityState.Added;
            if(AutoSaveChanges) 
                _db.SaveChanges();
            return entity;

        }
        public async Task<T> AddAsync(T entity, CancellationToken cancel = default)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            _db.Entry(entity).State = EntityState.Added;
            if (AutoSaveChanges)
                _db.SaveChangesAsync(cancel).ConfigureAwait(false);
            return entity;
        }
        public T Get(int id) => Items.SingleOrDefault(entity => entity.Id == id);
        public async Task<T> GetAsync(int id, CancellationToken cancel = default) => await Items
            .SingleOrDefaultAsync(entity => entity.Id == id, cancel = cancel)
            .ConfigureAwait(false);

        public void Remove(int id)
        {
            _db.Remove(new T { Id = id });

            if (AutoSaveChanges)
                _db.SaveChanges();
        }
        public async Task RemoveAsync(int id, CancellationToken cancel = default)
        {
            _db.Remove(new T { Id = id });

            if (AutoSaveChanges)
                await _db.SaveChangesAsync(cancel).ConfigureAwait(false);
        }
        public void Update(T entity)
        {
            if (entity is null) throw new ArgumentNullException(nameof(entity));
            _db.Entry(entity).State = EntityState.Added;
            if (AutoSaveChanges)
                _db.SaveChanges();
        }
        public async void UpdateAsync(T entity, CancellationToken cancel = default)
        {
            if (entity is null) throw new ArgumentNullException(nameof(entity));
            _db.Entry(entity).State = EntityState.Added;
            if (AutoSaveChanges)
                await _db.SaveChangesAsync(cancel).ConfigureAwait(false);
        }
    }
}
