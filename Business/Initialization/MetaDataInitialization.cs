using EPiServer.Framework.Initialization;
using EPiServer.Framework;
using EPiServer.Initialization;
using EPiServer.Shell.ObjectEditing;
using kim_episerver.Business.Extenders;
using EPiServer.ServiceLocation;

namespace kim_episerver.Business.Initialization
{
    [InitializableModule]
    [ModuleDependency(typeof(CmsCoreInitialization))]
    public class MetaDataInitialization : IInitializableModule
    {
        public void Initialize(InitializationEngine context)
        {
            if (context.HostType == HostType.WebApplication)
            {
                var registry = context.Locate.Advanced.GetInstance<MetadataHandlerRegistry>();
                registry.RegisterMetadataHandler(typeof(ContentData), new MetaDataExtender());
            }
        }

        public void Uninitialize(InitializationEngine context)
        {
        }
    }
}
