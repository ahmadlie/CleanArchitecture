namespace CleanArchitecture.Infrastructure.Data.Configurations;
public abstract class BaseAuditableEntityConfiguration<T> : IEntityTypeConfiguration<T> where T : BaseAuditableEntity
{
    public virtual void Configure(EntityTypeBuilder<T> builder)
    {
        builder.Property(p => p.Id).HasColumnName("Id").IsRequired();  // default -> true
        builder.Property(p => p.Created).HasColumnName("Created");
        builder.Property(p => p.CreatedBy).HasColumnName("CreatedBy").HasMaxLength(100).IsRequired();
        builder.Property(p => p.LastModified).HasColumnName("LastModified");
        builder.Property(p => p.LastModifiedBy).HasColumnName("LastModifiedBy").HasMaxLength(100).IsRequired(false);
    }
}
