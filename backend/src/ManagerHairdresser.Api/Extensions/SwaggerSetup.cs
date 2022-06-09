using Microsoft.OpenApi.Models;

namespace ManagerHairdresser.Api.Extensions
{
  public static class SwaggerSetup
  {
    public static void AddSwagger(this IServiceCollection services)
    {
      services.AddEndpointsApiExplorer();
      services.AddSwaggerGen(options =>
      {
        options.SwaggerDoc("v1", new OpenApiInfo
        {
          Title = "ManagerHairdresser.Api",
          Version = "v1",
        });

        options.SwaggerDoc("v2", new OpenApiInfo
        {
          Title = "ManagerHairdressed.Api",
          Version = "v2"
        });

        options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
        {
          Description = @"JWT Authorization header using the Bearer scheme.
                                Enter 'Bearer' [space] and then your token in the text input below.
                                Example: 'Bearer 12345abcdef'",
          Name = "Authorization",
          In = ParameterLocation.Header,
          Type = SecuritySchemeType.ApiKey,
          Scheme = "Bearer"
        });

        options.AddSecurityRequirement(new OpenApiSecurityRequirement()
        {
          {
          new OpenApiSecurityScheme
          {
              Reference = new OpenApiReference
              {
                  Type = ReferenceType.SecurityScheme,
                  Id = "Bearer"
              },
              Scheme = "oauth2",
              Name = "Bearer",
              In = ParameterLocation.Header,

              },
              new List<string>()
          }
        });
      });
    }
  }
}
