using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Phoneshop.Business;
using Phoneshop.Business.Scrapers;
using Phoneshop.Business.Services;
using Phoneshop.Domain;
using Phoneshop.Domain.Interfaces;

namespace Phoneshop.Scraper;

public static class Program
{
    // test test test

    private static readonly string[] URLS = {
        "https://www.vodafone.nl/telefoon/alle-telefoons",
        "https://www.belsimpel.nl/telefoon",
        "https://www.bol.com/nl/nl/l/smartphones/4010/"
    };
    private static int Count { get; set; } = 0;

    public static Task Main()
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile(@"appsettings.json")
            .Build();
        ServiceCollection service = new();
        service.AddScoped<DataContext>();
        service.AddScoped<IScraperService, ScraperService>();
        service.AddScoped<IHtmlDocumentLoader, HtmlWebDocumentLoader>();
        service.AddScoped<IScraper, VodafoneScraper>();
        service.AddScoped<IScraper, BelsimpelScraper>();
        service.AddScoped<IScraper, BolScraper>();
        service.AddSingleton<ICache, Cache>();
        service.AddSingleton(configuration);

        ApiService api = new(configuration);

        Menu(service, api);
        return Task.CompletedTask;
    }

    private static void Menu(ServiceCollection service, ApiService api)
    {
        ServiceProvider serviceProvider = service.BuildServiceProvider();
        IScraperService? scraper = serviceProvider.GetService<IScraperService>();
        CancellationTokenSource cancellationTokenSource = new();
        CancellationToken cancellationToken = cancellationTokenSource.Token;
        SemaphoreSlim semaphore = new(5);

        DrawMenu();
        if (int.TryParse(Console.ReadKey().KeyChar.ToString(), out int selection))
        {
            switch (selection)
            {
                case 1:
                    ScrapeSingle(scraper, cancellationTokenSource, cancellationToken, semaphore, api);
                    return;
                case 2:
                    ScrapeAll(scraper, cancellationTokenSource, cancellationToken, semaphore, api);
                    return;
                case 3: return;
            }
        }
    }

    private static void ScrapeSingle(IScraperService scraper, CancellationTokenSource cancellationTokenSource, CancellationToken cancellationToken, SemaphoreSlim semaphore, ApiService api)
    {
        ShowStartScraping();

        var url = SelectUrl();

        Action action = () =>
        {
            IEnumerable<Phone> phones = scraper.Get(url, cancellationToken, semaphore).Result;
            _ = ShowScraping(phones, api);

            Count++;
            Console.WriteLine($"{phones.Count()} {Count}");
        };

        _ = Task.Run(action);

        CancelScraping(cancellationTokenSource);

        ShowDoneScraping();
    }

    private static async void ScrapeAll(IScraperService scraper, CancellationTokenSource cancellationTokenSource, CancellationToken cancellationToken, SemaphoreSlim semaphore, ApiService api)
    {
        ShowStartScraping();

        Action actionAsync = async () =>
        {
            foreach (string url in URLS)
            {
                await ShowScraping(await scraper.Get(url, cancellationToken, semaphore), api);
            }

            Count++;
        };
        var myTask = Task.Run(actionAsync);

        CancelScraping(cancellationTokenSource);
        await myTask;
        ShowDoneScraping();
    }

    private static void CancelScraping(CancellationTokenSource cancellationTokenSource)
    {
        while (!cancellationTokenSource.IsCancellationRequested && Count < 1)
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.Escape)
                {
                    cancellationTokenSource.Cancel();
                }
            }
        }
    }

    private static void DrawMenu()
    {
        Console.Clear();
        Console.SetCursorPosition(0, 0);

        Console.Write(@"
                        ---Phoneshop Scraper---
        Please select and option by pressing the corresponding number key:

        1: Select URL to scrape
        2: Scrape all URLs
        3: Exit
        ");
    }

    private static void ShowStartScraping()
    {
        Console.Clear();
        Console.SetCursorPosition(0, 0);

        Console.WriteLine("Started Scraping...\n Press ESC to cancel\n");
    }

    private static void ShowDoneScraping()
    {
        Console.WriteLine("Done Scraping. Press any key to exit...");
        Console.ReadKey();
    }

    private static string SelectUrl()
    {
        while (true)
        {
            Console.Clear();
            Console.SetCursorPosition(0, 0);

            Console.WriteLine("\t\tSelect a URL to scrape:\n");

            for (int i = 0; i < URLS.Length; i++)
            {
                Console.WriteLine($"\t\t{i + 1}: {URLS[i]}");
            }

            (int x, int y) = Console.GetCursorPosition();

            if (int.TryParse(Console.ReadKey().KeyChar.ToString(), out int selection))
            {
                Console.SetCursorPosition(x, y);
                if (selection > 0 && selection <= URLS.Length)
                {
                    return URLS[selection - 1];
                }
            }
        }
    }

    private static async Task ShowScraping(IEnumerable<Phone> phones, ApiService api)
    {
        double count = 0;

        foreach (Phone phone in phones)
        {
            Console.WriteLine($"Scraped: {phone.FullName}\n");
            await api.AddPhone(phone);

            count++;
            double result = count / phones.ToList().Count * 100;
            Console.WriteLine($"{result:0}%");
        }
    }
}