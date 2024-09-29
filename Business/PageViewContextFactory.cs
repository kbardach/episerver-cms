
using EPiServer.ServiceLocation;
using EPiServer.Web;
using kim_episerver.Models.Pages;
using kim_episerver.Models.ViewModels;

namespace kim_episerver.Business
{

    [ServiceConfiguration]
    public class PageViewContextFactory
    {

        private readonly IContentLoader _contentLoader;
        private readonly ILogger<PageViewContextFactory> _logger;

        public PageViewContextFactory(IContentLoader contentLoader, ILogger<PageViewContextFactory> logger)
        {
            _contentLoader = contentLoader;
            _logger = logger;
        }

        public virtual LayoutModel CreateLayoutModel(ContentReference contentReference, HttpContext httpContext)
        {

            var startPageContentLink = SiteDefinition.Current.StartPage;

            if(contentReference.CompareToIgnoreWorkID(startPageContentLink))
            {
                startPageContentLink = contentReference;
            }

            var startPage = _contentLoader.Get<StartPage>(startPageContentLink);

            return new LayoutModel
            {
                StartPage = startPage,
                SettingsPage = GetSettingsPage(),

                //tillagd själv, måste lägga till properties i LayoutModel.cs   => public ArticlePage ArticelPage { get; set; }
                //ArticelPage = GetArticlePage()
            };
        }

        private SettingsPage GetSettingsPage()
        {
            if (SiteDefinition.Current.StartPage != ContentReference.EmptyReference)
            {
                var settingsPage = _contentLoader.GetChildren<SettingsPage>(SiteDefinition.Current.StartPage).FirstOrDefault();

                if (settingsPage != null)
                {
                    return settingsPage;
                }
                else
                {
                    //todo log
                    _logger.LogError("My Log: Settings page doesn't exist.");
                }
            }
            else
            {
                //todo log
                _logger.LogError("My Log: Start page doesn't exist.");
            }

            return null;
        }



        //tillagd själv, identiskt med den ovan
        private ArticlePage GetArticlePage()
        {
            if (SiteDefinition.Current.StartPage != ContentReference.EmptyReference)
            {
                var articlePage = _contentLoader.GetChildren<ArticlePage>(SiteDefinition.Current.StartPage).FirstOrDefault();

                if (articlePage != null)
                {
                    return articlePage;
                }
                else
                {
                    _logger.LogWarning("Article page not found under the start page.");
                }
            }
            else
            {
                _logger.LogError("Start page is not set or is invalid.");
            }

            return null;
        }

    }
}
