using AffiliateSite.Framework;
using AffiliateSite.Payment.Messages;

namespace AffiliateSite.Payment.Domain
{
    public class AffPayout : AggregateRoot<RefId>
    {
        public AffId AffId { get; private set; }
        public decimal Amount { get; private set; }
        public decimal Payout { get; private set; }
        public int Currency { get; private set; }
        public DateTime TransDate { get; private set; }
        public PayoutStatus Status { get; private set; }
        public decimal Rate { get; private set; }
        public decimal PreferredPayment { get; private set; }
        public int PlayerCustId { get; private set; }
        public string PlayerUsername { get; private set; }
        public string PlayerCurrency { get; private set; }
        public string PlayerCurrencyCode { get; private set; }
        public string PlayerCurrencyName { get; private set; }
        public AffPayout(int affId, DateTime transDate, decimal amount) =>
            Apply(new Events.CreateAffPayout
            {
                AffId = affId,
                TransDate = transDate,
                Amount = amount
            });

        protected override void When(object @event)
        {
            switch(@event) 
            {
                case Events.CreateAffPayout e:
                    AffId = e.AffId;
                    Amount = e.Amount * -1;
                    Status = PayoutStatus.Pending;
                    TransDate= e.TransDate;
                    break;
            }
        }
    }
}
