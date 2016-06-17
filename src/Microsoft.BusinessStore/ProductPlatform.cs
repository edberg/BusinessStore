namespace Microsoft.BusinessStore
{
    public class ProductPlatform
    {
        public string PlatformName { get; set; }
        public VersionInfo MinVersion { get; set; }
        public VersionInfo MaxTestedVersion { get; set; }
    }
}