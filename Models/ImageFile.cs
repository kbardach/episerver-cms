using EPiServer.Framework.DataAnnotations;
using static kim_episerver.Globals;

namespace kim_episerver.Models
{
    [ContentType(
        GUID = "8231B5C4-9D65-4EFC-9DB2-9082E3C2B99E"
    )]

    [MediaDescriptor(ExtensionString = "jpg, jpeg, jpe, ico, gif, bmp, png, webp, pdf")]
    public class ImageFile : ImageData
    {
    }
}
