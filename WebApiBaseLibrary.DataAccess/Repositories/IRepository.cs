using System;
using System.Threading.Tasks;
using WebApiBaseLibrary.DataAccess.Entities;

namespace WebApiBaseLibrary.DataAccess.Repositories
{
    public interface IRepository<TEntity>
        where TEntity : BaseEntity
    {
        public void Create(TEntity entity);
        public Task CreateAsync(TEntity entity);

        public void Update(TEntity entity);
        public Task UpdateAsync(TEntity entity);

        public TEntity Get(Guid id);
        public Task<TEntity> GetAsync(Guid id);

        public void Delete(Guid id);
        public Task DeleteAsync(Guid id);

        public bool ExistsWithId(Guid id);
        public Task<bool> ExistsWithIdAsync(Guid id);
    }
}