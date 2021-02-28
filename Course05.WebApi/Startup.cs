using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Course05.WebApi
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

            var str = "dasda:dfasdasd";

            var aa = str.IndexOf(":");

            var bb = str.Substring(aa + 1);


            ThreadPool.SetMaxThreads(20, 20);

            var a =100;
            var b = a.ToString("00");

            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo()
                {
                    Version = "v1",
                    Title = "webapi",
                    TermsOfService = null,
                    Description = "webapiÎÄµµ"

                });
                //var con=new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("")
                var a = Directory.GetCurrentDirectory();
                var b = AppDomain.CurrentDomain.BaseDirectory;
                var cc = Path.Combine(b, "Course05.WebApi.xml");
                c.IncludeXmlComments(cc);
                var d = Directory.GetDirectories("./");

                //var dd = Directory.GetDirectories("");

                //var dd = Directory.GetDirectories("/");

            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseSwagger();
            app.UseSwaggerUI(c => {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "sadads");
            });

            
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
