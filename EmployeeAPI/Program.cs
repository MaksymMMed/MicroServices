using EmployeeAPI;
using RabbitMQ.Client.Events;
using RabbitMQ.Client;
using Infrastructure.Persistense;
using Rabbit;
using MediatR;
using Domain.Entities;
using Newtonsoft.Json;

public class Program
{
    public static EmployeeContext Context { get; set; }

    public static void Main(string[] args) =>
        CreateHostBuilder(args).Build().Run();

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            });
}
