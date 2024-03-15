namespace CleanArchitecture.Domain.Events;

public class CategoryDeletedEvent : BaseEvent
{
    public CategoryDeletedEvent(Category category)
    {
        this.Category = category;
    }
    public Category Category { get; }
}