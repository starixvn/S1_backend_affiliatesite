namespace AffiliateSite.WebApi.Affiliate
{
    public static class QueryModels
    {
        public class GetAffiliateStatementHistory
        {
            public int AffId { get; set; }
            public int BaseCurrency { get; set; }
            public int PageSize { get; set; }
            public int PageNumber { get; set; }
        }
    }
}
