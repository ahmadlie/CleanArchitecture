using Microsoft.EntityFrameworkCore.Diagnostics;

namespace CleanArchitecture.Infrastructure.Data.Interceptors;
public class AuditableEntityInterceptor : SaveChangesInterceptor
{
    private readonly TimeProvider _dateTime;
    private readonly IUser _user;
    public AuditableEntityInterceptor(TimeProvider dateTime, IUser user)
    {
        this._dateTime = dateTime;
        this._user = user;
    }

    public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
    {
        UpdateEntities(eventData.Context);
        return base.SavingChanges(eventData, result);
    }

    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
    {
        UpdateEntities(eventData.Context);
        return base.SavingChangesAsync(eventData, result, cancellationToken);
    }

    public void UpdateEntities(DbContext? context)
    {
        if (context == null) return;
        foreach (var entry in context.ChangeTracker.Entries<BaseAuditableEntity>())
        {
            if (entry.State is EntityState.Added or EntityState.Modified)
            {
                if (entry.State is EntityState.Added)
                {
                    entry.Entity.Created = _dateTime.GetUtcNow();
                    entry.Entity.CreatedBy = _user.Id ?? "CodeEdu";
                }
                entry.Entity.LastModified = _dateTime.GetUtcNow();
                entry.Entity.LastModifiedBy = _user.Id ?? "CodeEdu";
            }
        }
    }
}
