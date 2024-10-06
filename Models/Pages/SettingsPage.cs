using static kim_episerver.Globals;
using System.ComponentModel.DataAnnotations;

namespace kim_episerver.Models.Pages
{
    [ContentType(
        GUID = "3932C4ED-5D39-46A7-AC9C-2FB2EB05D465",
        GroupName = GroupNames.Specialized
    )]
    [ImageUrl("/pages/CMS-icon-page-03.png")]
    public class SettingsPage : SitePageData
    {
        [Display(
            GroupName = SystemTabNames.Content,
            Order = 10
        )]

        public virtual ContentReference LinkToMoviesContainer { get; set; }
    }
}
