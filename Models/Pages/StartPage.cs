using EPiServer.Web;
using System.ComponentModel.DataAnnotations;
using static kim_episerver.Globals;

namespace kim_episerver.Models.Pages
{
    [ContentType(
        GUID = "3D239CE0-C604-4D9D-B98D-0904AF8E0D91",
        GroupName = GroupNames.Specialized
    )]

    [ImageUrl("/pages/CMS-icon-page-02.png")]
    public class StartPage : SitePageData
    {
        [Display(
            GroupName = SystemTabNames.Content,
            Order = 10
        )]

        [CultureSpecific]
        public virtual string Heading { get; set; } = string.Empty;

        [CultureSpecific]
        [UIHint(UIHint.Textarea)]
        public virtual string Preamble { get; set; } = string.Empty;

        [Display(
            GroupName = SystemTabNames.Content,
            Order = 30
        )]

        [CultureSpecific]
        public virtual XhtmlString MainBody { get; set; }

        [Display(
            GroupName = SystemTabNames.Content,
            Order = 40
        )]

        [UIHint(UIHint.Image)]
        public virtual ContentReference Image { get; set; }

    }
}
