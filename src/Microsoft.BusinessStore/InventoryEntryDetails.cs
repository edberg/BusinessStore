using System;

namespace Microsoft.BusinessStore
{
    public class InventoryEntryDetails
    {
        public ProductKey ProductKey { get; set; }
        public long SeatCapacity { get; set; }
        public long AvailableSeats { get; set; }
        public DateTime LastModified { get; set; }
        public LicenseType LicenseType { get; set; }
        public InventoryDistributionPolicy DistributionPolicy { get; set; }
        public InventoryStatus Status { get; set; }
    }
}