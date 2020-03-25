﻿namespace OpenRedding.Identity
{
    using System.Reflection;
    using FluentValidation;
    using MediatR;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.DependencyInjection.Extensions;
    using Microsoft.Extensions.Hosting;
    using OpenRedding.Identity.Middleware;
    using OpenRedding.Infrastructure.Extensions;

    public class Startup
    {
        public Startup(IWebHostEnvironment environment, IConfiguration configuration)
        {
            Environment = environment;
            Configuration = configuration;
        }

        public IWebHostEnvironment Environment { get; }

        public IConfiguration Configuration { get; set; }

        public void ConfigureServices(IServiceCollection services)
        {
            var connectionString = Configuration["ConnectionString"];
            var executingAssembly = Assembly.GetExecutingAssembly();

            // Add FluentValidation and MediatR for pipeline requests and validation
            services.AddOpenReddingInfrastructure(Configuration, true);
            services.AddMediatR(executingAssembly);
            services.AddValidatorsFromAssembly(executingAssembly);

            // Add MediatR middleware
            services.TryAddTransient(typeof(IPipelineBehavior<,>), typeof(IdentityRequestValidationBehavior<,>));

            // ASP.NET Core dependencies
            services.AddRazorPages();
            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Latest);

            // Override built in model state validation
            services.Configure<ApiBehaviorOptions>(options => options.SuppressModelStateInvalidFilter = true);
        }

        public void Configure(IApplicationBuilder app)
        {
            if (Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            // Enable ASP.NET Core specific middleware
            app.UseStaticFiles();
            app.UseRouting();

            // Auth middleware
            app.UseAuthentication();
            app.UseIdentityServer();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapRazorPages();
            });
        }
    }
}