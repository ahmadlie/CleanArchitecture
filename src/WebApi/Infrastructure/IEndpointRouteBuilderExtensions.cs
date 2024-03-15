using System.Diagnostics.CodeAnalysis;

namespace CleanArchitecture.WebApi.Infrastructure;
//public static class IEndpointRouteBuilderExtensions
//{

//    public static IEndpointRouteBuilder MapGet(this IEndpointRouteBuilder builder, Delegate handler, [StringSyntax("Route")] string pattern = "")
//    {
//        //Guard.Against.AnonymousMethod
//        builder.MapGet(pattern, handler)
//            .WithName(handler.Method.Name)
//            .Produces<int>(StatusCodes.Status200OK);

//        return builder;

//    }
//    public static IEndpointRouteBuilder MapPost(this IEndpointRouteBuilder builder, Delegate handler, [StringSyntax("Route")] string pattern = "")
//    {

//        builder.MapPost(pattern, handler)
//            .WithName(handler.Method.Name);
//        return builder;

//    }
//    public static IEndpointRouteBuilder MapPut(this IEndpointRouteBuilder builder, Delegate handler, [StringSyntax("Route")] string pattern = "")
//    {
//        builder.MapPut(pattern, handler)
//            .WithName(handler.Method.Name);
//        return builder;

//    }
//    public static IEndpointRouteBuilder MapDelete(this IEndpointRouteBuilder builder, Delegate handler, [StringSyntax("Route")] string pattern = "")
//    {
//        builder.MapGet(pattern, handler)
//            .WithName(handler.Method.Name);
//        return builder;
//    }
//}

public static class IEndpointRouteBuilderExtensions
{
    public static IEndpointRouteBuilder MapGet(this IEndpointRouteBuilder builder, Delegate handler, [StringSyntax("Route")] string pattern = "") => MapEndpoint(builder, "Get", handler, pattern);
    public static IEndpointRouteBuilder MapPost(this IEndpointRouteBuilder builder, Delegate handler, [StringSyntax("Route")] string pattern = "") => MapEndpoint(builder, "Post", handler, pattern);
    public static IEndpointRouteBuilder MapDelete(this IEndpointRouteBuilder builder, Delegate handler, [StringSyntax("Route")] string pattern = "") => MapEndpoint(builder, "Delete", handler, pattern);
    public static IEndpointRouteBuilder MapPut(this IEndpointRouteBuilder builder, Delegate handler, [StringSyntax("Route")] string pattern = "") => MapEndpoint(builder, "Put", handler, pattern);


    private static IEndpointRouteBuilder MapEndpoint(IEndpointRouteBuilder builder, string method, Delegate handler, string pattern)
    { 
        var routeBuilder = method switch
        {
            "Get" => builder.MapGet(pattern, handler),
            "Post" => builder.MapPost(pattern, handler),
            "Put" => builder.MapPut(pattern, handler),
            "Delete" => builder.MapDelete(pattern, handler),
            _ => throw new NotSupportedException($"Http method {method} is not supported")
        };

        routeBuilder.WithName($"{handler.Method.Name}{handler.GetVersion()}");
        return builder;
    }
}