using System;

namespace Microsoft.BusinessStore
{
    public class SeatDetails
    {
        public string AssignedTo { get; set; }
        public DateTime DateAssigned { get; set; }
        public SeatState State { get; set; }
        public ProductKey ProductKey { get; set; }
    }
}