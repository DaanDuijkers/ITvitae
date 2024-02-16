using HtmlAgilityPack;
using Moq;
using Phoneshop.Business.Scrapers;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace Phoneshop.Business.Tests.Scrapers.BelsimpelScraperTest
{
    public class BelsimpelTestBase
    {
        protected readonly BelsimpelScraper _scraper;
        protected readonly Mock<IHtmlDocumentLoader> _mockWeb;
        protected string Response = "";

        protected CancellationTokenSource cancellationTokenSource;
        protected CancellationToken cancellationToken;
        protected SemaphoreSlim semaphore;

        public BelsimpelTestBase()
        {
            _mockWeb = new Mock<IHtmlDocumentLoader>();

            _mockWeb.Setup(m => m.Load(It.IsAny<string>())).Returns<string>(url => ReadLocalHtml(url));

            _scraper = new BelsimpelScraper(_mockWeb.Object);


            this.cancellationTokenSource = new CancellationTokenSource();
            this.cancellationToken = cancellationTokenSource.Token;
            this.semaphore = new SemaphoreSlim(5);
        }

        private static async Task<HtmlDocument> ReadLocalHtml(string file)
        {
            var path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), $"Scrapers/LocalHtml/{file}");
            HtmlDocument doc = new();
            doc.LoadHtml(await File.ReadAllTextAsync(path));
            return doc;
        }
    }
}