using EPiServer.Web.Routing;

namespace kim_episerver.Business.Extensions
{
    public static class PageDataExtensions
    {
        public static string GetExternalUrl(this IContent content)
        {
            var internalUrl = UrlResolver.Current.GetUrl(content.ContentLink);

            if (internalUrl != null)
            {
                var url = new UrlBuilder(internalUrl);
                var friendlyUrl = UriSupport.AbsoluteUrlBySettings(url.ToString());

                return friendlyUrl;
            }

            return null;
        }

        public static string Url(this string url)
        {
            return UrlResolver.Current.GetUrl(url);
        }
    }
}





//// En statisk klass som innehåller utökningar (extension methods) för PageData och strängar.
//public static class PageDataExtensions
//{
//    // En utökad metod för IContent som hämtar den externa (fullständiga) URL:en till en sida eller annat innehåll.
//    public static string GetExternalUrl(this IContent content)
//    {
//        // Hämtar den interna URL:en baserat på ContentLink från IContent-objektet.
//        var internalUrl = UrlResolver.Current.GetUrl(content.ContentLink);

//        // Om den interna URL:en inte är null, omvandlar den till en absolut URL.
//        if (internalUrl != null)
//        {
//            // Skapar en UrlBuilder från den interna URL:en.
//            var url = new UrlBuilder(internalUrl);

//            // Omvandlar URL:en till en "vänlig" absolut URL baserat på inställningar i Episerver.
//            var friendlyUrl = UriSupport.AbsoluteUrlBySettings(url.ToString());

//            // Returnerar den absoluta (externa) URL:en.
//            return friendlyUrl;
//        }

//        // Om ingen intern URL hittades returneras null.
//        return null;
//    }

//    // En utökad metod för strängar som tar en URL-sträng och omvandlar den till en Episerver-url med hjälp av UrlResolver.
//    public static string Url(this string url)
//    {
//        // Hämtar den vänliga URL:en baserat på den sträng som skickas in, med hjälp av UrlResolver.
//        return UrlResolver.Current.GetUrl(url);
//    }
//}

