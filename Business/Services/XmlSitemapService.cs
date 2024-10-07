using kim_episerver.Business.Extensions;
using kim_episerver.Business.Services.Interfaces;
using kim_episerver.Models.Pages;

namespace kim_episerver.Business.Services
{
    public class XmlSitemapService : IXmlSitemapService
    {
        private readonly IContentLoader _contentLoader;

        public XmlSitemapService(IContentLoader contentLoader)
        {
            _contentLoader = contentLoader;
        }

        public List<SitePageData> GetPages(XmlSitemap currentPage)
        {
            var startPage = _contentLoader.GetAncestors(currentPage.ContentLink).FirstOrDefault(x => x is StartPage) as PageData;
            var descendants = Enumerable.Empty<SitePageData>();

            if (startPage != null)
            {
                descendants = _contentLoader.GetDescendentsAndSelf(startPage.ContentLink);
            }

            return descendants.ToList();
        }

    }
}




//// En tjänst (service) som implementerar IXmlSitemapService.
//// Den ansvarar för att hämta de sidor som ska inkluderas i en XML-sitemap.
//public class XmlSitemapService : IXmlSitemapService
//{
//    // Beroende på IContentLoader, som används för att ladda innehåll från Episerver CMS.
//    private readonly IContentLoader _contentLoader;

//    // Konstruktorn injicerar IContentLoader för att ladda innehåll från Episerver.
//    public XmlSitemapService(IContentLoader contentLoader)
//    {
//        _contentLoader = contentLoader;  // Sätter den injicerade instansen av IContentLoader till den privata fältet.
//    }

//    // Metod som hämtar alla sidor (SitePageData) som ska ingå i XML-sitemapen baserat på den aktuella sidan (XmlSitemap).
//    public List<SitePageData> GetPages(XmlSitemap currentPage)
//    {
//        // Hämtar den första förfadern (ancestor) till den aktuella sidan som är av typen StartPage (roten för webbplatsen).
//        var startPage = _contentLoader.GetAncestors(currentPage.ContentLink)
//            .FirstOrDefault(x => x is StartPage) as PageData;  // Förvandla till PageData.

//        // Skapar en tom uppsättning för att hålla de sidor som ska inkluderas.
//        var descendants = Enumerable.Empty<SitePageData>();

//        // Om en startPage hittades (alltså om det finns en förfader av typen StartPage),
//        // hämta alla underliggande sidor (descendants) från den start-sidan.
//        if (startPage != null)
//        {
//            // Använder en utökad metod GetDescendentsAndSelf för att hämta alla underliggande sidor samt startPage.
//            descendants = _contentLoader.GetDescendentsAndSelf(startPage.ContentLink);
//        }

//        // Konverterar den hämtade listan av underliggande sidor (descendants) till en lista och returnerar den.
//        return descendants.ToList();
//    }
//}
