namespace CleanArchitecture.Application.Categories.Commands.DeleteCommand;

public record DeleteCategoryCommand(int id) : IRequest<int>;

