using FluentValidation.AspNetCore;
using ManagerHairdresser.Api.Extensions;
using ManagerHairdresser.Api.IoC;

namespace ManagerHairdresser.Api
{
    public class Startup : Interfaces.IStartup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration) =>
            Configuration = configuration;

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            services.AddControllers().AddFluentValidation(fv =>
            {
                fv.DisableDataAnnotationsValidation = true;
            });
            services.AddRouting(options => options.LowercaseUrls = true);
            services.AddVersioning();
            services.AddSwagger();
            services.AddAuthentication(Configuration);
            services.RegisterServices(Configuration);

            services.RegisterValidators(Configuration);
        }

        public void Configure(WebApplication app, IWebHostEnvironment env)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("v1/swagger.json", "MyAPI V1");
            });
            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseCors(builder => builder
                .SetIsOriginAllowed(orign => true)
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials());
            app.MapControllers();
        }
    }
}
