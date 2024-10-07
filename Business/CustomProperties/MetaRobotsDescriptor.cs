using EPiServer.Shell.ObjectEditing.EditorDescriptors;
using EPiServer.Shell.ObjectEditing;
using kim_episerver.Business.CustomProperties;

namespace kim_episerver.Business.CustomProperties
{
    [EditorDescriptorRegistration(
        TargetType = typeof(string),
        UIHint = "MetaRobots"
    )]
    public class MetaRobotsDescriptor : EditorDescriptor
    {
        public override void ModifyMetadata(ExtendedMetadata metadata, IEnumerable<Attribute> attributes)
        {
            SelectionFactoryType = typeof(MetaRobotsFactory);

            ClientEditingClass = "epi-cms/contentediting/editors/SelectionEditor";

            base.ModifyMetadata(metadata, attributes);
        }
    }
}




//// Registrerar en EditorDescriptor som ska användas för egenskaper av typen 'string' med UI-hint "MetaRobots".
//[EditorDescriptorRegistration(
//    TargetType = typeof(string),  // Målet är en strängegenskap.
//    UIHint = "MetaRobots"         // Används när en strängegenskap har UIHint "MetaRobots".
//)]
//public class MetaRobotsDescriptor : EditorDescriptor
//{
//    // Modifierar metadata för att anpassa redigeringsgränssnittet för en specifik egenskap.
//    public override void ModifyMetadata(ExtendedMetadata metadata, IEnumerable<Attribute> attributes)
//    {
//        // Sätter vilken "SelectionFactory" som används för att tillhandahålla valalternativ för redigeraren.
//        // Här används en anpassad klass, 'MetaRobotsFactory', för att generera alternativen.
//        SelectionFactoryType = typeof(MetaRobotsFactory);

//        // Bestämmer vilken klientredigerare (JS-baserad editor) som ska användas.
//        // I detta fall används Episerver's inbyggda SelectionEditor för att visa alternativen.
//        ClientEditingClass = "epi-cms/contentediting/editors/SelectionEditor";

//        // Anropar basens (EditorDescriptor) implementering för att bibehålla övrig metadatahantering.
//        base.ModifyMetadata(metadata, attributes);
//    }
//}
