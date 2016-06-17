using System.Collections.Generic;

namespace Microsoft.BusinessStore
{
    internal class SeatDetailsResultSet
    {
        public string ContinuationToken { get; set; }
        public List<SeatDetails> Seats { get; set; }
    }
}