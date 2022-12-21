using Microsoft.EntityFrameworkCore;

namespace UnitTest.Web.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
    
        private readonly DbSet<TEntity> _entities;
        public Repository(DbSet<TEntity> entities)
        {
            _entities = entities;
        }

        public async Task Create(TEntity entity)
        {
          await _entities.AddAsync(entity);
        }

        public void Delete(TEntity entity)
        {
           _entities.Remove(entity);
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await _entities.ToListAsync();
        }

        public async Task<TEntity> GetById(int id)
        {
            return await _entities.FindAsync(id);
        }

        public void Update(TEntity entity)
        {
          _entities.Update(entity);
        }
    }
}
