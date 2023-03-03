using AffiliateSite.Framework;
using AffiliateSite.Payment.Domain;
using AffiliateSite.Payment.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AffiliateSite.Payment.Payout
{
    public class PayoutService
    {
        private readonly AffPayoutRepository _payoutRepository;
        private readonly AffTransRepository _affTransRepository;
        private readonly IUnitOfWork _unitOfWork;

        public PayoutService(IUnitOfWork unitOfWork, AffPayoutRepository payoutRepository, AffTransRepository transRepository)
        {
            _unitOfWork = unitOfWork;
            _payoutRepository = payoutRepository;
            _affTransRepository = transRepository;
        }

        public async Task Handle(Commands.Payout command, int userId) 
        {
            await _unitOfWork.BeginTransactionAsync();
            var now = DateTime.UtcNow;
            var affPayout = new AffPayout(userId, now, command.Amount);
            var refId = await _payoutRepository.Add(affPayout, _unitOfWork.Transaction);
            if (refId == 0) throw new Exception();
            var affTrans = new AffTrans(refId, userId, now, command.Amount);
            await _affTransRepository.Add(affTrans, _unitOfWork.Transaction); 
            await _unitOfWork.CommitAsync();
        }
    }
}
