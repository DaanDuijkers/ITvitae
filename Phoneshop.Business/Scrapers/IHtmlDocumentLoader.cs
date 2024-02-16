using System.Threading.Tasks;
using HtmlAgilityPack;

namespace Phoneshop.Business.Scrapers;

public interface IHtmlDocumentLoader {
    Task<HtmlDocument> Load(string url);
}
