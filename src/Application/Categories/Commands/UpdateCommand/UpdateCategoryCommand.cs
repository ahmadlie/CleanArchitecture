
namespace CleanArchitecture.Application.Categories.Commands.UpdateCommand;

public class UpdateCategoryCommand : IRequest<int>
{
    public int Id { get; set; }
    public string CategoryName { get; set; }
    public string? Description { get; set; }
}

public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, int>
{
    private readonly ICategoryRepository _categoryRepository;

    public UpdateCategoryCommandHandler(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<int> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = await _categoryRepository.GetByIdAsync(request.Id);

        category.CategoryName = request.CategoryName;
        category.Description = request.Description;

        await _categoryRepository.Update(category);

        return request.Id;
    }
}

