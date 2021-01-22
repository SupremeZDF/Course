using System;
using System.Collections.Generic;
using System.IO;
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
using Swashbuckle.AspNetCore;
using Microsoft.AspNetCore.Cors;
using Course04.Model.CrosModel;
using Microsoft.Extensions.Options;
using Microsoft.Net.Http.Headers;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using Microsoft.AspNetCore.Http;

namespace Course04.WebApi
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
            var ddd = oneExercise(54);

            int[] a = new int[5] { 1, 2, 3, 4, 5 };
            object[] b = new object[5] { 6, 7, 8, 9, 10 };

            Array.Copy(a, b, 2);


            var c = a;

            var aa = Directory.GetCurrentDirectory();  //D:\ѧϰ\�ܹ����_ѧϰ�γ�\Course1\Course04.WebApi

            services.AddControllers();
            services.Configure<CorsOptions>(Configuration.GetSection("AllowedHosts"));
            //OptionConfigure(services)

            services.AddControllers().AddJsonOptions(x =>
            {
                x.JsonSerializerOptions.Encoder = JavaScriptEncoder.Create(UnicodeRanges.All);
            });

            services.AddCors(options =>
            {
                options.AddPolicy("CustomCorsPolicy", policy =>
                {
                    // �趨����������Դ���ж��������','����
                    policy.SetIsOriginAllowed(_ => true).
                    //.AllowAnyHeader()
                    WithHeaders("authorization", "test", "content-type")
                    //.WithHeaders(HeaderNames.ContentType, "")
                    .AllowAnyMethod()
                    .AllowCredentials();
                });
            });

            //services.AddCors();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo()
                {
                    Version = "v1",
                    Title = "webapi",
                    TermsOfService = null,
                    Description = "webapi�ĵ�"
                });
                //var con=new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("")
                var a = Directory.GetCurrentDirectory();
                var b = AppDomain.CurrentDomain.BaseDirectory;
                var cc = Path.Combine(b, "Course04.WebApi.xml");
                c.IncludeXmlComments(cc);
                var d = Directory.GetDirectories("./");
                var dd = Directory.GetDirectories("/");
            });
        }

        public static string oneExercise(int x)
        {
            var integer = Math.Floor((double)x / 26);
            string[] A = new string[26] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
            if (x / 26 < 1)
            {
                var model = x % 26;
                return A[model - 1];
            }
            else
            {
                var str = "";
                for (var i = 0; i < integer; i++)
                {
                    str += "A";
                }
                var model = x % 26;
                if (model != 0)
                {
                    str += A[model - 1]; ;
                }
                return str;
            }
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IOptions<CorsOptions> corsOptions)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseHttpsRedirection();

            app.UseSwagger();
            app.UseSwaggerUI(c=> {
                c.SwaggerEndpoint("/swagger/v1/swagger.json","sadads");
            });

            // ���������ļ�ʵ��
            CorsOptions _corsOption = corsOptions.Value;
            // �ָ���ַ�������
            string[] hosts = _corsOption.url.Split('|');

            app.UseCors("CustomCorsPolicy");

            //����
            //app.UseCors(options=> 
            //{
            //    options.AllowAnyOrigin();
            //    //options.WithOrigins(hosts);
            //    options.AllowAnyHeader();
            //    options.AllowAnyMethod();
            //    options.AllowCredentials();
            //});

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
