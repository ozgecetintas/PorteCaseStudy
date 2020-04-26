namespace PorteCaseStudy
{
    using System;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using PorteCaseStudy.Common.Contracts;
    using PorteCaseStudy.Controllers;
    using PorteCaseStudy.Data;
    using PorteCaseStudy.Service;

    public class Program
    {
        public static void Main(string[] args)
        {
            var serviceProvider = ConfigureServices();
            var controller = serviceProvider.GetService<PartCostController>();
            controller.Index();
            Console.ReadLine();
        }

        private static IServiceProvider ConfigureServices()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddDbContext<DataContext>(options =>
            {
                options.UseInMemoryDatabase("PorteCaseStudy");
            });
            serviceCollection.AddSingleton<IPackageService, PackageService>();
            serviceCollection.AddSingleton<IViewService, ViewService>();
            serviceCollection.AddSingleton<IDataGeneratorService, DataGeneratorService>();
            serviceCollection.AddSingleton<IDataContext, DataContext>();
            serviceCollection.AddSingleton<PartCostController>();

            var serviceProvider = serviceCollection.BuildServiceProvider();
            return serviceProvider.CreateScope().ServiceProvider;
        }
    }
}
