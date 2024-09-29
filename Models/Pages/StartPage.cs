using EPiServer.Shell.ViewComposition;
using EPiServer.Web;
using System.ComponentModel.DataAnnotations;
using static kim_episerver.Globals;

namespace kim_episerver.Models.Pages
{
    [ContentType(
        GUID = "82DEBA0A-E0F9-407F-B673-3D7172615715",
        GroupName = GroupNames.Specialized
    )]
    [ImageUrl("/pages/CMS-icon-page-02.png")]
    [AvailableContentTypes(
        Availability.Specific,
        Include =
        [
            typeof(SettingsPage),
            typeof(ArticlePage),
            //typeof(SlideshowPage),
            typeof(ContainerPage)
        ]
    )]
    public class StartPage : SitePageData
    {
        [Display(
            GroupName = SystemTabNames.Content,
            Order = 10
        )]
        [CultureSpecific]
        public virtual string Heading { get; set; } = string.Empty;

        [Display(
            GroupName = SystemTabNames.Content,
            Order = 20
        )]
        [CultureSpecific]
        [ScaffoldColumn(false)]
        public virtual XhtmlString MainBody { get; set; }

        [Display(
            GroupName = SystemTabNames.Content,
            Order = 30,
            Name = "Slideshow",
            Description = ""
        )]
        [AllowedTypes(
            typeof(SlideshowPage)
            //typeof(SlideshowBlock)
        )]

        public virtual ContentArea Content { get; set; }
    }
}
