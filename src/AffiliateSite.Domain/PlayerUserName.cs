namespace AffiliateSite.Domain
{
    public class PlayerUserName
    {
        private string UserName { get; set; }

        public PlayerUserName(string userName)
        {
            if (string.IsNullOrEmpty(userName))
                throw new ArgumentNullException(nameof(userName), "Player user name cannot be empty");

            UserName = userName;
        }

        public static implicit operator string(PlayerUserName self) => self.UserName;
    }
}
