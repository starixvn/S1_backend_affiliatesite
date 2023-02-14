using AffiliateSite.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AffiliateSite.Domain
{
    public class AffDetail : Entity<AffId>
    {
        public AffDetail(Action<object> applier) : base(applier) { }
        public AffId ParentId { get; private set; }
        public AffiliateUserName UserName { get; private set; }
        public AffiliatePhone Phone { get; private set; }
        public AffiliateCustId CustId { get; private set; }
        public AffiliateLanguage language { get; private set; }

        public int Gender { get; private set; }
        protected override void When(object @event)
        {
            throw new NotImplementedException();
        }
    }
}
