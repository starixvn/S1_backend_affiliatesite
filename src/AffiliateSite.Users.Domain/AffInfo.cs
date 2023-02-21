using AffiliateSite.Framework;
using AffiliateSite.Users.Messages;

namespace AffiliateSite.Users.Domain
{
    public class AffInfo : AggregateRoot<AffId>
    {
        public AffiliateUserName UserName { get; private set; }
        public AffiliateFullName FullName { get; private set; }
        public AffiliateStatus Status { get; private set; }
        public AffiliateCurrency Currency { get; private set; }
        public AffiliateEmail Email { get; private set; }
        public AffiliatePassword Password { get; private set; }
        public AffDetail AffDetail { get; private set; }

        public AffInfo() { }

        public AffInfo(AffId affId, AffiliateUserName userName, AffiliateFullName fullName, AffiliateEmail email) =>
            Apply(new Events.AffiliateSignup
            {
                AffId = affId,
                UserName = userName,
                FirstName = fullName.FirstName,
                LastName = fullName.LastName,
                Email = email
            });

        public void ChangePassword(AffiliatePassword password) =>
            Apply(
                new Events.AffiliateChangePassword
                {
                    NewPassword = password.Value
                }
            );

        public void UpdateInformation(AffiliatePhone phone, AffiliateContactApp contactApp) =>
            Apply(
                new Events.AffiliateUpdateInformation
                {
                    Phone = phone,
                    Skype = contactApp.Skype,
                    QQ = contactApp.QQ,
                });

        protected override void When(object @event)
        {
            switch (@event)
            {
                case Events.AffiliateSignup e:
                    Id = new AffId(e.AffId);
                    UserName = new AffiliateUserName(e.UserName);
                    FullName = new AffiliateFullName(e.FirstName, e.LastName);
                    Status = AffiliateStatus.Pending;
                    Email = new AffiliateEmail(e.Email);
                    break;
                case Events.AffiliateChangePassword e:
                    Password = new AffiliatePassword(e.NewPassword);
                    break;
            }
        }

        public enum AffiliateStatus
        {
            Pending,
            Approved,
            Disapproved,
            Suspended,
            Closed
        }
    }
}
