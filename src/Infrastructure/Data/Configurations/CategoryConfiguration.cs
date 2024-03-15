namespace CleanArchitecture.Infrastructure.Data.Configurations; 
public class CategoryConfiguration : BaseAuditableEntityConfiguration<Category>
{
    public override void Configure(EntityTypeBuilder<Category> builder)
    {
        base.Configure(builder);

        builder.Property(p => p.CategoryName)
            .HasColumnName("CategoryName")
            .HasMaxLength(150).IsRequired();

        builder.Property(p => p.Description)
            .HasColumnName("Description")
            .HasMaxLength(500)
            .IsRequired(false);
    } 
}
