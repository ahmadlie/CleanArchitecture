namespace CleanArchitecture.Domain.Events;

public class ProductCreatedEvent : BaseEvent
{
    public ProductCreatedEvent(Product product)
    {
        this.Product = product;
    }
    public Product Product { get; }
}
