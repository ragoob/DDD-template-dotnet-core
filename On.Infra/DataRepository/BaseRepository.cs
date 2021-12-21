using Microsoft.EntityFrameworkCore;
using On.Core.Entites;
using On.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace On.Infra.DataRepository
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
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
        public void Delete(Guid id)
        {
            _entities.Remove(_entities.Find(id));
        }

        public async Task<TEntity> FristAsync(Guid id)
        {
            return await _entities.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _entities.ToListAsync();
        }

        public async Task<TEntity> GetAsync(Guid id)
        {
           return  await _entities.FindAsync(id);
        }
    }
}
