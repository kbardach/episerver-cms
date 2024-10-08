using System.ComponentModel.DataAnnotations;
using static kim_episerver.Globals;

namespace kim_episerver.Models.Pages
{
    [ContentType(
        GUID = "7CE3D773-793D-41D5-B685-876CADA96D9C",
        GroupName = GroupNames.Specialized
    )]
    public class ErrorPage : SitePageData
    {
        [Display(
            GroupName = SystemTabNames.Content,
            Order = 10
        )]
        public virtual string Header { get; set; }
    }
}
