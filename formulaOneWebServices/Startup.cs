using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace formulaOneWebServices
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Elenco api disponibili:\n\n");
                    await context.Response.WriteAsync("- COUNTRY:\n");
                    await context.Response.WriteAsync("1) /api/country\n");
                    await context.Response.WriteAsync("2) /api/country/it\n");
                    await context.Response.WriteAsync("- DRIVER:\n");
                    await context.Response.WriteAsync("3) /api/driver\n");
                    await context.Response.WriteAsync("4) /api/driver/number/10\n");
                    await context.Response.WriteAsync("5) /api/driver/name/Lewis Hamilton\n");
                    await context.Response.WriteAsync("6) /api/DCDtO\n");
                    await context.Response.WriteAsync("- TEAM:\n");
                    await context.Response.WriteAsync("7) /api/team\n");
                    await context.Response.WriteAsync("8) /api/team/id/1\n");
                    await context.Response.WriteAsync("9) /api/team/name/Mercedes-AMG Petronas F1 Team\n\n");
                    await context.Response.WriteAsync("----------------------------\n\n");
                    await context.Response.WriteAsync("1) Restituisce tutti i record della tabella country\n");
                    await context.Response.WriteAsync("2) Restituisce il record della tabella country corrispondente al parametro CountryCode\n\n");
                    await context.Response.WriteAsync("3) Restituisce tutti i record della tabella driver\n");
                    await context.Response.WriteAsync("4) Restituisce il record della tabella driver corrispondente al parametro Number\n");
                    await context.Response.WriteAsync("5) Restituisce il record della tabella driver corrispondente al parametro Name\n\n");
                    await context.Response.WriteAsync("6) Restituisce tutti i piloti con i relativi dati utili per la creazione il sito\n");
                    await context.Response.WriteAsync("7) Restituisce tutti i record della tabella team\n");
                    await context.Response.WriteAsync("8) Restituisce il record della tabella team corrispondente al parametro Id\n");
                    await context.Response.WriteAsync("9) Restituisce il record della tabella team corrispondente al parametro TeamName\n\n");
                    
                });
                endpoints.MapControllers();
            });
        }
    }
}
