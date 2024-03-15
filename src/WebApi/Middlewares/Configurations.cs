namespace CleanArchitecture.WebApi.Middlewares;


/// <summary>
/// Configurations
/// </summary>
public static class Configurations
{

    /// <summary>
    /// Configure
    /// </summary>
    /// <param name="app">IApplicationBuilder</param>
    /// <param name="env">IWebHostEnvironment</param>
    public static void Configure(this IApplicationBuilder app, IWebHostEnvironment env)
    {
        //app.UseMiddleware<CodeAcademyHeaderValidationMiddleware>();
        //app.UseAuthorization();
    }
}
