namespace AffiliateSite.Affiliate
{
    public static class Commands
    {
        public class Signup
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Email { get; set; }
            public string PlayerUserName { get; set; }
        }

        public class ChangePassword
        {
            public string UserName { get; set; }
            public string OldPassword { get; set; }
            public string NewPassword { get; set; }
            public string ConfirmNewPassword { get; set; }
        }

        public class UpdateInformation
        {
            public string UserName { get; set; }
            public string Phone { get; set; }
            public string Skype { get; set; }
            public string QQ { get; set; }
            public bool HasWebSite { get; set; }
            public List<string> WebSite { get; set; }
            public string NoSiteDesc { get; set; }
            public int DefaultBaseCurrency { get; set; }
        }
    }
}
