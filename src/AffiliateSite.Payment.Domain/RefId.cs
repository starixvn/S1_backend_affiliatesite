using AffiliateSite.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AffiliateSite.Payment.Domain
{
    public class RefId :ValueObject<RefId>
    {
        public int Value { get; }
        public RefId(int value)
        {
            if (value == default)
                throw new ArgumentNullException(nameof(value), "id cannot be empty");

            Value = value;
        }
        public static implicit operator int(RefId self) => self.Value;
        public static implicit operator RefId(int value) => new(value);
    }
}
