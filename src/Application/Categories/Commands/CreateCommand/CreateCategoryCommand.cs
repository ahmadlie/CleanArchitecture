namespace CleanArchitecture.Application.Categories.Commands.CreateCommand;

public class CreateCategoryCommand : IRequest<int>
{
    public string CategoryName { get; set; }
    public string? Description { get; set; }
}


public class CreaCreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, int>
{

    private readonly ICategoryRepository _repository;
    public CreaCreateCategoryCommandHandler(ICategoryRepository repository)
    {
        _repository = repository;
    }

    public async Task<int> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        var entity = new Category
        {
            CategoryName = request.CategoryName,
            Description = request.Description,
        };


        entity.AddDomainEvent(new CategoryCreatedEvent(entity));
        return await _repository.CreateAsync(entity);
        //_context.Categories.Add(entity);
        //await _context.SaveChangesAsync(cancellationToken);
    }
}