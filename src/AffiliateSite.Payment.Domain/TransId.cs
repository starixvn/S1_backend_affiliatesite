using AffiliateSite.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AffiliateSite.Payment.Domain
{
    public class TransId : ValueObject<TransId>
    {
        public int Value { get; }
        public TransId(int value)
        {
            if (value == default)
                throw new ArgumentNullException(nameof(value), "id cannot be empty");

            Value = value;
        }
        public static implicit operator int(TransId self) => self.Value;
        public static implicit operator TransId(int value) => new(value);
    }
}
