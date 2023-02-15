using AffiliateSite.Domain;
using AffiliateSite.Framework;
using AffiliateSite.Infrastructure;

namespace AffiliateSite.Affiliate
{
    public class AffiliateService : IApplicationService
    {
        private readonly IUsernameAutoIncrementRepository _autoIncrementRepository;
        private readonly IAffIInfoRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        private const string PREFIX = "N88AFF";
        public AffiliateService(IUsernameAutoIncrementRepository autoIncrementRepository, IAffIInfoRepository repository, IUnitOfWork unitOfWork)
        {
            _autoIncrementRepository = autoIncrementRepository;
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(object command)
        {
            switch (command)
            {
                case Commands.Signup cmd:
                    await _unitOfWork.BeginTransactionAsync();
                    var id = await _autoIncrementRepository.Generate(PREFIX, _unitOfWork.Transaction);
                    var classifiedAd = new AffInfo(new AffId(id), new AffiliateUserName(PREFIX, id), new AffiliateFullName(cmd.FirstName, cmd.LastName), AffiliateEmail.FromString(cmd.Email));
                    await _repository.Add(classifiedAd, _unitOfWork.Transaction);
                    await _unitOfWork.CommitAsync();
                    break;
                case Commands.ChangePassword cmd:
                    if (cmd.NewPassword != cmd.ConfirmNewPassword)
                        throw new InvalidOperationException($"{cmd.NewPassword} and {cmd.ConfirmNewPassword} is not match");

                    var affiliate = await _repository.Load(cmd.UserName);
                    if (affiliate == null)
                        throw new InvalidOperationException($"Entity with id {cmd.UserName} cannot be found");

                    affiliate.ChangePassword(AffiliatePassword.FromString(CryptographyHelper.Encrypt(cmd.NewPassword)));
                    await _repository.UpdatePassword(affiliate);
                    break;
                case Commands.UpdateInformation cmd:
                    var aff = await _repository.Load(cmd.UserName);
                    if (aff == null)
                        throw new InvalidOperationException($"Entity with user name {cmd.UserName} cannot be found");
                    aff.UpdateInformation(AffiliatePhone.FromString(cmd.Phone), new AffiliateContactApp(cmd.Skype, cmd.QQ));
                    await _repository.UpdateInformation(aff);
                    break;
            }
        }
    }
}
