namespace AffiliateSite.WebApi.Services
{
    public interface IApplicationService
    {
        Task Handle(object command);
    }
}
