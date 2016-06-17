using System.Collections.Generic;

namespace Microsoft.BusinessStore
{
    public class BulkSeatOperationResultSet
    {
        public List<SeatDetails> SeatDetails { get; set; }
        public List<FailedSeatRequest> FailedSeatOperations { get; set; }
    }
}