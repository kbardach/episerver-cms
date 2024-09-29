namespace kim_episerver.Models.Pages
{
    [ContentType(
        GUID = "A6CEB593-3A11-4073-8247-1427C13BEDEC"
        )]
    [AvailableContentTypes(
        Availability.Specific,
        Include = [typeof(SlideshowPage)]
    )]
    public class ContainerPage : PageData, IContainerPage
    {
    }
}
