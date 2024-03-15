using CleanArchitecture.Infrastructure.Data;

namespace CleanArchitecture.Infrastructure.Services;

public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
{
    public CategoryRepository(ApplicationDbContext context) : base(context) { }
}
