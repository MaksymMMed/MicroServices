using Microsoft.OpenApi.Models;
using Infrastructure.Persistense;
using MediatR;
using FluentValidation.AspNetCore;
using Apllication.Teams.Queries.GetAllTeams;
using Rabbit.Producer;

namespace EmployeeAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration) =>
            Configuration = configuration;

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection Services)
        {
            Services.AddTransient<IMessageProducer,RabbitMQProducer>();
            Services.AddPersistence(Configuration);
            Services.AddControllers();
            Services.AddEndpointsApiExplorer();
            Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "EmployeeCatalog.API",
                    Version = "v1"
                });

            });
            Services.AddHttpClient();
            Services.AddMediatR(typeof(GetAllTeamsQuery));
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint(
                    "/swagger/v1/swagger.json",
                    "EmployeeCatalog.API v1"));
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseStaticFiles();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
