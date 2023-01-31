using AffiliateSite.Domain;
using AffiliateSite.Framework;
using AffiliateSite.WebApi.Contracts;

namespace AffiliateSite.WebApi.Services
{
    public class AffiliateService : IApplicationService
    {
        private readonly IAffiliateRepository _repository;
        private readonly ICrypto _crypto;
        public AffiliateService(IAffiliateRepository repository, ICrypto crypto)
        {
            _repository = repository;
            _crypto = crypto;
        }
        
        public async Task Handle(object command)
        {
            switch (command) 
            {
                case Affiliates.Signup cmd:
                    if (await _repository.Exists(cmd.PlayerUserName.ToString()))
                        throw new InvalidOperationException($"Player Username {cmd.PlayerUserName} has been used. Please choose another one!");

                    var classifiedAd = new Affiliate(new AffiliateUserName(cmd.PlayerUserName), new AffiliateFullName(cmd.FirstName, cmd.LastName));

                    await _repository.Add(classifiedAd);
                    break;
                case Affiliates.ChangePassword cmd:
                    var affiliate = await _repository.Load(cmd.UserName);
                    if (affiliate == null)
                        throw new InvalidOperationException($"Entity with id {cmd.UserName} cannot be found");

                    if(cmd.NewPassword != cmd.ConfirmNewPassword)
                        throw new InvalidPasswordException($"{cmd.NewPassword} and {cmd.ConfirmNewPassword} is not match");

                    if(_crypto.VerifyHashedPassword(affiliate.Password, cmd.OldPassword))
                        throw new InvalidPasswordException($"Old password is incorrect");
                    affiliate.ChangePassword(AffiliatePassword.FromString(cmd.NewPassword, _crypto));
                    await _repository.UpdatePassword(affiliate);
                    break;
            }
        }
    }
}
