using HtmlAgilityPack;
using Phoneshop.Domain;
using Phoneshop.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Phoneshop.Business.Scrapers
{
    public class BelsimpelScraper : IScraper
    {
        private readonly IHtmlDocumentLoader httpClient;

        private readonly NumberFormatInfo _numberFormat = new()
        {
            NumberDecimalSeparator = ",",
            NumberGroupSeparator = "."
        };

        public BelsimpelScraper(IHtmlDocumentLoader httpClient)
        {
            this.httpClient = httpClient;
        }

        public bool CanExecute(string url)
        {
            return url.Contains("https://www.belsimpel.nl/telefoon") || url.Contains("Belsimpel.html");
        }

        public async Task<IEnumerable<Phone>> Execute(string url, CancellationToken cancellationToken, SemaphoreSlim semaphore)
        {
            url = url ?? throw new ArgumentNullException(nameof(url));
            if (semaphore == null)
            {
                throw new ArgumentNullException("Missing data");
            }

            semaphore.Wait();

            HtmlDocument doc = await httpClient.Load(url);
            List<Phone> phones = new();

            HtmlNodeCollection nodes = doc.DocumentNode.SelectNodes("html//section[contains(@class, \"SegmentItemContainerstyle__StyledSegmentItemContainer\")]");
            foreach (HtmlNode node in nodes)
            {
                Thread.Sleep(10);

                if (cancellationToken.IsCancellationRequested)
                {
                    break;
                }

                string innerText = node.SelectSingleNode(".//a[contains(@class, \"GridHeaderstyle__Anchor\")]").InnerText;
                string phoneType = this.PhoneType(innerText);
                string brand = this.PhoneBrand(innerText);
                double price = this.PhonePrice(node);

                Phone phone = new();
                {
                    phone.Type = phoneType;
                    phone.Brand = new Brand { Name = brand };
                    phone.Price = price;
                }
                phones.Add(phone);
            }
            semaphore.Release();

            return phones;
        }

        private string PhoneType(string innerText)
        {
            string[] split = innerText.Trim().Split(" ");
            string phoneName = string.Empty;
            for (int i = 1; i < split.Length; i++)
            {
                phoneName += $"{split[i]} ";
            }

            return phoneName;
        }

        private string PhoneBrand(string innerText)
        {
            return innerText.Trim().Substring(0, innerText.IndexOf(" "));
        }

        private double PhonePrice(HtmlNode node)
        {
            string priceText = node.SelectNodes("./div[3]/div[2]/div[1]/span").Last().InnerText;
            return double.Parse(priceText, _numberFormat);
        }
    }
}