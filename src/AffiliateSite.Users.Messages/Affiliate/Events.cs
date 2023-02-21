
namespace AffiliateSite.Users.Messages
{
    public static class Events
    {
        public class AffiliateSignup
        {
            public int AffId { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string UserName { get; set; }
            public string Email { get; set; }
        }

        public class AffiliateChangePassword
        {
            public string NewPassword { get; set; }
        }

        public class AffiliateUpdateInformation
        {
            public string Phone { get; set; }
            public string Skype { get; set; }
            public string QQ { get; set; }
        }
    }
}
