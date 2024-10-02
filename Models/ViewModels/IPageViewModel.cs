using kim_episerver.Models.Pages;

namespace kim_episerver.Models.ViewModels
{
    public interface IPageViewModel<out T> where T : SitePageData
    {
        T CurrentPage { get; }

        LayoutModel Layout { get; set; }


        public string MetaTitle
        {
            get
            {
                return !string.IsNullOrEmpty(CurrentPage.MetaTitle)
                    ? CurrentPage.MetaTitle
                    : "Kimpa the King";  
            }
        }
    }
}
