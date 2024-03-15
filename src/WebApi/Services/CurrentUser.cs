using CleanArchitecture.Application.Common.Interfaces;
using System.Security.Claims;

namespace CleanArchitecture.WebApi.Services;

public class CurrentUser : IUser
{
    private readonly IHttpContextAccessor _contextAccessor;
    public CurrentUser(IHttpContextAccessor contextAccessor)
    {
        this._contextAccessor = contextAccessor;
    }
    public string? Id => _contextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);
}
