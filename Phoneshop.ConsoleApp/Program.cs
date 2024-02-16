using Microsoft.Extensions.DependencyInjection;
using Phoneshop.Business;
using Phoneshop.Business.Extensions;
using Phoneshop.Domain;
using Phoneshop.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Phoneshop.ConsoleApp
{
    public class Program
    {
        private static IPhoneService phoneService;

        public static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            ServiceCollection serviceCollection = new();
            serviceCollection.AddScoped<DataContext>();
            serviceCollection.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            serviceCollection.AddScoped<IPhoneService, PhoneService>();
            serviceCollection.AddScoped<ILogger, DatabaseLogger>();
            serviceCollection.AddSingleton<ICache, Cache>();
            ServiceProvider serviceProvider = serviceCollection.BuildServiceProvider();

            phoneService = (PhoneService)serviceProvider.GetService<IPhoneService>();

            MainMenu();
        }

        public static void MainMenu()
        {
            List<Phone> sorted = phoneService.GetAll().OrderBy(x => x.FullName).ToList();

            foreach (Phone p in sorted)
            {
                Console.WriteLine($"\n {p.Id}. {p.Brand.Name} {p.Type}");
            }

            Console.WriteLine("\n\n Voer het nummer in van de telefoon die u wilt bekijken:");
            Console.WriteLine(" Druk op ENTER om de \"search\" functie te gebruiken:");

            SelectedPage();
        }

        public static void SelectedPage()
        {
            ConsoleKeyInfo input = Console.ReadKey(true);
            Console.Clear();

            if (input.Key == ConsoleKey.Enter)
            {
                SearchByKeywords();
            }
            else
            {
                SearchByID(input);
            }

            Console.WriteLine("\n Druk op een willekeurige toets om terug te gaan...");
            Console.ReadKey(true);
            Console.Clear();

            MainMenu();
        }

        private static void SearchByKeywords()
        {
            Console.WriteLine(" Schrijf sleutelwoorden:");

            string keywords = Console.ReadLine();
            List<Phone> searchedPhones = phoneService.GetAll().Where(x => x.FullName.ToLower().Contains(keywords) ||
                    x.Brand.Name.ToLower().Contains(keywords) ||
                    x.Type.ToLower().Contains(keywords) ||
                    x.Description.ToLower().Contains(keywords)
                    ).ToList();

            foreach (Phone p in searchedPhones)
            {
                Console.WriteLine($"\n {{ {p.Brand.Name} }} {{ {p.Type} }} {{ €{p.PriceWithoutVAT():0.00} }} (no VAT) " +
                    $"{{ €{p.Price:0.00} }} (with VAT)");
                Console.WriteLine($" {{ {p.Description} }} \n");
            }

            if (searchedPhones.Count == 0)
            {
                Console.WriteLine("\n Geen resultaten gevonden! ");
            }
        }

        private static void SearchByID(ConsoleKeyInfo input)
        {

            char inputChar = input.KeyChar;
            string inputText = inputChar.ToString();

            if (int.TryParse(inputText, out int id) == true)
            {
                Phone selectedPhone = phoneService.GetAll().FirstOrDefault(x => x.Id == id);

                if (selectedPhone != null)
                {
                    Console.WriteLine($"\n {{ {selectedPhone.Brand} }} {{ {selectedPhone.Type} }} " +
                        $"{{ €{selectedPhone.PriceWithoutVAT():0.00} }} (no VAT) {{ €{selectedPhone.Price:0.00} }} (with " +
                        $"VAT)\n");
                    Console.WriteLine($" {{ {selectedPhone.Description} }}");
                }
                else
                {
                    Console.WriteLine(" Er is geen telefoon met dit ID");
                }
            }
            else
            {
                Console.WriteLine(" Druk op een nummer!");
            }
        }
    }
}