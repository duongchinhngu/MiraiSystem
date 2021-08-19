using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using MiraiSystem.Models;
using MiraiSystem.Services;
using MiraiSystem.Services.IServices;
using MiraiSystem.UnitOfWorks;

namespace MiraiSystem
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        #region AddScopeToConfig
        public void AddScopeToConfig(IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IShoesService, ShoesService>();
            services.AddScoped<IShoesImageService, ShoesImageService>();
            services.AddScoped<IConcreteShoesService, ConcreteShoesService>();
            services.AddScoped<IUserService, UserService>();
        }
        #endregion

        #region AddSwaggerToConfig
        public void AddSwaggerToConfig(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(
                    "v1",
                    new OpenApiInfo
                    {
                        Title = "Mirai System API",
                        Version = "v1",
                        Description = "Mirai System ASP.NET Core Web API",
                        TermsOfService = new Uri("https://www.thecodebuzz.com/resolved-failed-to-load-api-definition-undefined-swagger-v1-swagger-json/"),
                        Contact = new OpenApiContact
                        {
                            Name = "Duong Chinh Ngu",
                            Email = string.Empty,
                            Url = new Uri("https://www.thecodebuzz.com/resolved-failed-to-load-api-definition-undefined-swagger-v1-swagger-json/"),
                        },
                    });
            });
        }
        #endregion
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<MiraiDBContext>(opts => opts.UseSqlServer(Configuration["ConnectionString:MiraiSystemDBConnection"]));
            // cors
            services.AddCors();
            // business service
            AddScopeToConfig(services);
            // mapper
            services.AddAutoMapper(typeof(Startup));
            // controller
            services.AddControllers();
            // swagger
            AddSwaggerToConfig(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint(url: "/swagger/v1/swagger.json", name: "Mirai System V1");
            });
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
