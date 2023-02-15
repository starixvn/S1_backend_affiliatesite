namespace AffiliateSite.WebApi.Auth
{
    public static class Contracts
    {
        public class Signin 
        {
            public string UserName { get; set; }
            public string Password { get; set; }
        }
    }
}
