using AutoMapper;
using Directory.EntityFramework;
using Directory.Host.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using Swashbuckle.AspNetCore.SwaggerUI;
using System;


namespace Invoice_Application
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        private readonly AppConfiguration;
        private readonly string corsPolicy = "Corspolicy";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddCors(CorsSetup);


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(SetupSwaggerUI);
            }
            app.UseCors(corsPolicy);

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
        private void SetupSwagger(SwaggerGenOptions options)
        {
            options.SwaggerDoc(appConfiguration.Version, new OpenApiInfo()
            {
                Version = $"{appConfiguration.Version}",
                Title = $"{appConfiguration.Name} API",
                Description = appConfiguration.Description
            });
        }
        private void SetupSwaggerUI(SwaggerUIOptions options)
        {
            options.SwaggerEndpoint(
                $"{appConfiguration.ServerAddress}/swagger/{appConfiguration.Version}/swagger.json",
                $"{appConfiguration.Name} API {appConfiguration.Version}"
            );
        }
        private void CorsSetup(CorsOptions options) {
            options.AddPolicy(corsPolicy,
                builder => {
                    builder.WithOrigins(AppConfiguration.CorsPolicy.Split(',', StringSplitOptions.RemoveEmptyEntries));
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowCredentials();
                });
        } 
    }
}
