using CleanArchitecture.Domain.Common;
using System.Linq.Expressions;

namespace CleanArchitecture.Application.Common.Interfaces;

public interface IGenericRepository<TEntity> where TEntity : BaseEntity
{
    Task<int> CreateAsync(TEntity entity);
    Task<int> Update(TEntity entity);
    Task<int> Delete(TEntity entity);
    Task<TEntity> GetByIdAsync(int id);
    Task<IEnumerable<TEntity>> GetAllAsync(bool isTracking, Expression<Func<TEntity, bool>> expression = null,
                                          params string[] includes);
}
