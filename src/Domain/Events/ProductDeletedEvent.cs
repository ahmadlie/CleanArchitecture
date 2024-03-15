namespace CleanArchitecture.Domain.Events;

public class ProductDeletedEvent : BaseEvent
{
    public ProductDeletedEvent(Product product)
    {
        this.Product = product;
    }
    public Product Product { get; }
}