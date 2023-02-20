using AffiliateSite.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AffiliateSite.Users.Domain
{
    public class AffId : ValueObject<AffId>
    {
        public int Value { get; }
        public AffId(int value)
        {
            if (value == default)
                throw new ArgumentNullException(nameof(value), "id cannot be empty");

            Value = value;
        }
        public static implicit operator int(AffId self) => self.Value;
        public static implicit operator AffId(int value) => new(value);
    }
}
