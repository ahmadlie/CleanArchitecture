namespace CleanArchitecture.Domain.Events;
public class CategoryCreatedEvent : BaseEvent
{
    public CategoryCreatedEvent(Category category)
    {
        this.Category = category;
    }
    public Category Category { get; }
}
