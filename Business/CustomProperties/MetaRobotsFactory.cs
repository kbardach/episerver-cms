using EPiServer.Shell.ObjectEditing;

namespace kim_episerver.Business.CustomProperties
{
    public class MetaRobotsFactory : ISelectionFactory
    {
        public IEnumerable<ISelectItem> GetSelections(ExtendedMetadata metadata)
        {
            var selections = new List<ISelectItem>
            {
                new SelectItem { Value = "INDEX, FOLLOW", Text = "INDEX, FOLLOW" },
                new SelectItem { Value = "INDEX, NOFOLLOW", Text = "INDEX, NOFOLLOW" },
                new SelectItem { Value = "NOINDEX, FOLLOW", Text = "NOINDEX, FOLLOW" },
                new SelectItem { Value = "NOINDEX, NOFOLLOW", Text = "NOINDEX, NOFOLLOW" }
            };

            return selections;
        }
    }
}




//// Implementerar ISelectionFactory, vilket är ett gränssnitt som används för att tillhandahålla valalternativ i redigeringsgränssnittet.
//public class MetaRobotsFactory : ISelectionFactory
//{
//    // Metoden som returnerar de valalternativ som ska visas för redaktören.
//    // Den tar emot metadata, men används inte direkt i detta fall.
//    public IEnumerable<ISelectItem> GetSelections(ExtendedMetadata extendedMetadata)
//    {
//        // Skapar en lista med ISelectItem, där varje objekt representerar ett alternativ i redigeringsgränssnittet.
//        var selections = new List<ISelectItem>
//        {
//            // Varje SelectItem representerar ett alternativ med ett värde och en text som visas för användaren.
//            new SelectItem { Value = "INDEX, FOLLOW", Text = "INDEX, FOLLOW" },
//            new SelectItem { Value = "INDEX, NOFOLLOW", Text = "INDEX, NOFOLLOW" },
//            new SelectItem { Value = "NOINDEX, FOLLOW", Text = "NOINDEX, FOLLOW" },
//            new SelectItem { Value = "NOINDEX, NOFOLLOW", Text = "NOINDEX, NOFOLLOW" }
//        };

//        // Returnerar listan med alternativ för att visas i redigeringsgränssnittet.
//        return selections;
//    }
//}
