using DesafioHubConexa.Data;
using DesafioHubConexa.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.PlatformAbstractions;
using System.IO;

namespace DesafioHubConexa.Configuration
{
    public static class DependencyInjectionConfiguration
    {
        
        public static void AddServices(this IServiceCollection services, IConfiguration configuration )
        {
            services.AddControllers();
            services.AddHttpClient<IOpenWeatherService, OpenWeatherService>();
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v2", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "OpenWeatherApi",                    
                    Description = "Busca de temperaturas por nome da cidade e por geolocalização",
                });

                options.CustomSchemaIds(x => x.FullName); //Essa linha deve ser inserida em casos que há classes com mesmo nome em namespaces diferentes

                //Obtendo o diretório e depois o nome do arquivo .xml de comentários
                var caminhoAplicacao = PlatformServices.Default.Application.ApplicationBasePath;
                var nomeAplicacao = PlatformServices.Default.Application.ApplicationName;
                var caminhoXmlDoc = Path.Combine(caminhoAplicacao, $"{nomeAplicacao}.xml");

                //Caso exista arquivo então adiciona-lo
                if (File.Exists(caminhoXmlDoc))
                {
                    options.IncludeXmlComments(caminhoXmlDoc);
                }
            });
            services.AddDbContext<Contexto>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
        }

        public static void UseServices(this IApplicationBuilder app, IWebHostEnvironment env)
        {
           
            if (env.EnvironmentName == "Development")
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

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint(url: "/swagger/v2/swagger.json", "My Cool API V1");
                c.RoutePrefix = "api/documentation";
            });
        }
    }
}
