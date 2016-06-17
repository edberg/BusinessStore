using System;

namespace Microsoft.BusinessStore
{
    public class ProductImage
    {
        public Uri Location { get; set; }
        public string Purpose { get; set; }
        public string Height { get; set; }
        public string Width { get; set; }
        public string Caption { get; set; }
        public string BackgroundColor { get; set; }
        public string ForegroundColor { get; set; }
        public long FileSize { get; set; }
    }
}