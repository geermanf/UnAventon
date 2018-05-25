using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using unAventonApi.Data;
using unAventonApi.Models;
using Microsoft.EntityFrameworkCore;
using unAventonApi.Services.Base;
using unAventonApi.Services.Interfaces;
using unAventonApi.Data.Repositories;
using Microsoft.AspNetCore.Mvc.Cors.Internal;
using Microsoft.AspNetCore.Mvc;

namespace unAventonApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        private void SetRepositories(IServiceCollection services)
        {
            // Repos
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IVehiculoRepository, VehiculoRepository>();
            services.AddScoped<ITarjetaRepository, TarjetaRepository>();

            // Services
            services.AddScoped<IAuthentificateService, AuthentificateService>();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();

            services.AddDbContext<UnAventonDbContext>(options =>
                    options.UseMySql(Configuration.GetConnectionString("DefaultConnection")));
            // services.AddDbContext<CodingBlastDbContext>(options =>
            //         options.UseInMemoryDatabase("prueba"));
            SetRepositories(services);
            services.AddMvc();

            services.Configure<MvcOptions>(options =>
{
    options.Filters.Add(new CorsAuthorizationFilterFactory("AllowSpecificOrigin"));
});


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
