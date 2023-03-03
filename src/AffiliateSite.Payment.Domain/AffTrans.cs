using AffiliateSite.Framework;
using AffiliateSite.Payment.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AffiliateSite.Payment.Domain
{

    public class AffTrans : Entity<TransId>
    {
        public AffTrans(RefId refId, AffId affId, DateTime transDate, decimal amount) 
        {
            Apply(new Events.CreateAffTrans 
            {
                RefId = refId,
                AffId = affId,
                TransDate = transDate,
                Amount = amount,
        });
        }   
        public RefId RefId { get; private set; }
        public AffId AffId { get; private set; }
        public decimal Amount { get; private set; }
        public DateTime TransDate { get; private set; }
        public PayoutStatus Status { get; private set; }
        public string Description { get; private set; }
        public int Currency { get; private set; }
        public decimal Rate { get; private set; }

        protected override void When(object @event)
        {
            switch (@event)
            {
                case Events.CreateAffTrans e:
                    AffId= e.AffId;
                    Amount= e.Amount;
                    TransDate = e.TransDate;
                    Status = PayoutStatus.Pending;
                    Description = "Request payout";
                    RefId = e.RefId;
                    break;
            }
        }
    }
}
