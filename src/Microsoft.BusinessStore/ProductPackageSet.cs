using System.Collections.Generic;

namespace Microsoft.BusinessStore
{
    public class ProductPackageSet
    {
        public string PackageSetId { get; set; }
        public List<ProductPackageDetails> ProductPackages { get; set; }
    }
}