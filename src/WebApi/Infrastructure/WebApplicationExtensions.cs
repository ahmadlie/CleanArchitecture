using System.Reflection;

namespace CleanArchitecture.WebApi.Infrastructure;

public static class WebApplicationExtensions
{
    public static RouteGroupBuilder MapGroup(this WebApplication app, EndpointGroupBase group )
    {
        var version = group.GetVersion(); 
        var groupName = group.GetType().Name;



        return app.MapGroup($"/api/{version}/{groupName}")
            .WithGroupName($"{groupName} V{version}")
            .WithName($"{groupName}V{version}")
            .WithTags($"{groupName} V{version}")
            .WithOpenApi();

    }


    public static WebApplication MapEndpoints(this WebApplication app)
    {
        var endpointGroupType = typeof(EndpointGroupBase);
        var assembly = Assembly.GetExecutingAssembly();

        var enpointGroptypes = assembly
            .GetExportedTypes()
            .Where(t => t.IsSubclassOf(endpointGroupType) && !t.IsAbstract);

        foreach (var type in enpointGroptypes)
        {
            if (Activator.CreateInstance(type) is EndpointGroupBase instance)
            {
                instance.Map(app);
            }
        }

        return app;
    }
}
