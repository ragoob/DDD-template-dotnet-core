using On.Core.Entites;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace On.Core.Repositories
{
    public interface IBaseRepository<TEntity> where TEntity : BaseEntity
    {
         Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> GetAsync(Guid id);
        Task<TEntity> FristAsync(Guid id);
        void Delete(Guid id);
        void Add(TEntity entity);

    }
}
