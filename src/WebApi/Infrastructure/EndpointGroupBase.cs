namespace CleanArchitecture.WebApi.Infrastructure;

/// <summary>
/// EndpointGroupBase
/// </summary>
public abstract class EndpointGroupBase
{
    /// <summary>
    /// Map
    /// </summary>
    /// <param name="app"></param>
    public abstract void Map(WebApplication app);
}
