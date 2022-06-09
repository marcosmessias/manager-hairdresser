using ManagerHairdresser.Domain.Entities.Shared;

namespace ManagerHairdresser.Domain.Interfaces.Repositories.Shared
{
    public interface IRepositoryBase<TEntity> : IDisposable where TEntity : Entity
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity?> GetByIdAsync(int id);
        Task<object> AddAsync(TEntity objeto);
        Task UpdateAsync(TEntity objeto);
        Task DeleteAsync(TEntity objeto);
        Task DeleteByIdAsync(int id);
    }
}
