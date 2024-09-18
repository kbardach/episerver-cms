using System.ComponentModel.DataAnnotations;
using static kim_episerver.Globals;

namespace kim_episerver.Models.Pages
{
    [ContentType(
        GUID = "3D239CE0-C604-4D9D-B98D-0904AF8E0D91",
        GroupName = GroupNames.Specialized
    )]

    public class StartPage : SitePageData
    {
        [Display(
            GroupName = SystemTabNames.Content
        )]

        [CultureSpecific]
        public virtual string Heading { get; set; } = string.Empty;
    }
}
