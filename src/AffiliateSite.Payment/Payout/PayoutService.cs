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
        private readonly AffTransRepository _transRepository;
        private readonly ExchangeRateRepository _exchangeRateRepository;
        private readonly AffiliateRepository _affiliateRepository;
        private readonly IUnitOfWork _unitOfWork;

        public PayoutService(IUnitOfWork unitOfWork, AffPayoutRepository payoutRepository, AffTransRepository transRepository, ExchangeRateRepository exchangeRateRepository, AffiliateRepository affiliateRepository)
        {
            _unitOfWork = unitOfWork;
            _payoutRepository = payoutRepository;
            _transRepository = transRepository;
            _exchangeRateRepository = exchangeRateRepository;
            _affiliateRepository = affiliateRepository;
        }

        public async Task Handle(Commands.Payout command, int affId) 
        {
            var now = DateTime.UtcNow;
            var affInfo = await _affiliateRepository.GetById(affId);
            if (affInfo == null) 
                throw new Exception("Your account is closed. Please contact your administrator");

            if (await _payoutRepository.IsExistsPending(affId)) 
                throw new Exception("Oops, this account is having 1 pending pay out request, please update this transaction first!");

            var rate = _exchangeRateRepository.Query(affInfo.AffCurrency, 3, now);

            await _unitOfWork.BeginTransactionAsync();
            
            var affPayout = new AffPayout(affId, now, command.Amount);
            var refId = await _payoutRepository.Add(affPayout, _unitOfWork.Transaction);
            if (refId == 0) throw new Exception();
            var affTrans = new AffTrans(refId, affId, now, command.Amount);
            await _transRepository.Add(affTrans, _unitOfWork.Transaction); 
            await _unitOfWork.CommitAsync();
        }
    }
}
