using AffiliateSite.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AffiliateSite.Link.Domain
{
    public class AffMediaLinkId : ValueObject<AffMediaLinkId>
    {
        public int Value { get; }
        public AffMediaLinkId(int value)
        {
            if (value == default)
                throw new ArgumentNullException(nameof(value), "id cannot be empty");

            Value = value;
        }
        public static implicit operator int(AffMediaLinkId self) => self.Value;
        public static implicit operator AffMediaLinkId(int value) => new(value);
    }
}
