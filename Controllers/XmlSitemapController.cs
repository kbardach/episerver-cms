using kim_episerver.Business.Services.Interfaces;
using kim_episerver.Controllers;
using kim_episerver.Models.Pages;
using kim_episerver.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace kim_episerver.Controllers
{
    public class XmlSitemapController : PageControllerBase<XmlSitemap>
    {
        private readonly IXmlSitemapService _xmlSitemapService;

        public XmlSitemapController(IXmlSitemapService xmlSitemapService)
        {
            _xmlSitemapService = xmlSitemapService;
        }

        public IActionResult Index(XmlSitemap currentPage)
        {
            var model = new XmlSitemapViewModel(currentPage)
            {
                Pages = _xmlSitemapService.GetPages(currentPage)
            };

            return View(model);
        }
    }
}



//// En controller för att hantera XmlSitemap-sidor. Den ärver från PageControllerBase med typen XmlSitemap,
//// vilket innebär att den hanterar sidor av typen XmlSitemap i Episerver (Optimizely).
//public class XmlSitemapController : PageControllerBase<XmlSitemap>
//{
//    // Ett beroende på en tjänst (IXmlSitemapService) som används för att hämta sidor som ska inkluderas i sitemapen.
//    private readonly IXmlSitemapService _xmlSitemapService;

//    // Konstruktorn tar emot en instans av IXmlSitemapService och injicerar den i controllern.
//    public XmlSitemapController(IXmlSitemapService xmlSitemapService)
//    {
//        _xmlSitemapService = xmlSitemapService;
//    }

//    // Action-metoden som hanterar GET-anrop till startsidan för XML-sitemapen.
//    // Den tar emot den aktuella XmlSitemap-sidan (currentPage) som en parameter.
//    public IActionResult Index(XmlSitemap currentPage)
//    {
//        // Skapar en instans av XmlSitemapViewModel och skickar in den aktuella sidan (currentPage).
//        // Hämtar sedan sidorna som ska inkluderas i sitemapen från _xmlSitemapService och fyller Pages-listan i ViewModel.
//        var model = new XmlSitemapViewModel(currentPage)
//        {
//            Pages = _xmlSitemapService.GetPages(currentPage) // Hämtar sidorna från tjänsten
//        };

//        // Returnerar vyn och skickar med ViewModel som innehåller både den aktuella sidan och dess lista med sidor.
//        return View(model);
//    }
//}
