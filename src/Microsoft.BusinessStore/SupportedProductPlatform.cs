using System.Collections.Generic;

namespace Microsoft.BusinessStore
{
    public class SupportedProductPlatform
    {
        public string PlatformName { get; set; }
        public VersionInfo MinVersion { get; set; }
        public VersionInfo MaxTestedVersion { get; set; }
        public List<ProductArchitectures> Architectures { get; set; }
    }
}
