using kim_episerver.Models.Pages;

namespace kim_episerver.Models.ViewModels
{
    public class XmlSitemapViewModel : PageViewModel<XmlSitemap>
    {
        public List<SitePageData> Pages { get; set; }

        public XmlSitemapViewModel(XmlSitemap currentPage) : base(currentPage)
        {
        }
    }
}



//namespace kim_episerver.Models.ViewModels
//{
//    // En ViewModel-klass som används för att binda data mellan en XmlSitemap-sida och vyn.
//    // Den ärver från PageViewModel och är typad med XmlSitemap, vilket innebär att den hanterar sidor av typen XmlSitemap.
//    public class XmlSitemapViewModel : PageViewModel<XmlSitemap>
//    {
//        // En egenskap som håller en lista över sidor (av typen SitePageData) som ska inkluderas i XML-sitemapen.
//        public List<SitePageData> Pages { get; set; }

//        // Konstruktorn tar emot den aktuella sidan av typen XmlSitemap och skickar vidare den till basklassen (PageViewModel).
//        // Basklassen ansvarar för att hantera de vanliga sid-egenskaperna.
//        public XmlSitemapViewModel(XmlSitemap currentPage) : base(currentPage)
//        {
//            // Konstruktorn gör inget mer än att skicka den aktuella sidan vidare till bas-klassen
//            // Egenskapen 'Pages' är förberedd för att fyllas senare i controllern eller tjänsten.
//        }
//    }
//}

