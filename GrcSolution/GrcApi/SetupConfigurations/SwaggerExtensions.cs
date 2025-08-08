using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;

namespace Arm.GrcApi.SetupConfigurations
{
    public static class SwaggerExtensions
    {

        public static void AddSwagggerConfigurations(this IServiceCollection services)
        {
            services.AddSwaggerGen(option =>
            {
                option.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "GRC Tool API",
                    Version = "v1",
                    Description = "An API for GRC",
                    TermsOfService = new Uri("https://www.arm.com.ng/"),
                    Contact = new OpenApiContact
                    {
                        Name = "Asset & Resource Management Holding Company (ARM) Limited.",
                        Email = "enquiries@arm.com.ng",
                        Url = new Uri("https://arminvestmentcenter.com/"),
                    }
                });

                option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Please enter a valid token",
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    BearerFormat = "JWT",
                    Scheme = "Bearer"
                });
                option.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type=ReferenceType.SecurityScheme,
                                Id="Bearer"
                            }
                        },
                        Array.Empty<string>()
                    }
                });
                option.MapType<DateOnly>(() => new OpenApiSchema
                {
                    Type = "string",
                    Format = "date",
                    Example = new OpenApiString(DateTime.Today.ToString("yyyy-MM-dd"))
                });
            });
        }

    }
}
