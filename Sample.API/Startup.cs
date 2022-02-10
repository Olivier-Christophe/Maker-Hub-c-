using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Sample.DAL.Services;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Sample.API
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

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Sample.API", Version = "v1" });
            });

            services.AddCors(o => o.AddDefaultPolicy(b =>
            {
                b.AllowAnyOrigin();
                b.AllowAnyMethod();
                b.AllowAnyHeader();
            }));

            services.AddScoped<SampleService>();
            services.AddScoped<CategoryService>();
            //services.AddScoped<SqlConnection>(m => new SqlConnection("Server=OLY\\TB2019; Database=Sample.DB;Integrated Security=True;"));
            services.AddScoped<SqlConnection>(m => new SqlConnection("Data Source=5212;User ID=sa;Password=formation; initial catalog=Sample.database"));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Sample.API v1"));
            }

            app.UseStaticFiles();

            app.UseCors();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
