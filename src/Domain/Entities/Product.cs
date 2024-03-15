namespace CleanArchitecture.Domain.Entities;
public class Product : BaseAuditableEntity
{
    public string ProductName { get; set; }
    public decimal? UnitPrice { get; set; }
    public int? UnitsInStock { get; set; }

    /// <summary>
    /// Navigation Property
    /// </summary>
    public int? CategoryId { get; set; }
    public Category? Category { get; set; }
}
