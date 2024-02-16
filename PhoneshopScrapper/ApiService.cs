using Microsoft.Extensions.Configuration;
using Phoneshop.Domain;
using System.Web;

namespace Phoneshop.Scraper
{
    internal class ApiService
    {

        private readonly Uri _baseUri;

        public ApiService(IConfiguration config)
        {
            _baseUri = new Uri(config.GetValue<string>("ApiUrl"));
        }

        public Task AddPhone(Phone phone)
        {
            var handler = new HttpClientHandler()
            {
                ServerCertificateCustomValidationCallback = (_, _, _, _) => true
            };
            using var client = new HttpClient(handler) { BaseAddress = _baseUri };

            var builder = new UriBuilder(_baseUri + "phone/HttpPost/Create");

            var queryString = HttpUtility.ParseQueryString(builder.Query);
            queryString["brandName"] = phone.Brand.Name;
            queryString["type"] = phone.Type;
            queryString["description"] = "scraped";
            queryString["price"] = phone.Price.ToString();
            queryString["stock"] = 1.ToString();
            builder.Query = queryString.ToString();
            return Task.CompletedTask;
        }
    }
}