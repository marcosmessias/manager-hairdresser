using Microsoft.EntityFrameworkCore;
using ManagerHairdresser.Data.Context;
using ManagerHairdresser.Domain.Interfaces.Repositories.Shared;
using ManagerHairdresser.Domain.Entities.Shared;

namespace ManagerHairdresser.Data.Repositories.Shared
{

    public abstract class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : Entity
    {
        protected readonly DataContext Context;

        public RepositoryBase(DataContext dataContext) =>
            Context = dataContext;

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync() =>
            await Context.Set<TEntity>()
                .AsNoTracking()
                .ToListAsync();

        public virtual async Task<TEntity?> GetByIdAsync(int id) =>
            await Context.Set<TEntity>().FindAsync(id);

        public virtual async Task<object> AddAsync(TEntity objeto)
        {
            Context.Add(objeto);
            await Context.SaveChangesAsync();
            return objeto.Id;
        }

        public virtual async Task UpdateAsync(TEntity objeto)
        {
            Context.Entry(objeto).State = EntityState.Modified;
            await Context.SaveChangesAsync();
        }

        public virtual async Task DeleteAsync(TEntity objeto)
        {
            Context.Set<TEntity>().Remove(objeto);
            await Context.SaveChangesAsync();
        }

        public virtual async Task DeleteByIdAsync(int id)
        {
            var objeto = await GetByIdAsync(id);
            if (objeto == null)
                throw new Exception("O registro não existe na base de dados.");
            await DeleteAsync(objeto);
        }

        public void Dispose() =>
            Context.Dispose();
    }
}
