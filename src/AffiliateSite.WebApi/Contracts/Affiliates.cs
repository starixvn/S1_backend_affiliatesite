namespace AffiliateSite.WebApi.Contracts
{
    public static class Affiliates
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
    }
}
