using LightOps.Commerce.Services.Navigation.Configuration;
using LightOps.Commerce.Services.Navigation.Domain.GrpcServices;
using LightOps.CQRS.Configuration;
using LightOps.DependencyInjection.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Sample.NavigationService
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddLightOpsDependencyInjection(root =>
            {
                root
                    .AddCqrs()
                    .AddNavigationService();
            });

            services.AddGrpc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGrpcService<NavigationGrpcServiceV1>();

                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Sample NavigationService. Communication must be made through a gRPC client.");
                });
            });
        }
    }
}
