using System;
using System.Collections.Generic;

namespace Phoneshop.ConsoleApp
{
    public class Program
    {
        private static readonly List<Phone> phones = new()
        {
            new Phone("Huawei",
                "P30",
                "6.47\" FHD + (2340x1080) OLED, Kirin 980 Octa - Core (2x Cortex - A76 2.6GHz + 2x Cortex - A76 1.92GHz + " +
                "4x Cortex - A55 1.8GHz), 8GB RAM, 128GB ROM, 40 + 20 + 8 + TOF / 32MP, Dual SIM, 4200mAh, Android 9.0 + " +
                "EMUI 9.1",
                697),
            new Phone("Samsung",
                "Galaxy A52",
                "64 megapixel camera, 4k videokwaliteit 6.5 inch AMOLED scherm 128 GB opslaggeheugen (Uitbreidbaar met " +
                "Micro - sd) Water - en stofbestendig (IP67)",
                399),
            new Phone("Apple",
                "IPhone 11",
                "Met de dubbele camera schiet je in elke situatie een perfecte foto of video De krachtige A13 - chipset " +
                "zorgt voor razendsnelle prestaties Met Face ID hoef je enkel en alleen naar je toestel te kijken om te " +
                "ontgrendelen Het toestel heeft een lange accuduur dankzij een energiezuinige processor",
                619),
            new Phone("Google",
                "Pixel 4a",
                "12.2 megapixel camera, 4k videokwaliteit 5.81 inch OLED scherm 128 GB opslaggeheugen 3140 mAh " +
                "accucapaciteit",
                411),
            new Phone("Xiaomi",
                "Redmi Note 10 Pro",
                "108 megapixel camera, 4k videokwaliteit 6.67 inch AMOLED scherm 128 GB opslaggeheugen (Uitbreidbaar met " +
                "Micro sd) Water - en stofbestendig (IP53)",
                298)
        };

        public static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            MainMenu();
        }

        public static void MainMenu ()
        {
            foreach (Phone p in phones)
            {
                Console.WriteLine($"\n {p.Id} | {p.Brand} | {p.Type}");
            }
            Console.WriteLine("\n\n Voer alstublieft het ID (nummer) in van de telefoon die u wilt bekijken:");

            SelectedPage();
        }

        public static void SelectedPage ()
        {
            char input = Console.ReadKey(true).KeyChar;
            string inputText = input.ToString();

            if (int.TryParse(inputText, out int id) == true)
            {
                Phone selectedPhone = phones.Find(x => x.Id == id);

                Console.Clear();
                if (selectedPhone != null)
                {
                    Console.WriteLine($"\n {{ { selectedPhone.Brand } }} {{ { selectedPhone.Type } }} " +
                        $"{{ €{ selectedPhone.Price } }}");
                    Console.WriteLine($" {{ { selectedPhone.Description } }}");
                }
                else
                {
                    Console.WriteLine(" Er is geen telefoon met dit ID");
                }
                Console.WriteLine("\n Druk op een willekeurige toets om terug te gaan...");

                Console.ReadKey(true);
                Console.Clear();
                MainMenu();
            }
            else
            {
                SelectedPage();
            }
        }
    }
}