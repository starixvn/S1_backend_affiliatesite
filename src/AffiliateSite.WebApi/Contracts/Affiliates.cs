namespace AffiliateSite.WebApi.Contracts
{
    public static class Affiliates
    {
        public class Signup 
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Email { get; set; }
            public string UserName { get; set; }
        }
    }
}
