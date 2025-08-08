using Microsoft.AspNetCore.Authorization;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Arm.GrcApi.Utilities
{
    public class AuthFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {

            var isAuthorized = context.MethodInfo.DeclaringType.GetCustomAttributes(true).OfType<AuthorizeAttribute>().Any() ||
                              context.MethodInfo.GetCustomAttributes(true).OfType<AuthorizeAttribute>().Any();

            operation.Responses.TryAdd("200", new OpenApiResponse { Description = "Success" });
            operation.Responses.TryAdd("401", new OpenApiResponse { Description = "Unauthorized. Use login to authenticate your request" });
            operation.Responses.TryAdd("403", new OpenApiResponse { Description = "Forbidden" });
            operation.Responses.TryAdd("409", new OpenApiResponse { Description = "Conflict. Some of your parameters are not correct. Check them and try again or contact system administrator" });
            operation.Responses.TryAdd("406", new OpenApiResponse { Description = "The server cannot provide a response that is acceptable according to the Accept headers sent in the request" });
            operation.Responses.TryAdd("429", new OpenApiResponse { Description = "Rate limit exceeded. Please try again later." });
            operation.Responses.TryAdd("500", new OpenApiResponse { Description = "Unknown error occured. Please contact administrator" });
            if (!isAuthorized) return;
            var jwtbearerScheme = new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "bearer" }
            };

            operation.Security = new List<OpenApiSecurityRequirement>
                {
                    new OpenApiSecurityRequirement
                    {
                        [ jwtbearerScheme ] = Array.Empty<string>()
                    }
                };
        }
    }
}
