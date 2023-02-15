using System.Diagnostics.CodeAnalysis;
using BiscoitosLipe.Domain;
using BiscoitosLipe.Persistence.Contextos;
using BiscoitosLipe.Persistence.Contracts;
using BiscoitosLipe.Persistence.Persistencia;
using Cadastros.Persistence.Persistencia;
using Microsoft.EntityFrameworkCore;

using Newtonsoft.Json;
namespace BiscoitosLipe
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
            services.AddCors(c =>
            {
                c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            });

            string connection = Configuration.GetConnectionString("Default");

            services.AddDbContext<IDataContext, DataContext>(options =>
                options.UseMySql(connection, ServerVersion.AutoDetect(connection))
            );

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            
            services.AddScoped<IPersistenciaEstatica<Clientes>, PersistenciaEstatica<Clientes>>();
            services.AddScoped<IPersistenciaEstatica<Pedidos>, PersistenciaEstatica<Pedidos>>();
            services.AddScoped<IPersistenciaEstatica<Localização>, PersistenciaEstatica<Localização>>();

            services.AddScoped<IPersistenciaDinamica<Clientes>, PersistenciaDinamica<Clientes>>();
            services.AddScoped<IPersistenciaDinamica<Pedidos>, PersistenciaDinamica<Pedidos>>();
            services.AddScoped<IPersistenciaDinamica<Localização>, PersistenciaDinamica<Localização>>();
            
            services.AddControllers();
            services.AddSwaggerGen();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI();
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
