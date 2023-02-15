using System.Diagnostics.CodeAnalysis;
using BiscoitosLipe.Persistence.Contextos;
using BiscoitosLipe.Persistence.Contracts;
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

            string connection = Configuration.GetConnectionString("PostgreSQL");

            services.AddDbContext<IDataContext, DataContext>(options =>
                options.UseNpgsql(connection)
            );

            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

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
