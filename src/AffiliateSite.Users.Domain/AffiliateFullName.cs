using AffiliateSite.Framework;

namespace AffiliateSite.Users.Domain
{
    public class AffiliateFullName : ValueObject<AffiliateFullName>
    {
        public AffiliateFullName(string firstName, string lastName)
        {
            if (string.IsNullOrEmpty(firstName))
                throw new ArgumentOutOfRangeException(
                    nameof(firstName),
                    "Affiliate first name can not be empty"
                );

            if (string.IsNullOrEmpty(lastName))
                throw new ArgumentOutOfRangeException(
                    nameof(lastName),
                    "Affiliate last name can not be empty"
                );

            FirstName = firstName;
            LastName = lastName;
        }
        public string FirstName { get; internal set; }
        public string LastName { get; internal set; }
    }
}
