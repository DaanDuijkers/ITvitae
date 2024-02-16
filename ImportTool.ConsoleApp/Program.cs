using Microsoft.Extensions.DependencyInjection;
using Phoneshop.Business;
using Phoneshop.Business.Phones;
using Phoneshop.Domain;
using Phoneshop.Domain.Interfaces;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ImportTool.ConsoleApp
{
    public class Program
    {
        private static PhoneXML phoneXML;
        private static IBrandService brandService;
        private static IPhoneService phoneService;

        private static List<Brand> brands;
        private static List<Phone> phones;

        private static void Main(string[] args)
        {
            ServiceCollection service = new();
            service.AddScoped<DataContext>();
            service.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            service.AddScoped<IPhoneService, PhoneService>();
            service.AddScoped<IBrandService, BrandService>();
            service.AddScoped<ILogger, DatabaseLogger>();
            service.AddSingleton<ICache, Cache>();
            ServiceProvider serviceProvider = service.BuildServiceProvider();

            phoneXML = new PhoneXML();
            brandService = serviceProvider.GetService<IBrandService>();
            phoneService = serviceProvider.GetService<IPhoneService>();

            brands = brandService.GetAll().Result.ToList();
            phones = phoneService.GetAll().ToList();

            string xml = File.ReadAllText(args[0]);
            foreach (Phone p in PhoneXML.GetAll(xml).ToList())
            {
                if (phones.FirstOrDefault(x => x.FullName == p.FullName) == null)
                {
                    if (brands.FirstOrDefault(x => x.Name == p.Brand.Name) == null)
                    {
                        brandService.Create(p.Brand);
                    }

                    phoneService.Create(p);
                }
            }
        }
    }
}