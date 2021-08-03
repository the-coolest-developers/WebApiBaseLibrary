using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApiBaseLibrary.DataAccess.Entities;

namespace WebApiBaseLibrary.DataAccess.Repositories
{
    public class EntityFrameworkBaseRepository<TEntity> : IRepository<TEntity>, IDatabaseRepository
        where TEntity : BaseEntity
    {
        private DbContext EntityContext { get; }
        protected DbSet<TEntity> EntityDbSet => EntityContext.Set<TEntity>();

        public EntityFrameworkBaseRepository(DbContext entityContext)
        {
            EntityContext = entityContext;
        }

        public virtual void Create(TEntity entity)
        {
            EntityDbSet.Add(entity);
        }

        public virtual async Task CreateAsync(TEntity entity)
        {
            await EntityDbSet.AddAsync(entity);
        }

        public virtual void Update(TEntity entity)
        {
            EntityDbSet.Update(entity);
        }

        public virtual Task UpdateAsync(TEntity entity)
        {
            Update(entity);
            return Task.CompletedTask;

            //return Task.FromResult(EntityDbSet.Update(entity));
        }

        public virtual TEntity Get(Guid id)
        {
            return EntityDbSet.Find(id);
        }

        public virtual async Task<TEntity> GetAsync(Guid id)
            => await EntityDbSet.FindAsync(id);

        public virtual void Delete(Guid id)
        {
            var entity = Get(id);

            EntityDbSet.Remove(entity);
        }

        public virtual async Task DeleteAsync(Guid id)
        {
            var entity = await GetAsync(id);

            EntityDbSet.Remove(entity);
        }

        public virtual bool ExistsWithId(Guid id) => EntityDbSet.Any(entity => entity.Id == id);

        public virtual Task<bool> ExistsWithIdAsync(Guid id) => EntityDbSet.AnyAsync(entity => entity.Id == id);

        public virtual void SaveChanges()
        {
            EntityContext.SaveChanges();
        }

        public virtual Task SaveChangesAsync() => EntityContext.SaveChangesAsync();
    }
}