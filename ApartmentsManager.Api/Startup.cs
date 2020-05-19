using ApartmentsManager.Domain.Handlers;
using ApartmentsManager.Domain.Repositories;
using ApartmentsManager.Infra.Contexts;
using ApartmentsManager.Infra.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ApartmentsManager.Api
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            // Injeta o contexto da aplicaçãp
            services.AddDbContext<ApartmentsManagerContext>(opt => opt.UseInMemoryDatabase("ApartmentsManager"));

            // Injeta repositorios
            services.AddTransient<IResidentRepository, ResidentRepository>();
            services.AddTransient<ICondominiumRepository, CondominiumRepository>();

            //Injeta handlers
            services.AddTransient<ResidentHandler, ResidentHandler>();
            services.AddTransient<CondominiumHandler, CondominiumHandler>();

            // Injet o AutoMapper
            services.AddAutoMapper(typeof(Startup).Assembly);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
