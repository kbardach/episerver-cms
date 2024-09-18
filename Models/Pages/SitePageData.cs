using EPiServer.Cms.Shell;
using System.ComponentModel.DataAnnotations;

namespace kim_episerver.Models.Pages
{
    public class SitePageData : PageData
    {
        [Display(
            GroupName = Globals.GroupNames.MetaData,
            Order = 100)]

        [CultureSpecific]
        public virtual string MetaTitle
        {
            get
            {
                var metaTitle = this.GetPropertyValue(p => p.MetaTitle);
                return !string.IsNullOrWhiteSpace(metaTitle)
                    ? metaTitle
                    : PageTypeName;

            }
            set => this.SetPropertyValue(p => p.MetaTitle, value);
        }
    }
}
