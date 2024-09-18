using EPiServer.Web.Mvc;
using kim_episerver.Models.Pages;

namespace kim_episerver.Controllers
{
    public abstract class PageControllerBase<T> : PageController<T> where T : SitePageData
    {
        
    }
}
