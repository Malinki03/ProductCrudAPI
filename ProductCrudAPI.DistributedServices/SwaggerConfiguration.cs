using System.Reflection;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace ProductCrudAPI.DistributedServices;

public static class SwaggerConfiguration
{
    public static void AddSwaggerDocumentation(SwaggerGenOptions o)
    {
        var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
        o.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
    } 
}