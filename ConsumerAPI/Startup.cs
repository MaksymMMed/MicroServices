using BLL.Services.Interfaces;
using BLL.Services.Realization;
using BLL.Transit;
using DAL;
using DAL.Repositories.Interfaces;
using DAL.Repositories.Realization;
using DAL.Repositories.UnitOfWork;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.OpenApi.Models;
using Rabbit.Producer;
using System.Text.Json.Serialization;

public class Startup
{
    public Startup(IConfiguration configuration) =>
            Configuration = configuration;

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection Services)
    {
        Services.AddDbContext<UnitContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("UnitContext")));

        Services.AddStackExchangeRedisCache(options =>
        {
            options.Configuration = Configuration.GetValue<string>("CacheSettings:ConnectionString");
        });

        //Services.AddTransient<IMessageProducer,RabbitMQProducer>();

        Services.AddTransient<IConsumerRepository, ConsumerRepository>();
        Services.AddTransient<IUnitRepository, UnitRepository>();
        Services.AddTransient<IEnergyConsumeRepository, EnergyConsumeRepository>();
        Services.AddTransient<IIssueRepository, IssueRepository>();

        Services.AddTransient<IUnitOfWork, UnitOfWork>();

        Services.AddTransient<IConsumerService, ConsumerService>();
        Services.AddTransient<IUnitService, UnitService>();
        Services.AddTransient<IEnergyConsumeService, EnergyConsumeService>();



        Services.AddScoped<IDistributedCache>();
        
        Services.AddControllers().AddJsonOptions(x =>
                 x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
        Services.AddEndpointsApiExplorer();
        Services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "ConsumerCatalog.API",
                Version = "v1"
            });

        });
        Services.AddHttpClient();
        Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        Services.AddMassTransit(config => {

            config.AddConsumer<MessageConsumer>();

            config.UsingRabbitMq((ctx, cfg) => {
                cfg.Host(Configuration.GetValue<string>("EventBusSettings:HostAddress"));
                cfg.ReceiveEndpoint("Queue", c => {
                    c.ConfigureConsumer<MessageConsumer>(ctx);
                });
            });
        });
        Services.AddMassTransitHostedService();

        // General Configuration
        Services.AddScoped<MessageConsumer>();
    }
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (!env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint(
                "/swagger/v1/swagger.json",
                "ConsumerCatalog.API v1"));
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