using HtmlAgilityPack;
using Phoneshop.Domain;
using Phoneshop.Domain.Interfaces;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Phoneshop.Business.Scrapers;

public class VodafoneScraper : IScraper
{
    private readonly IHtmlDocumentLoader _client;

    private readonly NumberFormatInfo _numberFormat = new()
    {
        NumberDecimalSeparator = ",",
        NumberGroupSeparator = "."
    };

    public VodafoneScraper(IHtmlDocumentLoader httpClient)
    {
        _client = httpClient;
    }

    public bool CanExecute(string url)
    {
        url = url.ToLower().Replace("https://", "").Replace("www.", "");
        return url == "vodafone.nl/telefoon/alle-telefoons"
            || url.StartsWith("vodafone.nl/telefoon/alle-telefoons/");
    }

    public async Task<IEnumerable<Phone>> Execute(string url, CancellationToken cancellationToken, SemaphoreSlim semaphore)
    {
        var doc = await _client.Load(url);
        var phoneList = doc.DocumentNode.SelectNodes("//div[@class='vfz-vodafone-product-card__product']");

        IEnumerable<Phone> phones = phoneList.Select(c => FromCard(c, cancellationToken)).Where(p => p != null);
        return phones;
    }

    private Phone FromCard(HtmlNode card, CancellationToken cancellationToken)
    {
        Thread.Sleep(10);

        if (cancellationToken.IsCancellationRequested)
        {
            return null;
        }

        var nameLabel = card.SelectSingleNode(".//span[@class='vfz-vodafone-product-card__model-label']");

        if (nameLabel == null) return null; // filter out advertisement cards

        var nameText = nameLabel.InnerText.Trim();
        var brandName = nameText.Split(' ').First();
        var phoneName = nameText[(nameText.IndexOf(' ') + 1)..];

        var priceLabel = card.SelectSingleNode(".//p[@class='vfz-vodafone-product-card__price-container-price']");
        var priceText = priceLabel.InnerText.Replace("Vanaf €", "").Trim();
        var price = double.Parse(priceText, _numberFormat);

        return new Phone { Type = phoneName, Price = price, Brand = new Brand { Name = brandName } };
    }
}
