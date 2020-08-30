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
using Microsoft.EntityFrameworkCore;
//using ParkingPOCAPI.Data;
using ParkingPOC.Infra;
using ParkingPOC.Services.Interfaces;
using Services.Interfaces;
using ParkingPOC.Services.Models;
using ParkingPOC.Services.Services;
using ParkingPOC.Services.Interfaces.Repository;

namespace ParkingPOCAPI
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

            services.AddScoped<IGenericRepository<Estabelecimento>, GenericRepository<Estabelecimento>>(); 
            services.AddScoped<IGenericRepository<Veiculo>, GenericRepository<Veiculo>>();
            services.AddScoped<IOcorrenciaRepository, OcorrenciaRepository>(); 

            services.AddScoped<IEstabelecimentoService, EstabelecimentoService>(); 
            services.AddScoped<IVeiculoService, VeiculoService>();
            services.AddScoped<IOperarVagasService, OperarVagasService>();
            services.AddScoped<IIncluirOcorrenciaService, IncluirOcorrenciaService>();

            services.AddDbContext<ParkingPOCAPIContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("ParkingPOCAPIContext"), x => x.MigrationsAssembly("ParkingPOC.Infra")), ServiceLifetime.Singleton);
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

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
