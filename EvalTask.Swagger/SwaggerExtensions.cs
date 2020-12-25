using System;
using System.IO;
using System.Reflection;
using EvalTask.Swagger.Filters;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace EvalTask.Swagger
{
    public static class SwaggerExtensions
    {

        public static void AddSwagger(this IServiceCollection service)
        {
            service.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo()
                {
                    Title = "Eval Task",
                    Version = "v1"
                });

                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "EvalTask.API.xml"));

                options.OperationFilter<AuthorizationOperationFilter>();
                
                options.DescribeAllParametersInCamelCase();
                options.DescribeAllEnumsAsStrings();
                
                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Description = @"JWT Authorization header using the Bearer scheme. 
                      Enter 'Bearer' [space] and then your token in the text input below.
                      Example: 'Bearer 12345abcdef'",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });
            });
        }
        
        public static void UseSwagger(this IApplicationBuilder app)
        {
            app.UseSwagger(options =>
            {
                
            });
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Eval Task API");
            });
        }
        
    }
}