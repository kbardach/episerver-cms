using kim_episerver.Models.Pages;

namespace kim_episerver.Models.ViewModels
{
    public class LayoutModel
    {
        public StartPage StartPage { get; set; }
        public SettingsPage SettingsPage { get; set; }

        //tillagd själv för artikel sidan
        public ArticlePage ArticelPage { get; set; }
    }
}
