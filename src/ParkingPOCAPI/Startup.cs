using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
//using ParkingPOCAPI.Data;
using ParkingPOC.Infra;
using ParkingPOC.Services.Interfaces;
using ParkingPOC.Services.Interfaces.Repository;
using ParkingPOC.Services.Models;
using ParkingPOC.Services.Services;
using Services.Interfaces;
using System.Text;

namespace ParkingPOCAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddScoped<IGenericRepository<Estabelecimento>, GenericRepository<Estabelecimento>>();
            services.AddScoped<IGenericRepository<Usuario>, GenericRepository<Usuario>>();
            services.AddScoped<IGenericRepository<Veiculo>, GenericRepository<Veiculo>>();
            services.AddScoped<IOcorrenciaRepository, OcorrenciaRepository>();

            services.AddScoped<IEstabelecimentoService, EstabelecimentoService>();
            services.AddScoped<IVeiculoService, VeiculoService>();
            services.AddScoped<IOperarVagasService, OperarVagasService>();
            services.AddScoped<IIncluirOcorrenciaService, IncluirOcorrenciaService>();
            services.AddScoped<IUsuarioService, UsuarioService>();

            services.AddSingleton<ITokenService, TokenService>();
            services.AddSingleton<IPasswordHasher<Usuario>, PasswordHasher<Usuario>>(); 

            services.AddDbContext<ParkingPOCAPIContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("ParkingPOCAPIContext"), x => x.MigrationsAssembly("ParkingPOC.Infra")), ServiceLifetime.Singleton);

            var key = Encoding.ASCII.GetBytes("2710aae3badf56186914697620391533");

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
