using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.WebApi.Services;

namespace CleanArchitecture.WebApi;

/// <summary>
/// WebApi Dependency
/// </summary>
public static class DependencyInjection
{

    /// <summary>
    /// WebApi Dependency Collection
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
    public static IServiceCollection AddWebServices(
        this IServiceCollection services)
    {


        services.AddHttpContextAccessor();
        services.AddScoped<IUser, CurrentUser>();
        services.AddExceptionHandler<CustomExceptionHandler>();
        return services;
    }
}
