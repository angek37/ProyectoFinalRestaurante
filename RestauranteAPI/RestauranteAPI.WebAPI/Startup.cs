using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using RestauranteAPI.Domain;
using RestauranteAPI.Domain.Abstract;
using RestauranteAPI.Domain.Concrete;

namespace RestauranteAPI.WebAPI
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
            services.AddCors(o => o.AddPolicy("Policy", builder =>
            {
                builder.AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowAnyOrigin();
            }));

            // Dependency Injector
            services.AddDbContext<restauranteContext>(options =>
                options.UseNpgsql(
                    Configuration["Data:DbPostgres:ConnectionString"]));
            services.AddTransient<IPreguntaRepository, PreguntaRepository>();
            services.AddTransient<IRespuestaRepository, RespuestaRepository>();
            services.AddTransient<ISucursalRepository, SucursalRepository>();

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("Policy");
            app.UseMvc();
        }
    }
}
