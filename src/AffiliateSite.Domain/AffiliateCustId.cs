using AffiliateSite.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AffiliateSite.Domain
{
    public class AffiliateCustId : ValueObject<AffiliateCustId>
    {
        int Value { get; }
        public AffiliateCustId(int value)
        {
            if (value == default)
                throw new ArgumentNullException(
                    nameof(value),
                    "The Id cannot be empty");
            Value = value;
        }

        public static implicit operator int(AffiliateCustId self) => self.Value;
    }
}
