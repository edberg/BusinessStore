using System.Collections.Generic;

namespace Microsoft.BusinessStore
{
    public class LocalizedProductDetail
    {
        public string Language { get; set; }
        public string DisplayName { get; set; }
        public string Description { get; set; }
        public List<ProductImage> Images { get; set; }
        public PublisherDetails Publisher { get; set; }
    }
}