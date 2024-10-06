using System.ComponentModel.DataAnnotations;
using static kim_episerver.Globals;

namespace kim_episerver.Models.Pages
{
    [ContentType(
        GUID = "733317BA-DE7F-498B-BB06-1EFB2BB68455",
        GroupName = GroupNames.Specialized
    )]
    [ImageUrl("/pages/CMS-icon-page-04.png")]
    public class SavedMoviePage : SitePageData
    {
        [Display(
            GroupName = SystemTabNames.Content,
            Order = 10
        )]

        public virtual string Heading { get; set; } = string.Empty;
    }
}
