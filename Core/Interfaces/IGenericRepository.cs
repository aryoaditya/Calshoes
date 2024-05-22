using Core.Models;

namespace Core.Interfaces
{
    public interface IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        Task<IReadOnlyList<TEntity>>GetAllAsync();
        Task<TEntity>GetByIdAsync(int id);
        Task<IReadOnlyList<TEntity>> GetAllWithSpecAsync(ISpecification<TEntity> spec);
        Task<TEntity> GetByIdWithSpecAsync(ISpecification<TEntity> spec);
	    Task<int> CountAsync(ISpecification<TEntity> spec);
    }
}