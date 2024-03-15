namespace CleanArchitecture.Infrastructure.Data.Configurations; 
public class ProductConfiguration : BaseAuditableEntityConfiguration<Product>
{
    public override void Configure(EntityTypeBuilder<Product> builder)
    {
        base.Configure(builder);

        builder.Property(p => p.ProductName).HasColumnName("ProductName").HasMaxLength(150).IsRequired();
        builder.Property(p => p.UnitPrice).HasColumnName("UnitPrice").IsRequired(false);
        builder.Property(p => p.UnitsInStock).HasColumnName("UnitsInStock").IsRequired(false);
        builder.Property(p => p.CategoryId).HasColumnName("CategoryId").IsRequired(false);


        builder.HasOne(p => p.Category)         // bir ürünün, bir kategorisi olur
            .WithMany(p => p.Products)          // bir kategori'nin birden fazla ürünü olur
            .HasForeignKey(p => p.CategoryId)   // ürün tablosunda kategoriye ait navigation property
            .OnDelete(DeleteBehavior.Cascade);  // (sosyal mesaj) kategori giderse, ürün gider
    }
}
