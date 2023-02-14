using AffiliateSite.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AffiliateSite.Domain
{
    public class UsernameAutoIncrement : Entity<AffId>
    {
        public AffId AffId { get; set; }
        public string PrefixName { get; set; }

        protected override void When(object @event)
        {
            throw new NotImplementedException();
        }
    }
}
