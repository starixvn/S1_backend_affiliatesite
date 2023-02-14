using AffiliateSite.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AffiliateSite.Domain
{
    public class AffiliateCurrency : ValueObject<AffiliateCurrency>
    {
        int Value { get; }
        public AffiliateCurrency(int value)
        {
            Value = value;
        }
    }
}
