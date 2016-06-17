namespace Microsoft.BusinessStore
{
    public class FailedSeatRequest
    {
        public string FailureReason { get; set; }
        public ProductKey ProductKey { get; set; }
        public string UserName { get; set; }
    }
}