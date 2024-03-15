namespace CleanArchitecture.WebApi.Middlewares;


/// <summary>
/// CodeAcademyHeaderValidationMiddleware
/// </summary>
public class CodeAcademyHeaderValidationMiddleware
{
    private readonly RequestDelegate _next;
    /// <summary>
    /// CodeAcademyHeaderValidationMiddleware
    /// </summary>
    /// <param name="next">new middleware</param>
    public CodeAcademyHeaderValidationMiddleware(RequestDelegate next)
    {
        this._next = next;
    } 

    public async Task InvokeAsync(HttpContext context)
    {
        if (!context.Request.Headers.TryGetValue("Code-Academy-v1", out var headerValue))
        {
            context.Response.StatusCode = StatusCodes.Status403Forbidden;
            await context.Response.WriteAsync("Elvinden veta çinaradan icaze al");
            return;  // bir sonraki middleware'a geçmesine izin verme :)
        }


        await _next(context);
    }
}
