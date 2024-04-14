using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Web_App.Data;
using Web_App.Interfaces;
using Web_App.Models;
using Web_App.ViewModels;

namespace Web_App.Repository
{
    public abstract class Repository<TEntity>(ApplicationDbContext database) : IRepository<TEntity>
        where TEntity : Entity, new()
    {
        protected readonly ApplicationDbContext Database = database;
        protected readonly DbSet<TEntity> DatabaseSet = database.Set<TEntity>();

        public async Task<IEnumerable<TEntity>> Search(Expression<Func<TEntity, bool>> predicate)
        {
            return await DatabaseSet.AsNoTracking().Where(predicate).ToListAsync();
        }

        public virtual async Task<TEntity> GetById(Guid id)
        {
            return await DatabaseSet.FindAsync(id); // Se der erro no futuro, provavelmente é aqui! Teste --> return await DatabaseSet.FindAsync(id);
        }

        public virtual async Task<List<TEntity>> GetAll()
        {
            return await DatabaseSet.ToListAsync();
        }

        public virtual async Task Add(TEntity entity)
        {
            DatabaseSet.Add(entity);
            await SaveChanges();
        }

        public virtual async Task Update(TEntity entity)
        {
            DatabaseSet.Update(entity);
            await SaveChanges();
        }

        public virtual async Task Delete(Guid id)
        {
            DatabaseSet.Remove(new TEntity { Id = id });
            await SaveChanges();
        }

        public async Task<int> SaveChanges()
        {
            return await Database.SaveChangesAsync();
        }

        public void Dispose()
        {
            Database?.Dispose();
        }
    }
}
