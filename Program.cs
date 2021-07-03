using buildxact_supplies;
using buildxact_supplies.Extensions;
using buildxact_supplies.Factory;
using buildxact_supplies.Models;
using buildxact_supplies.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace SuppliesPriceLister
{
    class Program
    {

        private static IServiceProvider _services;
        public static void Setup()
        {
            var host = Host
             .CreateDefaultBuilder()
             .ConfigureAppConfiguration((context, builder) =>
             {
                 var env = context.HostingEnvironment.EnvironmentName;
                 builder
                     .AddJsonFile("appsettings.json", optional: true);
             })
             .ConfigureServices((context, services) =>
             {
                 var aa = context.Configuration.GetSection("supplierSettingModel").Value;

                 services.AddScoped<IProcessSuppliers, ProcessSuppliers>();
                 services.AddScoped<IReaderFactory, ReaderFactory>();
                 services.RegisterAllTypes<IReader>(new[] { typeof(IReader).Assembly });
                 services.AddOptions()
                       .Configure<AppSettings>(context.Configuration.GetSection("AppSettings"));


             })
             .Build();

            _services = host.Services;
        }

        static void Main(string[] args)
        {
            Setup();
            using var serviceScope = _services.CreateScope();
            var services = serviceScope.ServiceProvider;
            var supplier = services.GetService<IProcessSuppliers>();
            supplier.Process();            
        }
    }
}
