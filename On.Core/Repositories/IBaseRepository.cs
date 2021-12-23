using On.Core.Entites;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace On.Core.Repositories
{
    public interface IBaseRepository<TEntity, TIdentity> where TEntity : BaseEntity<TIdentity>
    {
         Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> GetAsync(TIdentity id);
        Task<TEntity> FristAsync(TIdentity id);
        void Delete(TIdentity id);
        void Add(TEntity entity);

    }
}
