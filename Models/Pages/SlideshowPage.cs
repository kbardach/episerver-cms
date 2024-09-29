using EPiServer.Web;
using System.ComponentModel.DataAnnotations;
using static kim_episerver.Globals;

namespace kim_episerver.Models.Pages
{

    //[ContentType(
    //    GUID = "08FFEB34-C786-467C-B76B-A841A773C35D",
    //    GroupName = GroupNames.Specialized,
    //    DisplayName = "Slideshow",
    //    Description = "This is a slideshow template"
    //)]
    //[ImageUrl("/pages/CMS-icon-page-06.png")]

    //public class SlideshowPage : SitePageData
    //{
    //    [Display(
    //        GroupName = SystemTabNames.Content,
    //        Order = 10
    //    )]
    //    [UIHint(UIHint.Image)]
    //    public virtual ContentReference Image { get; set; }
    //}

    [ContentType(
        GUID = "08FFEB34-C786-467C-B76B-A841A773C35D",
        GroupName = GroupNames.Specialized,
        DisplayName = "Slideshow",
        Description = "This is a slideshow template"
    )]
    [ImageUrl("/pages/CMS-icon-page-06.png")]

    public class SlideshowPage : SitePageData
    {
        [Display(
            GroupName = SystemTabNames.Content,
            Order = 10
        )]
        [UIHint(UIHint.Image)]
        public virtual ContentReference Image { get; set; }



        [Display(
            GroupName = SystemTabNames.Content,
            Order = 20
        )]
        public virtual string Heading { get; set; }

        [Display(
            GroupName = SystemTabNames.Content,
            Order = 30
        )]
        public virtual string Text { get; set; }

        [Display(
            GroupName = SystemTabNames.Content,
            Order = 40
        )]
        public virtual Url Link { get; set; }
    }
}
