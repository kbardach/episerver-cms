using EPiServer.Shell.ObjectEditing;
using System.ComponentModel.DataAnnotations;

namespace kim_episerver.Business.Extenders
{
    public class MetaDataExtender : IMetadataExtender
    {
        public void ModifyMetadata(ExtendedMetadata metadata, IEnumerable<Attribute> attributes)
        {
            foreach (var property in metadata.Properties)
            {
                if (property.PropertyName == "icategorizable_category")
                {
                    property.GroupName = "EPiServerCMS_SettingsPanel";
                    property.Order = 1;
                }

                foreach (var attribute in property.Attributes)
                {
                    if (attribute is ScaffoldColumnAttribute scaffoldColumnAttribute)
                    {
                        if (scaffoldColumnAttribute.Scaffold == false)
                        {
                            property.ShowForEdit = false;
                        }
                    }
                }
            }
        }
    }
}
