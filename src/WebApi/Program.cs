using Asp.Versioning;
using CleanArchitecture.Application;
using CleanArchitecture.Infrastructure;
using CleanArchitecture.WebApi;
using CleanArchitecture.WebApi.Middlewares;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;

[assembly: Microsoft.AspNetCore.Mvc.ApiController]
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddProblemDetails();
builder.Services.AddApiVersioning(
                    options =>
                    {
                        options.ReportApiVersions = true;
                        options.Policies.Sunset(0.9)
                                        .Effective(DateTimeOffset.Now.AddDays(60))
                                        .Link("policy.html")
                                            .Title("Versioning Policy")
                                            .Type("text/html");
                    })
                .AddMvc()
                .AddApiExplorer(
                    options =>
                    {
                        // add the versioned api explorer, which also adds IApiVersionDescriptionProvider service
                        // note: the specified format code will format the version as "'v'major[.minor][-status]"
                        options.GroupNameFormat = "'v'VVV";

                        // note: this option is only necessary when versioning by url segment. the SubstitutionFormat
                        // can also be used to control the format of the API version in route templates
                        options.SubstituteApiVersionInUrl = true;
                    });

builder.Services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();

builder.Services.AddEndpointsApiExplorer();


builder.Services.AddSwaggerGen(opt =>
{
    // add a custom operation filter which sets default values
    opt.OperationFilter<SwaggerDefaultValues>();

    var fileName = typeof(Program).Assembly.GetName().Name + ".xml";
    var filePath = Path.Combine(AppContext.BaseDirectory, fileName);

    // integrate xml comments
    opt.IncludeXmlComments(filePath);
});

builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddWebServices();

var app = builder.Build();


app.UseStaticFiles();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();

    app.UseSwaggerUI(
    options =>
    {
        var descriptions = app.DescribeApiVersions();

        // build a swagger endpoint for each discovered API version
        foreach (var description in descriptions)
        {
            var url = $"/swagger/{description.GroupName}/swagger.json";
            var name = description.GroupName.ToUpperInvariant();
            options.SwaggerEndpoint(url, name);
        }

        // Swagger UI için bazı opsiyonel yapılandırmalar
        options.RoutePrefix = "docs"; // Swagger UI'nin erişileceği URL yolunu değiştirir (varsayılan: 'swagger')
        options.DocumentTitle = "My API Documentation"; // Tarayıcı sekmesinde görünen başlık
        options.DefaultModelExpandDepth(2); // Model detaylarının varsayılan genişletme derinliği
        options.DefaultModelRendering(Swashbuckle.AspNetCore.SwaggerUI.ModelRendering.Model); // Modeli nasıl render ettiği
        options.DefaultModelsExpandDepth(-1); // Model şemalarının genişletme derinliği (-1 hepsini kapalı tutar)
        options.DisplayOperationId(); // Operasyon ID'lerini göster
        options.DisplayRequestDuration(); // İstek süresini göster
        options.DocExpansion(Swashbuckle.AspNetCore.SwaggerUI.DocExpansion.None); // Tüm operasyonları varsayılan olarak daraltır
        options.EnableDeepLinking(); // Derin bağlantılara izin ver
        options.EnableFilter(); // Arama filtresini etkinleştir

        options.InjectStylesheet("/css/swagger.css");
    });

}
app.Configure(builder.Environment);
app.UseAuthorization();
app.UseExceptionHandler(options => { });
//app.MapControllers();

app.MapEndpoints();
app.Run();

// set Header Code-Academy "Rnet103"
// https://github.com/dotnet/aspnet-api-versioning/tree/main/examples/AspNetCore/WebApi/OpenApiExample