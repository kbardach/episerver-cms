using System.ComponentModel.DataAnnotations;

namespace kim_episerver
{
    public class Globals
    {
        [GroupDefinitions]
        public static class GroupNames
        {
            [Display(
                Name = "Metadata",
                Order = 40
             )]
            public const string MetaData = "Metadata";

            [Display(
                Name = "Specialized",
                Order = 50
             )]
            public const string Specialized = "Specialized";
        }
    }
}
