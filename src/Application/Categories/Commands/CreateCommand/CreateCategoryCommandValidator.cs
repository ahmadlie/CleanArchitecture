namespace CleanArchitecture.Application.Categories.Commands.CreateCommand;

public class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
{
    public CreateCategoryCommandValidator()
    {
        RuleFor(v => v.CategoryName)
            .MaximumLength(150).WithMessage(Messages.CategoryNameMaxLength)
            .NotEmpty().WithMessage(Messages.CategoryNameNotNull);
    }
}
