using System.Reflection;
using Infrastructure.Context;
using Infrastructure.Interfaces;
using Infrastructure.Repositories;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Net.Http.Headers;

namespace Main
{
    public class Startup
    {
        readonly string MyPolicy = "_myAllowSpecificOrigins";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<NueraContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("NueraDbContext")));

            services.AddScoped<IHouseholdItemRepository, HouseholdItemRepository>();

            services.AddScoped<INueraContext, NueraContext>();

            services.AddMediatR(Assembly.GetExecutingAssembly());

            services.AddCors(options =>
            {
                options.AddPolicy(MyPolicy,
                                  builder =>
                                  {
                                      builder.WithOrigins("http://localhost:3000")
                                      .WithHeaders(HeaderNames.ContentType, "application/json")
                                      .WithMethods("POST", "PUT", "DELETE", "GET");
                                  });
            });

            services.AddControllers().AddNewtonsoftJson();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }            

            app.UseRouting();

            app.UseCors();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers().RequireCors(MyPolicy); ;
            });
        }
    }
}
