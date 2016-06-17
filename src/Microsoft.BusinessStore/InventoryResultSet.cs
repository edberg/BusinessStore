using System.Collections.Generic;

namespace Microsoft.BusinessStore
{
    internal class InventoryResultSet
    {
        public string ContinuationToken { get; set; }
        public List<InventoryEntryDetails> InventoryEntries { get; set; }
    }
}