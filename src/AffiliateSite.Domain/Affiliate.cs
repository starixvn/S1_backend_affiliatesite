using AffiliateSite.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AffiliateSite.Domain
{
    public class Affiliate : AggregateRoot<AffId>
    {
        public AffId AffId { get; set; }
        public AffiliateUserName UserName { get; private set; }
        public AffiliateFullName FullName { get; private set; }
        public AffiliatePassword Password { get; private set; }
        public AffiliateEmail Email { get; private set; }
        public AffiliatePhone Phone { get; private set; }
        public AffiliateContactApp ContactApp { get; private set; }
        public AffiliateUserName PlayerUserName { get; private set; }
        public AffiliateStatus Status { get; private set; }


        public Affiliate(AffiliateUserName userName, AffiliateFullName fullName) =>
            Apply(new Events.AffiliateSignup
            {
                UserName = userName,
                FirstName = fullName.FirstName,
                LastName = fullName.LastName
            });

        public void ChangePassword(AffiliatePassword password) =>
            Apply(
                new Events.AffiliateChangePassword
                {
                    UserName = UserName,
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
                    UserName = new AffiliateUserName(e.UserName);
                    FullName = new AffiliateFullName(e.FirstName, e.LastName);
                    Status = AffiliateStatus.Pending;
                    break;
                case Events.AffiliateChangePassword e:
                    UserName = new AffiliateUserName(e.UserName);
                    Password = new AffiliatePassword(e.NewPassword);
                    break;
                case Events.AffiliateUpdateInformation e:
                    Phone = new AffiliatePhone(e.Phone);
                    ContactApp = new AffiliateContactApp(e.Skype, e.QQ);
                    break;
            }
        }

        public enum AffiliateStatus 
        {
            Pending,
            Approved,
            Reject
        }
    }
}
