using kim_episerver.Models.Pages;
using System.ComponentModel.DataAnnotations;
using static kim_episerver.Globals;

namespace kim_episerver.Models.Blocks
{
    [ContentType(
        GUID = "DD9E7B40-DC48-454E-9617-2520CC16D46A",
        GroupName = GroupNames.Specialized,
        DisplayName = "Slideshow",
        Description = "This is a slideshow block template"
    )]
    [ImageUrl("/pages/CMS-icon-page-09.png")]

    public class SlideshowBlock : BlockData
    {
        [Display(
            GroupName = SystemTabNames.Content,
            Order = 10
        )]
        [AllowedTypes(
            typeof(SlideshowPage)
        )]
        public virtual ContentArea Slideshow { get; set; }
    }
}
