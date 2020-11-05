using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.PlatformAbstractions;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore;
using System.IO;
using Microsoft.AspNetCore.Cors;

namespace Course02.API
{

    public class DDD 
    {
           public int A { get; set; }

           public string B { get; set; }
    }

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

            //var dd = typeof(int) == typeof(Int64);

            services.AddControllers();
            services.AddRazorPages();
            services.AddMvc();

            services.AddSwaggerGen(swag =>
            {
                swag.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo()
                {
                    Description = "",
                    Title = "",
                    Version = "1.0",
                    TermsOfService = null
                });
                var basePath = PlatformServices.Default.Application.ApplicationBasePath;
                var path = System.IO.Path.Combine(basePath, "Course02.API.xml");
                swag.IncludeXmlComments(path);
            });

            //var  c= new ConfigurationBuilder()
            //    .SetBasePath(Directory.GetCurrentDirectory())
            //    .AddJsonFile("appsettings.json"); 

            //IConfiguration configuration= new config();

            services.AddCors(
               options => options.AddPolicy(
                   "MY",
                   configurePolicy => configurePolicy
                       .SetIsOriginAllowed(o=>true)
                       .AllowAnyHeader()
                       .AllowAnyMethod()
                       .AllowCredentials()
               )
           );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseSwagger();
            app.UseSwaggerUI(c=> 
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json","eqeqweda");
            });

            app.UseCors("MY");

            app.UseRouting();

            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
