using EPiServer.Cms.Shell;
using System.ComponentModel.DataAnnotations;

namespace kim_episerver.Models.Pages
{
    public class SitePageData : PageData
    {
        [Display(
            GroupName = Globals.GroupNames.MetaData,
            Order = 10
        )]
        [UIHint("MetaRobots")]
        public virtual string MetaRobots { get; set; }


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

        // Den här metoden används för att ställa in standardvärden för innehållstyper (ContentType).
        public override void SetDefaultValues(ContentType contentType)
        {
            // Anropar basklassens implementation av SetDefaultValues för att bibehålla befintlig logik.
            base.SetDefaultValues(contentType);

            // Sätter standardvärdet för egenskapen MetaRobots till "INDEX, FOLLOW".
            // Detta innebär att när en ny instans av den här innehållstypen skapas,
            // kommer egenskapen MetaRobots att ha detta värde som förvalt.
            MetaRobots = "INDEX, FOLLOW";
        }
    }
}
