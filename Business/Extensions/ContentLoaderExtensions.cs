using kim_episerver.Models.Pages;

namespace kim_episerver.Business.Extensions
{
    public static class ContentLoaderExtensions
    {
        public static IEnumerable<SitePageData> GetDescendentsAndSelf(this IContentLoader contentLoader, ContentReference startPageReference)
        {
            var startPage = contentLoader.Get<SitePageData>(startPageReference);

            var descendants = contentLoader.GetDescendents(startPageReference)
                .Select(contentLoader.Get<IContent>)
                .OfType<SitePageData>()
                .Where(content => content.MetaRobots == null || !content.MetaRobots.ToLower().Contains("noindex"))
                .ToList();

            return new[] { startPage }.Concat(descendants);
        }
    }

}




//public static class ContentLoaderExtensions
//{
//    // Denna metod hämtar en sida (startPage) och dess underliggande sidor (descendants),
//    // och returnerar alla som inte har "noindex" i MetaRobots-fältet.
//    public static IEnumerable<SitePageData> GetDescendentsAndSelf(this IContentLoader contentLoader, ContentReference startPageReference)
//    {
//        // Hämtar den specifika startPage (start-sidan) baserat på en ContentReference
//        var startPage = contentLoader.Get<SitePageData>(startPageReference);

//        // Hämtar alla underliggande sidor (descendants) från startPageReference
//        // och filtrerar dessa för att endast inkludera objekt av typen SitePageData.
//        var descendants = contentLoader.GetDescendents(startPageReference)  // Hämta alla descendants
//            .Select(contentLoader.Get<IContent>)                           // Hämta innehåll för varje descendant
//            .OfType<SitePageData>()                                        // Filtrera för att endast inkludera SitePageData
//            .Where(content => content.MetaRobots == null ||                // Om MetaRobots är null, inkludera sidan
//                              !content.MetaRobots.ToLower().Contains("noindex"))  // Exkludera sidor med "noindex" i MetaRobots
//            .ToList();                                                     // Gör om resultatet till en lista

//        // Returnerar startPage och de filtrerade descendants som en kombinerad lista
//        return new[] { startPage }.Concat(descendants);  // Slår ihop startPage med descendants och returnerar
//    }
//}

