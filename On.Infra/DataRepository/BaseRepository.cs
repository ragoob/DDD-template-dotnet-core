using Microsoft.EntityFrameworkCore;
using On.Core.Entites;
using On.Core.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace On.Infra.DataRepository
{
    public abstract class BaseRepository<TEntity, TIdentity> : IBaseRepository<TEntity, TIdentity> where TEntity : BaseEntity<TIdentity>
    {
        private DbSet<TEntity>  _entities;
        public BaseRepository(OnContext onContext)
        {
            _entities = onContext.Set<TEntity>();
        }
        public void Add(TEntity entity)
        {
            _entities.Add(entity);
        }
        public void Delete(TIdentity id)
        {
            _entities.Remove(_entities.Find(id));
        }

        public async Task<TEntity> FristAsync(TIdentity id)
        {
            return await _entities.FirstOrDefaultAsync(c => c.Id.Equals(id));
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _entities.ToListAsync();
        }

        public async Task<TEntity> GetAsync(TIdentity id)
        {
           return  await _entities.FindAsync(id);
        }
    }
}
