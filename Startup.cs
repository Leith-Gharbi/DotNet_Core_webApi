using DotNet_Core_webApi.Data;
using DotNet_Core_webApi.Data.Services;
using DotNet_Core_webApi.Exceptions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNet_Core_webApi
{
    public class Startup
    {

        public string ConnectionString { get; set; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            ConnectionString = configuration.GetConnectionString("DefaultConnectionString");


        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();

            // Configure DBContext with PostgeSQL 
            services.AddDbContext<AppDbContext>(options => options.UseNpgsql(ConnectionString));
            // Configure the services 
            services.AddTransient<BooksService>();
            services.AddTransient<PublishersService>();
            services.AddTransient<AuthorsService>();
            // versioning
            services.AddApiVersioning( config =>
            {
                config.DefaultApiVersion = new ApiVersion(1, 0);
                config.AssumeDefaultVersionWhenUnspecified = true;

               // config.ApiVersionReader = new HeaderApiVersionReader("custom-version-header");
                //config.ApiVersionReader = new MediaTypeApiVersionReader();
            });
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "DotNet_Core_webApi", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "DotNet_Core_webApi v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            //Exception Handling 

             app.ConfigureBuildInExceptionHandler();
            //app.ConfigureCustomExceptionHandler();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
          //  AppDbInitializer.Seed(app);
        }
    }
}
