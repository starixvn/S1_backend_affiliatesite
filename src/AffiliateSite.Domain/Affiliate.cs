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
        public AffiliateStatus Status { get; private set; }

        public void Signup(AffiliateUserName userName, AffiliateFullName fullName) =>
            Apply(new Events.AffiliateSignup
            {
                UserName = userName,
                FirstName = fullName.FirstName, 
                LastName = fullName.LastName
            });
        
        protected override void When(object @event)
        {
            switch (@event) 
            {
                case Events.AffiliateSignup e:
                    UserName = new AffiliateUserName(e.LastName);
                    FullName = new AffiliateFullName(e.FirstName, e.LastName);
                    Status = AffiliateStatus.Pending;
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
