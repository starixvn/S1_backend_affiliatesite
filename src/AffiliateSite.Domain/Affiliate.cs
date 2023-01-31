using AffiliateSite.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AffiliateSite.Domain
{
    public class Affiliate : Entity<AffiliateUserName>
    {
        public int AffId { get; set; }
        public AffiliateUserName UserName { get; private set; }
        public AffiliateFullName FullName { get; private set; }
        public AffiliatePassword Password { get; set; }
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
                    NewPassword = password.Password
                }
            );

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
