using System;
using System.Reflection;
using System.Threading.Tasks;
using HtmlAgilityPack;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Phoneshop.Business.Scrapers;

public class HtmlWebDocumentLoader : IHtmlDocumentLoader
{
    private readonly ScraperOptions _scraperOptions = new();
    private readonly ChromeOptions _driverOptions;
    private readonly ChromeDriverService _driverService;
    public HtmlWebDocumentLoader(ScraperOptions scraperOptions = null)
    {
        _scraperOptions = scraperOptions ?? _scraperOptions;

        _driverOptions = new();
        _driverOptions.AddArguments("headless", "disable-gpu", "--log-level=3");

        string driverPath = AppDomain.CurrentDomain.BaseDirectory + "/Scrapers/Drivers/" + (OperatingSystem.IsLinux() ? "Linux" : "Windows");
        _driverService = ChromeDriverService.CreateDefaultService(driverPath);
        _driverService.EnableVerboseLogging = false;
        _driverService.SuppressInitialDiagnosticInformation = true;
    }

    public async Task<HtmlDocument> Load(string url)
    {
        var driver = new ChromeDriver(_driverService, _driverOptions);

        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        driver.Navigate().GoToUrl(url);

        await Task.Delay(_scraperOptions.RequestDelay);
        var source = driver.PageSource;
        driver.Close();

        var doc = new HtmlDocument();
        doc.LoadHtml(source);
        return doc;
    }
}