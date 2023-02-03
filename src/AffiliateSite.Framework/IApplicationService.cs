namespace AffiliateSite.Framework
{
    public interface IApplicationService
    {
        Task Handle(object command);
    }
}
