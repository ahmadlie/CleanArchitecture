namespace CleanArchitecture.Domain.Entities;
public class Category : BaseAuditableEntity
{
    public string CategoryName { get; set; }
    public string? Description { get; set; }

    public ICollection<Product> Products { get; set; }
}
