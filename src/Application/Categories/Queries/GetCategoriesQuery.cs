
namespace CleanArchitecture.Application.Categories.Queries;
public class GetCategoriesQuery : IRequest<IEnumerable<Category>> { }


public class GetCategoriesQueryHandler : IRequestHandler<GetCategoriesQuery, IEnumerable<Category>>
{
    private readonly ICategoryRepository _categoryRepository;

    public GetCategoriesQueryHandler(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<IEnumerable<Category>> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
    {
        return await _categoryRepository.GetAllAsync(false, null, null);
    }
}

