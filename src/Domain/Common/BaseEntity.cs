using System.ComponentModel.DataAnnotations.Schema;

namespace CleanArchitecture.Domain.Common;
public class BaseEntity
{
    public int Id { get; set; }



    private readonly List<BaseEvent> _domainEvents = new();

    [NotMapped]
    public IReadOnlyCollection<BaseEvent> DomainEvents => _domainEvents.AsReadOnly();


    /// <summary>
    /// Add new Event
    /// </summary>
    /// <param name="domainEvent"></param>
    public void AddDomainEvent(BaseEvent domainEvent) => this._domainEvents.Add(domainEvent);

    /// <summary>
    /// Remove current Event
    /// </summary>
    /// <param name="domainEvent"></param>
    public void RemoveDomainEvent(BaseEvent domainEvent) => this._domainEvents.Remove(domainEvent);

    /// <summary>
    /// Create all Events
    /// </summary>
    public void ClearDomainEvents() => this._domainEvents.Clear();

}
