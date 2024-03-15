using CleanArchitecture.Application.Categories.Commands.CreateCommand;
using CleanArchitecture.Application.Categories.Queries;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace CleanArchitecture.WebApi.Endpoints.v1;

/// <summary>
/// Category Endpoint Mapping
/// </summary>
public class Categories : EndpointGroupBase
{

    /// <summary>
    /// Global Mapping Function
    /// </summary>
    /// <param name="app"></param>
    /// <exception cref="NotImplementedException"></exception>
    public override void Map(WebApplication app)
    {
        app.MapGroup(this )
             .MapPost(CreateCategory);
    }


    /// <summary>
    /// Create new Category Item
    /// </summary>
    /// <param name="sender">MediatR Sender</param>
    /// <param name="command">Category Create Command</param>
    /// <returns></returns> 
    public async Task<IResult> CreateCategory(ISender sender, CreateCategoryCommand command)
    {
        var categoryId = await sender.Send(command);
        return Results.Ok(categoryId);
    }
     
}
