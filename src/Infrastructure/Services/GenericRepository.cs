using CleanArchitecture.Infrastructure.Data;
using System.Linq.Expressions;

namespace CleanArchitecture.Infrastructure.Services;

public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity
{
    private readonly ApplicationDbContext _context;
    public DbSet<TEntity> Entites { get => _context.Set<TEntity>(); }
    public GenericRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> CreateAsync(TEntity entity)
    {
        await Entites.AddAsync(entity);
        await _context.SaveChangesAsync();
        return entity.Id;
    }

    public async Task<int> Delete(TEntity entity)
    {
        Entites.Remove(entity);
        await _context.SaveChangesAsync();
        return entity.Id;
    }

    public async Task<IEnumerable<TEntity>> GetAllAsync(bool isTracking = false,
        Expression<Func<TEntity, bool>>? expression = null, params string[] includes)
    {

        var query = GetIncludes(includes);
        if (isTracking && expression is not null) return query.Where(expression);
        return await query.AsNoTracking().AsNoTrackingWithIdentityResolution().ToListAsync();
    }

    private IQueryable<TEntity> GetIncludes(params string[] includes)
    {
        IQueryable<TEntity> query = Entites;
        foreach (var item in includes)
        {
            query = query.Include(item);
        }
        return query;
    }

    public async Task<TEntity> GetByIdAsync(int id)
    {
        return await Entites.FindAsync(id);
    }

    public async Task<int> Update(TEntity entity)
    {
        Entites.Update(entity);
        await _context.SaveChangesAsync();
        return entity.Id;
    }
}
