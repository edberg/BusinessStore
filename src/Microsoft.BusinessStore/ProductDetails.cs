using System.Collections.Generic;

namespace Microsoft.BusinessStore
{
    public class ProductDetails
    {
        public ProductKey ProductKey { get; set; }
        public ProductType ProductType { get; set; }
        public ApplicationType ApplicationType { get; set; }
        public List<string> SupportedLanguages { get; set; }
        public string Category { get; set; }
        public List<AlternateIdentifier> AlternateIds { get; set; }
        public string PackageFamilyName { get; set; }
        public List<SupportedProductPlatform> SupportedPlatforms { get; set; }
    }
}