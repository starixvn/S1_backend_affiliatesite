namespace AffiliateSite.WebApi.Affiliate
{
    public static class ReadModels
    {
        public class AffiliateStatementHistory
        {
            public DateTimeOffset MonthDate { get; set; }
            public int TransType { get; set; }
            public decimal Amount { get; set; }
            public string Status { get; set; }
            public string Description { get; set; }
            public string CalculatedType { get; set; }
        }
    }
}
