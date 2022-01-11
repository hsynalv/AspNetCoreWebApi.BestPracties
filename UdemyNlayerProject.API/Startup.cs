using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UdemyNlayerProject.Data;
using UdemyNlayerProject.Data.Repositories;
using UdemyNlayerProject.Data.UnitOfWorks;
using UdemyNlayerProject.Service.Services;
using UdemyNLayerProject.Core.Repositories;
using UdemyNLayerProject.Core.Services;
using UdemyNLayerProject.Core.UnitOfWorks;
using AutoMapper;
using UdemyNlayerProject.API.Filters;
using Microsoft.AspNetCore.Diagnostics;
using UdemyNlayerProject.API.DTOs;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using UdemyNlayerProject.API.Extensions;

namespace UdemyNlayerProject.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(Startup));

            services.AddScoped<ProductNotFoundFilter>();
            services.AddScoped<IUnitOfWork,UnitOfWork>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped(typeof(IService<>), typeof(BaseService<>));
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IProductService, ProductService>();


            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(Configuration["ConnectionStrings:SqlConnection"].ToString(), o => 
                {
                    o.MigrationsAssembly("UdemyNlayerProject.Data");
                })
            );

            

            services.AddControllers(o => o.Filters.Add(new ValidationFilter()));


            services.Configure<ApiBehaviorOptions>(options =>
            options.SuppressModelStateInvalidFilter = true);
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCustomException(); // Custom ExceptionHandler

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
