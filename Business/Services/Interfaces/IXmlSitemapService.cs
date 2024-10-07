using kim_episerver.Models.Pages;

namespace kim_episerver.Business.Services.Interfaces
{
    public interface IXmlSitemapService
    {
        List<SitePageData> GetPages(XmlSitemap currentPage);
    }
}
